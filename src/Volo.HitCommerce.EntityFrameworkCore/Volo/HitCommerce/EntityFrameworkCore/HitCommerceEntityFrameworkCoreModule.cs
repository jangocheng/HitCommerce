using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.HitCommerce.Addresses;
using Volo.HitCommerce.BaseEntities;
using Volo.HitCommerce.Customers;
using Volo.HitCommerce.Directions;
using Volo.HitCommerce.Medias;
using Volo.HitCommerce.UserGroups;
using Volo.HitCommerce.Vendors;
using Volo.HitCommerce.Widgets;

namespace Volo.HitCommerce.EntityFrameworkCore
{
    [DependsOn(
        typeof(HitCommerceDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class HitCommerceEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HitCommerceDbContext>(options =>
            {
                options.AddRepository<Customer, EfCoreCustomerRepository>();
                options.AddRepository<CustomerAddress, EfCoreCustomerAddressRepository>();
                options.AddRepository<CustomerUserGroup, EfCoreCustomerUserGroupRepository>();
                options.AddRepository<Address, EfCoreAddressRepository>();
                options.AddRepository<BaseEntity, EfCoreCustomerRepository>();
                options.AddRepository<BaseEntityType, EfCoreBaseEntityTypeRepository>();
                options.AddRepository<Country, EfCoreCountryRepository>();
                options.AddRepository<StateOrProvince, EfCoreStateOrProvinceRepository>();
                options.AddRepository<District, EfCoreDistrictRepository>();
                options.AddRepository<Media, EfCoreMediaRepository>();
                options.AddRepository<UserGroup, EfCoreUserGroupRepository>();
                options.AddRepository<Vendor, EfCoreVendorRepository>();
                options.AddRepository<Widget, EfCoreWidgetRepository>();
                options.AddRepository<WidgetInstance, EfCoreWidgetInstanceRepository>();
            });
        }
    }
}