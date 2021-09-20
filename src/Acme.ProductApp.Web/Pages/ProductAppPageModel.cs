using Acme.ProductApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.ProductApp.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ProductAppPageModel : AbpPageModel
    {
        protected ProductAppPageModel()
        {
            LocalizationResourceType = typeof(ProductAppResource);
        }
    }
}