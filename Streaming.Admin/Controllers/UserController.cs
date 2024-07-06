using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Admin;
using Streaming.Application.Admin.Dto;

namespace Streaming.Admin.Controllers
{
    public class UserController : Controller
    {
        private UsuarioAdminService usuarioAdminService;

        public UserController(UsuarioAdminService usuarioAdminService) 
        { 
            this.usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Index()
        {
            var result = this.usuarioAdminService.ObterTodos();

            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Salvar(UsuarioAdminDto dto)
        {
            if (ModelState.IsValid == false)
                return View("Criar");

            this.usuarioAdminService.Salvar(dto);

            return RedirectToAction("Index");
        }
    }
}
