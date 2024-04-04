using Streaming.Application.Transacao.Dto;

namespace Streaming.Application.Transacao.Profile
{
    public class TransacaoProfile : AutoMapper.Profile
    {
        public TransacaoProfile()
        {
            CreateMap<TransacaoDto, Domain.Transacao.Aggregates.Transacao>().ReverseMap();
        }
    }
}
