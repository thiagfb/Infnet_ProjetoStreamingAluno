using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Application.Streaming.VO;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class AlbumService
    {
        private AlbumRepository Repository { get; set; }
        private MusicaRepository MusicaRepository { get; set; }

        private IMapper Mapper { get; set; }

        public AlbumService(AlbumRepository repository, IMapper mapper, MusicaRepository musicaRepository)
        {
            Repository = repository;
            Mapper = mapper;
            MusicaRepository = musicaRepository;
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

        public IEnumerable<AlbumMusicaVO> GetAllArtista(Guid Id)
        {
            var classe = this.Repository.Find(x => x.Artista.Id == Id).ToList();

            var lstAlbum = new List<AlbumMusicaVO>();

            foreach (var c in classe)
            {
                var album = new AlbumMusicaVO();
                album.Id = c.Id;
                album.Titulo = c.Titulo;
                album.AnoLancamento = c.AnoLancamento;

                foreach (var faixa in c.LstFaixa)
                {
                    var musica = new Musica();

                    musica.Id = faixa.Musica.Id;
                    musica.Titulo = faixa.Musica.Titulo;

                    album.Musica.Add(musica);
                }

                lstAlbum.Add(album);
            }      

            return lstAlbum;
        }
    }
}
