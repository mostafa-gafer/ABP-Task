using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Acme.ProductApp.Web
{
    [Dependency(ReplaceServices = true)]
    public class ProductAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ProductApp";
    }
}
