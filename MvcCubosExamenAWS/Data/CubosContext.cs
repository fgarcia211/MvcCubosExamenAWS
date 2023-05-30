using Microsoft.EntityFrameworkCore;
using MvcCubosExamenAWS.Models;

namespace MvcCubosExamenAWS.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options): base(options) { }

        public DbSet<Cubo> Cubos { get; set; }
    }
}
