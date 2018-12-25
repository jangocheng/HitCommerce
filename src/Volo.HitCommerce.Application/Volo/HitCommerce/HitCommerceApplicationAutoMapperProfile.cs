using AutoMapper;
using Volo.HitCommerce.Addresses;
using Volo.HitCommerce.BaseEntities;
using Volo.HitCommerce.BaseEntities.Dtos;
using Volo.HitCommerce.Customers;
using Volo.HitCommerce.Customers.Dtos;
using Volo.HitCommerce.Directions;
using Volo.HitCommerce.Directions.Dtos;
using Volo.HitCommerce.Vendors;
using Volo.HitCommerce.Vendors.Dtos;
using Volo.HitCommerce.Widgets;
using Volo.HitCommerce.Widgets.Dtos;

namespace Volo.HitCommerce
{
    public class HitCommerceApplicationAutoMapperProfile : Profile
    {
        public HitCommerceApplicationAutoMapperProfile()
        {
            CreateMap<BaseEntity, BaseEntityDto>();
            CreateMap<BaseEntityType, BaseEntityTypeDto>();

            CreateMap<Address, CustomerAddressDto>();
            
            CreateMap<Country, CountryDto>();
            CreateMap<StateOrProvince, StateOrProvinceDto>();
            CreateMap<District, DistrictDto>();
            
            CreateMap<Vendor, VendorDto>();
            
            CreateMap<Widget, WidgetDto>();
            CreateMap<WidgetInstance, WidgetInstanceDto>();
            CreateMap<WidgetZone, WidgetZoneDto>();
        }
    }
}