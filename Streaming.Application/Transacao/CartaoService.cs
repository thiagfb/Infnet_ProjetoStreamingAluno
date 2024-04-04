using AutoMapper;
using Streaming.Application.Transacao.Dto;
using Streaming.Domain.Transacao.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Transacao
{
    public class CartaoService
    {
        private CartaoRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public CartaoService(CartaoRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public CartaoDto Criar(CartaoDto dto)
        {
            dto.Id = Guid.NewGuid();

            Cartao classe = this.Mapper.Map<Cartao>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<CartaoDto>(classe);
        }

        public CartaoDto Atualizar(CartaoDto dto)
        {
            Cartao classe = this.Mapper.Map<Cartao>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<CartaoDto>(classe);
        }

        public CartaoDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<CartaoDto>(classe);
        }

        public CartaoDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<CartaoDto>(classe);
        }

        public IEnumerable<CartaoDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<CartaoDto>>(classe);
        }
    }
}
