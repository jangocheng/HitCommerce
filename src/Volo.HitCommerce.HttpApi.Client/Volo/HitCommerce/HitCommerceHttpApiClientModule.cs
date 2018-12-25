using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class HitCommerceHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "HitCommerce";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HitCommerceApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
