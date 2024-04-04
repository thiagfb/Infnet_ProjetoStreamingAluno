using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class GeneroService
    {
        private GeneroRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public GeneroService(GeneroRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public GeneroDto Criar(GeneroDto dto)
        {
            dto.Id = Guid.NewGuid();

            Genero classe = this.Mapper.Map<Genero>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<GeneroDto>(classe);
        }

        public GeneroDto Atualizar(GeneroDto dto)
        {
            Genero classe = this.Mapper.Map<Genero>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<GeneroDto>(classe);
        }

        public GeneroDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<GeneroDto>(classe);
        }

        public GeneroDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<GeneroDto>(classe);
        }

        public IEnumerable<GeneroDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<GeneroDto>>(classe);
        }
    }
}
