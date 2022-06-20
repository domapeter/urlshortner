using AutoMapper;
using DTO;
using Entities;

namespace WebApp.Mappers
{
    public class ShortLinkMappingProfile : Profile
    {
        public ShortLinkMappingProfile()
        {
            CreateMap<ShortLinkCreateRequest, LinkPair>()
                .ForMember(d => d.Link, opt => opt.MapFrom(s => s.Url));

            CreateMap<LinkPair, ShortLinkResponse>()
                .ForMember(d => d.Url, opt => opt.MapFrom(s => s.Link))
                .ForMember(d => d.ShortUrl, opt => opt.MapFrom(s => s.ShortLink));
        }
    }
}