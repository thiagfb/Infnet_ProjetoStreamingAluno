using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming.Dto;
using Streaming.Application.Streaming;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaixaController : ControllerBase
    {
        private FaixaService _FaixaService;

        public FaixaController(FaixaService FaixaService)
        {
            _FaixaService = FaixaService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] FaixaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._FaixaService.Criar(dto);

            return Created($"/Faixa/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] FaixaDto dto)
        {
            var itemToUpdate = this._FaixaService.GetId(dto.Id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", dto.Id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    var result = this._FaixaService.Atualizar(dto);

                    return Created($"/Faixa/{result.Id}", result);
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
            var itemToUpdate = this._FaixaService.GetId(id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    this._FaixaService.Excluir(id);

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
            var result = this._FaixaService.GetId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._FaixaService.GetAll();

            return Ok(result);
        }
    }
}
