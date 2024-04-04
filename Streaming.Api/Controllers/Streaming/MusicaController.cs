using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming.Dto;
using Streaming.Application.Streaming;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private MusicaService _MusicaService;

        public MusicaController(MusicaService MusicaService)
        {
            _MusicaService = MusicaService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] MusicaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._MusicaService.Criar(dto);

            return Created($"/Musica/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] MusicaDto dto)
        {
            var itemToUpdate = this._MusicaService.GetId(dto.Id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", dto.Id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    var result = this._MusicaService.Atualizar(dto);

                    return Created($"/Musica/{result.Id}", result);
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
            var itemToUpdate = this._MusicaService.GetId(id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    this._MusicaService.Excluir(id);

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
            var result = this._MusicaService.GetId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._MusicaService.GetAll();

            return Ok(result);
        }
    }
}
