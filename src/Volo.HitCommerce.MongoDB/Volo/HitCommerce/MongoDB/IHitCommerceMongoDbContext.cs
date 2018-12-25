using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Volo.HitCommerce.Addresses;
using Volo.HitCommerce.BaseEntities;
using Volo.HitCommerce.Customers;
using Volo.HitCommerce.Directions;
using Volo.HitCommerce.Medias;
using Volo.HitCommerce.UserGroups;
using Volo.HitCommerce.Vendors;
using Volo.HitCommerce.Widgets;

namespace Volo.HitCommerce.MongoDB
{
    [ConnectionStringName("HitCommerce")]
    public interface IHitCommerceMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Address> Addresses { get; }
        
        IMongoCollection<BaseEntity> Entities { get; }
        
        IMongoCollection<BaseEntityType> EntityTypes { get; }
        
        IMongoCollection<Customer> Users { get; }
        
        IMongoCollection<CustomerAddress> UserAddresses { get; }
        
        IMongoCollection<CustomerUserGroup> CustomerUserGroups { get; }
        
        IMongoCollection<Country> Countries { get; }
        
        IMongoCollection<StateOrProvince> StateOrProvinces { get; }
        
        IMongoCollection<District> Districts { get; }
        
        IMongoCollection<UserGroup> UserGroups { get; }
        
        IMongoCollection<Media> Medias { get; }
        
        IMongoCollection<Vendor> Vendors { get; }
        
        IMongoCollection<Widget> Widgets { get; }
        
        IMongoCollection<WidgetInstance> WidgetInstances { get; }
    }
}
