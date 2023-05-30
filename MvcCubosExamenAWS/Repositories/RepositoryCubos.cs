using Microsoft.EntityFrameworkCore;
using MvcCubosExamenAWS.Data;
using MvcCubosExamenAWS.Models;

namespace MvcCubosExamenAWS.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        private int GetMaxIDCubo()
        {
            if (this.context.Cubos.Count() != 0)
            {
                return this.context.Cubos.Max(x => x.IdCubo) + 1;
            }
            else
            {
                return 1;
            }
        }

        public async Task<List<Cubo>> GetAllCubos()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<Cubo> GetCuboID(int id)
        {
            return await this.context.Cubos.FirstOrDefaultAsync(x => x.IdCubo == id);
        }

        public async Task InsertCubo(Cubo cubo)
        {
            cubo.IdCubo = this.GetMaxIDCubo();
            this.context.Cubos.Add(cubo);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCuboID(int id)
        {
            this.context.Cubos.Remove(await this.GetCuboID(id));

            await this.context.SaveChangesAsync();
        }

        public async Task EditCubo(Cubo cubo)
        {
            Cubo c = await this.GetCuboID(cubo.IdCubo);

            c.Nombre = cubo.Nombre;
            c.Marca = cubo.Marca;
            c.Imagen = cubo.Imagen;
            c.Precio = cubo.Precio;

            await this.context.SaveChangesAsync();
        }
    }
}
