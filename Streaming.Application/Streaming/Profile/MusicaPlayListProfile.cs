using Streaming.Application.Conta.Dto;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class MusicaPlayListProfile : AutoMapper.Profile
    {
        public MusicaPlayListProfile()
        {
            CreateMap<MusicaDto, Musica>().ReverseMap();

            CreateMap<UsuarioDto, Usuario>().ReverseMap();
        }
    }
}
