using AutoMapper;
using Streaming.Application.Transacao.Dto;
using Streaming.Repository.Repository;

namespace Streaming.Application.Transacao
{
    public class TransacaoService
    {
        private TransacaoRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public TransacaoService(TransacaoRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public TransacaoDto Criar(TransacaoDto dto)
        {
            dto.Id = Guid.NewGuid();

            Domain.Transacao.Aggregates.Transacao classe = this.Mapper.Map<Domain.Transacao.Aggregates.Transacao>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<TransacaoDto>(classe);
        }

        public TransacaoDto Atualizar(TransacaoDto dto)
        {
            Domain.Transacao.Aggregates.Transacao classe = this.Mapper.Map<Domain.Transacao.Aggregates.Transacao>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<TransacaoDto>(classe);
        }

        public TransacaoDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<TransacaoDto>(classe);
        }

        public TransacaoDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<TransacaoDto>(classe);
        }

        public IEnumerable<TransacaoDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<TransacaoDto>>(classe);
        }
    }
}
