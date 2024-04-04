using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class MusicaProfile : AutoMapper.Profile
    {
        public MusicaProfile()
        {
            CreateMap<MusicaDto, Musica>().ReverseMap();

            CreateMap<GeneroDto, Genero>().ReverseMap();

            CreateMap<CompositorDto, Compositor>().ReverseMap();
        }
    }
}
