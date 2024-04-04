using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming.Dto;
using Streaming.Application.Streaming;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {
        private PlanoService _PlanoService;

        public PlanoController(PlanoService PlanoService)
        {
            _PlanoService = PlanoService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PlanoDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._PlanoService.Criar(dto);

            return Created($"/Plano/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] PlanoDto dto)
        {
            var itemToUpdate = this._PlanoService.GetId(dto.Id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", dto.Id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    var result = this._PlanoService.Atualizar(dto);

                    return Created($"/Plano/{result.Id}", result);
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
            var itemToUpdate = this._PlanoService.GetId(id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    this._PlanoService.Excluir(id);

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
            var result = this._PlanoService.GetId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._PlanoService.GetAll();

            return Ok(result);
        }
    }
}
