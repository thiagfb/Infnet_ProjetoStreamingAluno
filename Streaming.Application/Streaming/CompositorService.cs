using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class CompositorService
    {
        private CompositorRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public CompositorService(CompositorRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public CompositorDto Criar(CompositorDto dto)
        {
            dto.Id = Guid.NewGuid();

            Compositor classe = this.Mapper.Map<Compositor>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<CompositorDto>(classe);
        }

        public CompositorDto Atualizar(CompositorDto dto)
        {
            Compositor classe = this.Mapper.Map<Compositor>(dto);

            this.Repository.Update(classe);

            return this.Mapper.Map<CompositorDto>(classe);
        }

        public CompositorDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<CompositorDto>(classe);
        }

        public CompositorDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<CompositorDto>(classe);
        }

        public IEnumerable<CompositorDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<CompositorDto>>(classe);
        }
    }
}
