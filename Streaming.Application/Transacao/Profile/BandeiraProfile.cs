using Streaming.Application.Transacao.Dto;
using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Application.Transacao.Profile
{
    public class BandeiraProfile : AutoMapper.Profile
    {
        public BandeiraProfile()
        {
            CreateMap<BandeiraDto, Bandeira>().ReverseMap();
        }
    }
}
