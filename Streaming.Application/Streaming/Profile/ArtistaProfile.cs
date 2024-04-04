using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class ArtistaProfile : AutoMapper.Profile
    {
        public ArtistaProfile()
        {
            CreateMap<ArtistaDto, Artista>().ReverseMap();
        }
    }
}
