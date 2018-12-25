using Volo.HitCommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceEntityFrameworkCoreTestModule)
        )]
    public class HitCommerceDomainTestModule : AbpModule
    {
        
    }
}
