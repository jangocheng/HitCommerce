using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.HitCommerce.Addresses;
using Volo.HitCommerce.Customers;
using Volo.HitCommerce.Directions;
using Volo.HitCommerce.Medias;
using Volo.HitCommerce.Seo;
using Volo.HitCommerce.UserGroups;
using Volo.HitCommerce.Vendors;
using Volo.HitCommerce.Widgets;

namespace Volo.HitCommerce.MongoDB
{
    [DependsOn(
        typeof(HitCommerceDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class HitCommerceMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            HitCommerceBsonClassMap.Configure();

            context.Services.AddMongoDbContext<HitCommerceMongoDbContext>(options =>
            {
                options.AddRepository<Customer, MongoCustomerRepository>();
                options.AddRepository<CustomerAddress, MongoCustomerAddressRepository>();
                options.AddRepository<CustomerUserGroup, MongoCustomerUserGroupRepository>();
                options.AddRepository<Address, MongoAddressRepository>();
                options.AddRepository<UrlRecord, MongoUrlRecordRepository>();
                options.AddRepository<Country, MongoCountryRepository>();
                options.AddRepository<StateOrProvince, MongoStateOrProvinceRepository>();
                options.AddRepository<District, MongoDistrictRepository>();
                options.AddRepository<Media, MongoMediaRepository>();
                options.AddRepository<UserGroup, MongoUserGroupRepository>();
                options.AddRepository<Vendor, MongoVendorRepository>();
                options.AddRepository<Widget, MongoWidgetRepository>();
                options.AddRepository<WidgetInstance, MongoWidgetInstanceRepository>();
            });
        }
    }
}
