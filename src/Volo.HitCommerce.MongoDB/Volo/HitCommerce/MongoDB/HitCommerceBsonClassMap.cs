using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;
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
    public static class HitCommerceBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Customer>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Address>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<UrlRecord>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Country>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<StateOrProvince>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<District>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Media>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<UserGroup>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Vendor>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Widget>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<WidgetInstance>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<WidgetZone>(map =>
                {
                    map.AutoMap();
                });
            });
        }
    }
}