using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;
using System.Numerics;

namespace Streaming.Application.Streaming
{
    public class MusicaService
    {
        private MusicaRepository Repository { get; set; }
        private CompositorRepository CompositorRepository { get; set; }
        private GeneroRepository GeneroRepository { get; set; }
        private IMapper Mapper { get; set; }

        public MusicaService(MusicaRepository repository, IMapper mapper, CompositorRepository compositorRepository, GeneroRepository generoRepository)
        {
            Repository = repository;
            Mapper = mapper;
            CompositorRepository = compositorRepository;
            GeneroRepository = generoRepository;
        }

        public MusicaDto Criar(MusicaDto dto)
        {
            dto.Id = Guid.NewGuid();

            Compositor compositor = this.CompositorRepository.GetById(dto.Compositorid);
            Genero genero = this.GeneroRepository.GetById(dto.GeneroId);

            if (compositor == null)
                throw new Exception("Compositor não existente ou não encontrado");

            if (genero == null)
                throw new Exception("Gênero não existente ou não encontrado");

            Musica musica = new Musica();
            musica.AdicionarMusica(dto.Titulo, genero, compositor, dto.Letra, dto.DataComposicao);

            this.Repository.Save(musica);

            return this.Mapper.Map<MusicaDto>(musica);
        }

        public MusicaDto Atualizar(MusicaDto dto)
        {
            Musica classe = this.Mapper.Map<Musica>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<MusicaDto>(classe);
        }

        public MusicaDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<MusicaDto>(classe);
        }

        public Musica GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);

            if (classe == null)
            {
                throw new Exception("Música não encontrada");
            }

            return classe;
        }

        public IEnumerable<MusicaDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<MusicaDto>>(classe);
        }
    }
}
