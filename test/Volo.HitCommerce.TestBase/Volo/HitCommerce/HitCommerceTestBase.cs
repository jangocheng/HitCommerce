using Volo.Abp;
using Volo.Abp.Modularity;

namespace Volo.HitCommerce
{
    public abstract class HitCommerceTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> 
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
