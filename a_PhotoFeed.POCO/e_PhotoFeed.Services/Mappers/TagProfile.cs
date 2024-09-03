using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>()
                .ForMember(dest => dest.IdTag, src => src.MapFrom(x => x.IdTag))
                .ForMember(dest => dest.TagName, src => src.MapFrom(x => x.TagName));

            CreateMap<TagDTO, Tag>()
                .ForMember(dest => dest.IdTag, src => src.MapFrom(x => x.IdTag))
                .ForMember(dest => dest.TagName, src => src.MapFrom(x => x.TagName))
                .ForMember(dest => dest.PhotoTags, src => src.Ignore());
        }
    }
}
