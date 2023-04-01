using AutoMapper;
using Newtonsoft.Json;
using OpenParticipationPlatform.Api.Dbo;
using OpenParticipationPlatform.Api.InputModel;
using OpenParticipationPlatform.Api.OutputModel;
using System.Security.Principal;

namespace OpenParticipationPlatform.Api.Mappings
{
    public class BasicProfiles : Profile
    {
        public BasicProfiles()
        {
            CreateMap<CategoryDbo, CategoryViewModel>();

            CreateMap<List<MapObjectDbo>, GeoJsonModel.Root>();

            CreateMap<MapObjectDbo, GeoJsonModel.Properties>()
                .ForMember(dst => dst.description, src => src.MapFrom(opt => opt.Description))
                .ForMember(dst => dst.name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dst => dst.urls, src => src.MapFrom(opt => opt.Urls))
                ;

            CreateMap<UrlDbo, GeoJsonModel.Url>()
                .ForMember(dst => dst.name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dst => dst.url, src => src.MapFrom(opt => opt.Url))
                ;

           

            CreateMap<FaqDbo, FaqViewModel>();

            CreateMap<UrlDbo, UrlViewModel>();

            CreateMap<MapObjectInputModel, MapObjectDbo>();

        }
    }
}
