using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Streaming;
using Streaming.Application.Streaming.Dto;

namespace Streaming.Api.Controllers.Streaming
{

    [Route("api/[controller]")]
    [ApiController]
    public class MusicaPlayListController : ControllerBase
    {
        private MusicaPlayListService _Service;

        public MusicaPlayListController(MusicaPlayListService MusicaPlayListService)
        {
            _Service = MusicaPlayListService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] MusicaPlayListDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._Service.Criar(dto);

            return Created($"/MusicaPlayList/{result.MusicaId}", result);
        }

        [HttpDelete("{idUsuario}/{idMusica}")]
        public IActionResult Excluir(Guid idUsuario, Guid idMusica)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._Service.Delete(idUsuario, idMusica);

            return Created($"/MusicaPlayList/{result.MusicaId}", result);
        }
    }
}
