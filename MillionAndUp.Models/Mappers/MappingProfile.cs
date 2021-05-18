using AutoMapper;
using MillionAndUp.Models.Models.Entity;
using MillionAndUp.Models.Models.ValueObject;

namespace MillionAndUp.Models.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDetail>();
            CreateMap<OwnerDetail, Owner>();
            CreateMap<PropertyDetail, Property>();
            CreateMap<Property, PropertyDetail>();
            CreateMap<PropertyImage, PropertyImageDetail>();
            CreateMap<PropertyImageDetail, PropertyImage>();
            CreateMap<PropertyTrace, PropertyTraceDetail>();
            CreateMap<PropertyTraceDetail, PropertyTrace>();
        }
    }
}
