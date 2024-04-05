using AutoMapper;
using Streaming.Application.Conta.Dto;
using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Core.Extension;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Transacao.Aggregates;
using Streaming.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }
        private CartaoRepository CartaoRepository { get; set; }

        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository, CartaoRepository cartaoRepository)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
            CartaoRepository = cartaoRepository;
        }

        public UsuarioDto Criar(UsuarioDto dto)
        {
            try
            {
                if (this.UsuarioRepository.Exists(x => x.Email == dto.Email))
                    throw new Exception("Usuario já existente na base");


                Plano plano = this.PlanoRepository.GetById(dto.PlanoId);

                if (plano == null)
                    throw new Exception("Plano não existente ou não encontrado");


                Cartao cartao = this.CartaoRepository.Find(x => x.Numero == dto.Cartao).First();

                Usuario usuario = new Usuario();
                usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DtNascimento, dto.Telefone, plano, cartao);

                this.UsuarioRepository.Save(usuario);
                var result = this.Mapper.Map<UsuarioDto>(usuario);

                return result;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioDto Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public UsuarioDto Autenticar(String email, String senha)
        {
            //var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha.EncryptPassword()).FirstOrDefault();
            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha).FirstOrDefault();
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }
    }    
}
