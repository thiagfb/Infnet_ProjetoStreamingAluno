using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class PlayListMusicaProfile : AutoMapper.Profile
    {
        public PlayListMusicaProfile()
        {
            CreateMap<PlayListMusicaDto, PlayListMusica>().ReverseMap();
        }
    }
}
