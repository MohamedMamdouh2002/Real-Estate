using AutoMapper;
using MyProject.Dtos;
using MyProject.Dtos.Amenities;
using MyProject.Models.realstates;
using MyProject.Models.RealStates;
using MyProject1.Dtos;
using MyProject1.Dtos.Amenities;
using MyProject1.Dtos.CompoundDtos;
using MyProject1.Dtos.DeveloperDto;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Models.RealStates;

namespace MyProject.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RealEState, SellByAdminDto>().ReverseMap();
            CreateMap<RealEState, RealEStateReturnDto>().ReverseMap();
            CreateMap<IQueryable<RealEState>, IQueryable<RealEStateReturnDto>>().ReverseMap();
            //CreateMap<RealEState, RealEStateDto>();
            CreateMap<Compound, CompoundReturnDto>().ForMember(p => p.MasterPlanURL, opt => opt.Ignore());
            CreateMap<Compound, CompoundDto>().ReverseMap();
            CreateMap<Amenities, AmenitiesDto>().ReverseMap()
                .ForMember(p => p.ImgURL, opt => opt.Ignore());

            CreateMap<CompoundAmenities, IEnumerable<CompoundAmenitiesDto>>()
                 .ReverseMap().ForMember(i => i.CompoundId, opt => opt.Ignore()); ;
            CreateMap<Amenities, AmenitiesReturnDto>().ReverseMap();
            CreateMap<Compound, IEnumerable<CompoundReturnDto>>();
            CreateMap<Compound, CompoundReturnDto>();
            CreateMap<CompoundDto, Compound>()
                .ForMember(i => i.MasterPlanURL, opt => opt.Ignore());
            //Developer
            CreateMap<Developer, IEnumerable<DeveloperDto>>().ReverseMap();
            CreateMap<Developer, IEnumerable<DeveloperReturnDto>>().ReverseMap();


            CreateMap<Developer, DeveloperDto>().ReverseMap()
                                .ForMember(i => i.LogoURL, opt => opt.Ignore());
            CreateMap<Developer, DeveloperReturnDto>().ReverseMap()
                                .ForMember(i => i.LogoURL, opt => opt.Ignore());
            CreateMap<IEnumerable<CompoundAmenities>, IEnumerable<AmenitiesReturnDto>>().ReverseMap();



        }
    }
}
