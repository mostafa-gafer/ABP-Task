using Acme.ProductApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.ProductApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ProductAppController : AbpController
    {
        protected ProductAppController()
        {
            LocalizationResource = typeof(ProductAppResource);
        }
    }
}