using Volo.Abp.Modularity;

namespace Acme.ProductApp
{
    [DependsOn(
        typeof(ProductAppApplicationModule),
        typeof(ProductAppDomainTestModule)
        )]
    public class ProductAppApplicationTestModule : AbpModule
    {

    }
}