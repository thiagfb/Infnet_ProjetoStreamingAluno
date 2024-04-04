using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class PlanoService
    {
        private PlanoRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public PlanoService(PlanoRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public PlanoDto Criar(PlanoDto dto)
        {
            dto.Id = Guid.NewGuid();

            Plano classe = this.Mapper.Map<Plano>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<PlanoDto>(classe);
        }

        public PlanoDto Atualizar(PlanoDto dto)
        {
            Plano classe = this.Mapper.Map<Plano>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<PlanoDto>(classe);
        }

        public PlanoDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<PlanoDto>(classe);
        }

        public PlanoDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<PlanoDto>(classe);
        }

        public IEnumerable<PlanoDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<PlanoDto>>(classe);
        }
    }
}
