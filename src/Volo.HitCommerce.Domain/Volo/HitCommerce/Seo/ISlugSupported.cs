namespace Volo.HitCommerce.Seo
{
    public interface ISlugSupported
    {
        string Name { get; set; }
        
        string Slug { get; set; }
    }
}