using Acme.ProductApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Acme.ProductApp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ProductAppEntityFrameworkCoreModule),
        typeof(ProductAppApplicationContractsModule)
        )]
    public class ProductAppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
