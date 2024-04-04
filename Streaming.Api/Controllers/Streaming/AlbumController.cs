using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming.Dto;
using Streaming.Application.Streaming;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private AlbumService _service;

        public AlbumController(AlbumService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] AlbumDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._service.Criar(dto);

            return Created($"/Album/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] AlbumDto dto)
        {
            var itemToUpdate = this._service.GetId(dto.Id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", dto.Id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    var result = this._service.Atualizar(dto);

                    return Created($"/Album/{result.Id}", result);
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
            var itemToUpdate = this._service.GetId(id);

            if (itemToUpdate == null)
            {
                var msg = String.Format("Registro {0} não encontrado.", id);
                return NotFound(msg);
            }
            else
            {
                try
                {
                    this._service.Excluir(id);

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
            var result = this._service.GetId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._service.GetAll();

            return Ok(result);
        }
    }
}
