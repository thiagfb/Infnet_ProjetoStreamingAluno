using Streaming.Application.Streaming.Dto;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Profile
{
    public class CompositorProfile : AutoMapper.Profile
    {
        public CompositorProfile()
        {
            CreateMap<CompositorDto, Compositor>().ReverseMap();
        }
    }
}