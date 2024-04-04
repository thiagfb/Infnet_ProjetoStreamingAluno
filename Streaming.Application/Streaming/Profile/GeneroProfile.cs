using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class GeneroProfile : AutoMapper.Profile
    {
        public GeneroProfile()
        {
            CreateMap<GeneroDto, Genero>().ReverseMap();
        }
    }
}
