using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.ProductApp.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.ProductApp.EntityFrameworkCore
{
    public class EntityFrameworkCoreProductAppDbSchemaMigrator
        : IProductAppDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreProductAppDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ProductAppDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ProductAppDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
