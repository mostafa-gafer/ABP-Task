using Acme.ProductApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.ProductApp.Permissions
{
    public class ProductAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //permission group (to group permissions on the UI, will be seen below)
            //and 4 permissions inside this group
            var productAppGroup = context.AddGroup(ProductAppPermissions.GroupName, L("Permission:ProductApp"));

            var productsPermission = productAppGroup.AddPermission(ProductAppPermissions.Products.Default, L("Permission:Products"));
            productsPermission.AddChild(ProductAppPermissions.Products.Create, L("Permission:Products.Create"));
            productsPermission.AddChild(ProductAppPermissions.Products.Edit, L("Permission:Products.Edit"));
            productsPermission.AddChild(ProductAppPermissions.Products.Delete, L("Permission:Products.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductAppResource>(name);
        }
    }
}
