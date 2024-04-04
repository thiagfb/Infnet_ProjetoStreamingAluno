using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming.Dto;
using Streaming.Application.Streaming;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private GeneroService _GeneroService;

        public GeneroController(GeneroService GeneroService)
        {
            _GeneroService = GeneroService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] GeneroDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._GeneroService.Criar(dto);

            return Created($"/Genero/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] GeneroDto dto)
        {
            var itemToUpdate = this._GeneroService.GetId(dto.Id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", dto.Id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    var result = this._GeneroService.Atualizar(dto);

                    return Created($"/Genero/{result.Id}", result);
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
            var itemToUpdate = this._GeneroService.GetId(id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    this._GeneroService.Excluir(id);

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
            var result = this._GeneroService.GetId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._GeneroService.GetAll();

            return Ok(result);
        }
    }
}
