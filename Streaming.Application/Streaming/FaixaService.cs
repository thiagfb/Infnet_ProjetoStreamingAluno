using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class FaixaService
    {
        private FaixaRepository Repository { get; set; }
        private MusicaRepository MusicaRepository { get; set; }
        private IMapper Mapper { get; set; }

        public FaixaService(FaixaRepository repository, IMapper mapper, MusicaRepository musicaRepository)
        {
            Repository = repository;
            Mapper = mapper;
            MusicaRepository = musicaRepository;
        }

        public FaixaDto Criar(FaixaDto dto)
        {
            dto.Id = Guid.NewGuid();

            Musica musica = this.MusicaRepository.GetById(dto.MusicaId);

            if (musica == null)
                throw new Exception("Música não existente ou não encontrada");

            Faixa faixa = new Faixa();
            faixa.AdicionarFaixa(musica, dto.Ordem, dto.Duracao);

            this.Repository.Save(faixa);

            return this.Mapper.Map<FaixaDto>(faixa);
        }

        public FaixaDto Atualizar(FaixaDto dto)
        {
            Faixa classe = this.Mapper.Map<Faixa>(dto);
            this.Repository.Update(classe);

            return this.Mapper.Map<FaixaDto>(classe);
        }

        public FaixaDto Excluir(Guid id)
        {
            var classe = this.Repository.GetById(id);
            this.Repository.Delete(classe);

            return this.Mapper.Map<FaixaDto>(classe);
        }

        public FaixaDto GetId(Guid id)
        {
            var classe = this.Repository.GetById(id);
            return this.Mapper.Map<FaixaDto>(classe);
        }

        public IEnumerable<FaixaDto> GetAll()
        {
            var classe = this.Repository.GetAll();
            return this.Mapper.Map<IEnumerable<FaixaDto>>(classe);
        }
    }
}
