using Acme.ProductApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.ProductApp
{
    [DependsOn(
        typeof(ProductAppEntityFrameworkCoreTestModule)
        )]
    public class ProductAppDomainTestModule : AbpModule
    {

    }
}