using AutoMapper;
using Streaming.Application.Transacao.Dto;
using Streaming.Domain.Transacao.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Transacao
{
    public class BandeiraService
    {
        private BandeiraRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public BandeiraService(BandeiraRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public BandeiraDto Criar(BandeiraDto dto)
        {
            dto.Id = Guid.NewGuid();

            Bandeira classe = this.Mapper.Map<Bandeira>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<BandeiraDto>(classe);
        }

        public BandeiraDto Atualizar(BandeiraDto dto)
        {
            Bandeira classe = this.Mapper.Map<Bandeira>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<BandeiraDto>(classe);
        }

        public BandeiraDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<BandeiraDto>(classe);
        }

        public BandeiraDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<BandeiraDto>(classe);
        }

        public IEnumerable<BandeiraDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<BandeiraDto>>(classe);
        }
    }
}
