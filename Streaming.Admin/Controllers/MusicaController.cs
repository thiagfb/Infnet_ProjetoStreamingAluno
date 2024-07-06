using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Admin.Controllers
{
    [Authorize]
    public class MusicaController : Controller
    {
        private MusicaService musicaService;

        public MusicaController(MusicaService musicaService)
        {
            this.musicaService = musicaService;
        }

        public IActionResult Index()
        {
            var result = this.musicaService.GetAll();

            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Salvar(MusicaDto dto)
        {
            //if (ModelState.IsValid == false)
            //    return View("Criar");

            this.musicaService.Criar(dto);

            return RedirectToAction("Index");
        }
    }
}
