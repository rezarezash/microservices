using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace   PlatformService.Profiles {
    public class PlatformsProfile : Profile {
        public PlatformsProfile()
        {
            // Source (Model) -> Target (Dto)
            CreateMap<Platform,PlatfromReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}