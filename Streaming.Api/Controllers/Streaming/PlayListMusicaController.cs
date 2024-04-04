using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming.Dto;
using Streaming.Application.Streaming;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListMusicaController : ControllerBase
    {
        private PlayListMusicaService _PlayListMusicaService;

        public PlayListMusicaController(PlayListMusicaService PlayListMusicaService)
        {
            _PlayListMusicaService = PlayListMusicaService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PlayListMusicaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._PlayListMusicaService.Criar(dto);

            return Created($"/PlayListMusica/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] PlayListMusicaDto dto)
        {
            var itemToUpdate = this._PlayListMusicaService.GetId(dto.Id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", dto.Id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    var result = this._PlayListMusicaService.Atualizar(dto);

                    return Created($"/PlayListMusica/{result.Id}", result);
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
            var itemToUpdate = this._PlayListMusicaService.GetId(id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    this._PlayListMusicaService.Excluir(id);

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
            var result = this._PlayListMusicaService.GetId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._PlayListMusicaService.GetAll();

            return Ok(result);
        }
    }
}
