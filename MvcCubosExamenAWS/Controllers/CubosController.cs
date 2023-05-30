using Microsoft.AspNetCore.Mvc;
using MvcCubosExamenAWS.Models;
using MvcCubosExamenAWS.Repositories;

namespace MvcCubosExamenAWS.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetAllCubos());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.repo.GetCuboID(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteCuboID(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cubo cubo)
        {
            await this.repo.InsertCubo(cubo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await this.repo.GetCuboID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cubo cubo)
        {
            await this.repo.EditCubo(cubo);
            return RedirectToAction("Index");
        }


    }
}
