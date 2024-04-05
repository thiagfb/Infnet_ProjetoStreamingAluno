using Streaming.Application.Conta.Dto;
using Streaming.Application.Transacao.Dto;
using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Application.Conta.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Usuario, UsuarioDto>()
            .AfterMap((s, d) =>
            {
                var plano = s.LstAssinatura?.FirstOrDefault(a => a.Ativo)?.Plano;

                if (plano != null)
                    d.PlanoId = plano.Id;

                d.Senha = "xxxxxxxxx";

            });

            CreateMap<CartaoDto, Cartao>()
                .ForPath(x => x.Limite.Valor, m => m.MapFrom(f => f.Limite))
                .ReverseMap();
        }
    }
}
