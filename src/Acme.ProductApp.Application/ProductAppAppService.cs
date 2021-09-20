using System;
using System.Collections.Generic;
using System.Text;
using Acme.ProductApp.Localization;
using Volo.Abp.Application.Services;

namespace Acme.ProductApp
{
    /* Inherit your application services from this class.
     */
    public abstract class ProductAppAppService : ApplicationService
    {
        protected ProductAppAppService()
        {
            LocalizationResource = typeof(ProductAppResource);
        }
    }
}
