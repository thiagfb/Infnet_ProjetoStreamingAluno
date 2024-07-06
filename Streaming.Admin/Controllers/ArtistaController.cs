using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming;
using Streaming.Application.Streaming.Dto;

namespace Streaming.Admin.Controllers
{
    public class ArtistaController : Controller
    {
        private ArtistaService artistaService;

        public ArtistaController(ArtistaService artistaService)
        {
            this.artistaService = artistaService;
        }

        public IActionResult Index()
        {
            var result = this.artistaService.GetAll();

            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Salvar(ArtistaDto dto)
        {
            if (ModelState.IsValid == false)
                return View("Criar");

            this.artistaService.Criar(dto);

            return RedirectToAction("Index");
        }
    }
}
