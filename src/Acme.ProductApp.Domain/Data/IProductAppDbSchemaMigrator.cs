using System.Threading.Tasks;

namespace Acme.ProductApp.Data
{
    public interface IProductAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
