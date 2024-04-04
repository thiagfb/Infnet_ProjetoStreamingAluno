using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class FaixaProfile : AutoMapper.Profile
    {
        public FaixaProfile()
        {
            CreateMap<FaixaDto, Faixa>().ReverseMap();

            CreateMap<MusicaDto, Musica>().ReverseMap();
        }
    }
}
