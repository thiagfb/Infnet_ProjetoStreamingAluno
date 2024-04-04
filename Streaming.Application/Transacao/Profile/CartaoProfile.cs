using Streaming.Application.Transacao.Dto;
using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Application.Transacao.Profile
{
    public class CartaoProfile : AutoMapper.Profile
    {
        public CartaoProfile()
        {
            CreateMap<CartaoDto, Cartao>().ReverseMap();
        }
    }
}
