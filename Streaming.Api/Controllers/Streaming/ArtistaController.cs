using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming;
using Streaming.Application.Streaming.Dto;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private ArtistaService _artistaService;

        public ArtistaController(ArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ArtistaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._artistaService.Criar(dto);

            return Created($"/artista/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ArtistaDto dto)
        {
            var itemToUpdate = this._artistaService.GetId(dto.Id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", dto.Id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    var result = this._artistaService.Atualizar(dto);

                    return Created($"/artista/{result.Id}", result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"error: {ex.Message}");
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var itemToUpdate = this._artistaService.GetId(id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    this._artistaService.Excluir(id);

                    return Ok("Excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"error: {ex.Message}");
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            var result = this._artistaService.GetId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._artistaService.GetAll();

            return Ok(result);
        }
    }
}
