using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class AlbumService
    {
        private AlbumRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public AlbumService(AlbumRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public AlbumDto Criar(AlbumDto dto)
        {
            dto.Id = Guid.NewGuid();

            Album classe = this.Mapper.Map<Album>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<AlbumDto>(classe);
        }

        public AlbumDto Atualizar(AlbumDto dto)
        {
            Album classe = this.Mapper.Map<Album>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<AlbumDto>(classe);
        }

        public AlbumDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<AlbumDto>(classe);
        }

        public AlbumDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<AlbumDto>(classe);
        }

        public IEnumerable<AlbumDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<AlbumDto>>(classe);
        }
    }
}
