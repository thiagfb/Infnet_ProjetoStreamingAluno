using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Conta;
using Streaming.Application.Conta.Dto;

namespace Streaming.Api.Controllers.Conta
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Streaming-user")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _service;

        public UsuarioController(UsuarioService usuarioService)
        {
            _service = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._service.Criar(dto);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._service.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Request.LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = this._service.Autenticar(login.Email, login.Senha);

            if (result == null)
            {
                return BadRequest(new
                {
                    Error = "email ou senha inválidos"
                });
            }

            return Ok(result);

        }
    }
}
