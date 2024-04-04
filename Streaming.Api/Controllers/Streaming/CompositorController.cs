using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Streaming.Application.Streaming;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Api.Controllers.Streaming
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositorController : ControllerBase
    {
        private CompositorService _service;

        public CompositorController(CompositorService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CompositorDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._service.Criar(dto);

            return Created($"/Compositor/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] CompositorDto dto)
        {
            try
            {
                var result = this._service.Atualizar(dto);

                return Created($"/Compositor/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"error: {ex.Message}");
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
