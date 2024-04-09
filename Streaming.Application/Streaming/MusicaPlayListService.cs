using AutoMapper;
using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Repository.Repository;

namespace Streaming.Application.Streaming
{
    public class MusicaPlayListService
    {
        private MusicaPlayListRepository Repository { get; set; }

        private IMapper Mapper { get; set; }

        public MusicaPlayListService(IMapper mapper, MusicaPlayListRepository repository)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public MusicaPlayList Criar(MusicaPlayListDto dto)
        {
            MusicaPlayList musicaPlayList = new MusicaPlayList();
            musicaPlayList.UsuarioId = dto.UsuarioId;
            musicaPlayList.MusicaId = dto.MusicaId;

            this.Repository.InsertMusic(musicaPlayList);

            return musicaPlayList;
        }

        public MusicaPlayList Delete(Guid idUsuario, Guid idMusica)
        {
            MusicaPlayList musicaPlayList = new MusicaPlayList();
            musicaPlayList.UsuarioId = idUsuario;
            musicaPlayList.MusicaId = idMusica;

            this.Repository.DeleteMusic(musicaPlayList);

            return musicaPlayList;
        }
    }
}
