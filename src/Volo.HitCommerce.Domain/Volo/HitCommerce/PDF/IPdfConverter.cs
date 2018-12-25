using Volo.Abp.DependencyInjection;

namespace Volo.HitCommerce.PDF
{
    public interface IPdfConverter : ITransientDependency
    {
        byte[] Convert(string htmlContent);
    }
}