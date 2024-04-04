using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class ArtistaService
    {
        private ArtistaRepository ArtistaRepository { get; set; }
        private IMapper Mapper { get; set; }

        public ArtistaService(ArtistaRepository artistaRepository, IMapper mapper)
        {
            ArtistaRepository = artistaRepository;
            Mapper = mapper;
        }

        public ArtistaDto Criar(ArtistaDto dto)
        {
            if (dto.Id != Guid.Empty)
            {
                dto.Id = Guid.NewGuid();
            }

            Artista artista = this.Mapper.Map<Artista>(dto);
            this.ArtistaRepository.Save(artista);

            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public ArtistaDto Atualizar(ArtistaDto dto)
        {
            Artista artista = this.Mapper.Map<Artista>(dto);
            this.ArtistaRepository.Update(artista);

            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public ArtistaDto Excluir(Guid id)
        {
            var artista = this.ArtistaRepository.GetById(id);
            this.ArtistaRepository.Delete(artista);

            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public ArtistaDto GetId(Guid id)
        {
            var artista = this.ArtistaRepository.GetById(id);
            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public IEnumerable<ArtistaDto> GetAll()
        {
            var banda = this.ArtistaRepository.GetAll();
            return this.Mapper.Map<IEnumerable<ArtistaDto>>(banda);
        }
    }
}
