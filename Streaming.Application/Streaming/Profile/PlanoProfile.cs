using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class PlanoProfile : AutoMapper.Profile
    {
        public PlanoProfile()
        {
            CreateMap<PlanoDto, Plano>().ReverseMap();
        }
    }
}
