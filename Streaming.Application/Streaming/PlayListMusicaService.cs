using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class PlayListMusicaService
    {
        private PlayListMusicaRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public PlayListMusicaService(PlayListMusicaRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public PlayListMusicaDto Criar(PlayListMusicaDto dto)
        {
            dto.Id = Guid.NewGuid();

            PlayListMusica classe = this.Mapper.Map<PlayListMusica>(dto);
            this.Repository.Save(classe);

            return this.Mapper.Map<PlayListMusicaDto>(classe);
        }

        public PlayListMusicaDto Atualizar(PlayListMusicaDto dto)
        {
            PlayListMusica classe = this.Mapper.Map<PlayListMusica>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<PlayListMusicaDto>(classe);
        }

        public PlayListMusicaDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<PlayListMusicaDto>(classe);
        }

        public PlayListMusicaDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<PlayListMusicaDto>(classe);
        }

        public IEnumerable<PlayListMusicaDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<PlayListMusicaDto>>(classe);
        }
    }
}
