using System.Threading.Tasks;
using Acme.ProductApp.Localization;
using Acme.ProductApp.MultiTenancy;
using Acme.ProductApp.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.ProductApp.Web.Menus
{
    public class ProductAppMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<ProductAppResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    ProductAppMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );
            
            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
            var productAppMenu = new ApplicationMenuItem(
                    "ProductApp",
                    l["ProductManagment"],
                    icon: "fa fa-book"
                );
            context.Menu.AddItem(productAppMenu);
            //CHECK the PERMISSION
            if (await context.IsGrantedAsync(ProductAppPermissions.Products.Default))
            {
                productAppMenu.AddItem(
                 new ApplicationMenuItem(
                     "ProductApp.Products",
                     l["Products"],
                     url: "/Products"
                 ));

             }       
            
        }
    }
}
