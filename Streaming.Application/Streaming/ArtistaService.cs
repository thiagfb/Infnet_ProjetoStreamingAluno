using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class ArtistaService
    {
        private ArtistaRepository ArtistaRepository { get; set; }
        private AlbumRepository AlbumRepository { get; set; }

        private IMapper Mapper { get; set; }

        public ArtistaService(ArtistaRepository artistaRepository, AlbumRepository albumRepository, IMapper mapper)
        {
            ArtistaRepository = artistaRepository;
            AlbumRepository = albumRepository;
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

        //public AlbumDto AssociarAlbum(AlbumDto dto)
        //{
        //    var artista = this.ArtistaRepository.GetById(dto.ArtistaId);

        //    if (artista == null)
        //    {
        //        throw new Exception("Artista não encontrada");
        //    }

        //    var album = this.AlbumRepository.Find(x => x.Artista.Id == dto.ArtistaId && x.Id == dto.Id).First();


        //    //var novoAlbum = this.AlbumDtoParaAlbum(dto);

        //    //artista.AdicionarAlbum(album);

        //    //this.ArtistaRepository.Update(banda);

        //    var result = this.AlbumParaAlbumDto(album);

        //    return result;
        //}

        //private Album AlbumDtoParaAlbum(AlbumDto dto)
        //{
        //    Album album = new Album()
        //    {
        //        Titulo = dto.Titulo
        //    };

        //    foreach (FaixaDto item in dto.LstFaixa)
        //    {
        //        album.AdicionarAlbum(new Musica
        //        {
        //            Nome = item.Nome,
        //            Duracao = new SpotifyLike.Domain.Streaming.ValueObject.Duracao(item.Duracao)
        //        });
        //    }

        //    return album;
        //}

        //private AlbumDto AlbumParaAlbumDto(Album album)
        //{
        //    AlbumDto dto = new AlbumDto();
            
            
        //    dto.Id = album.Id;
        //    dto.Titulo = album.Titulo;

        //    foreach (var item in album.LstFaixa)
        //    {                
        //        var faixa = new Faixa()
        //        {
        //            Id = item.Id,
        //            Duracao = item.Duracao.Valor,
        //            Ordem = item.Ordem
        //        };

        //        dto.LstFaixa.Add(faixa);
        //    }

        //    return dto;
        //}
    }
}
