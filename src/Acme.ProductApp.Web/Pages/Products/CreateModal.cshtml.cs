using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.ProductApp.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.IO;
using Acme.ProductApp.Helper;

namespace Acme.ProductApp.Web.Pages.Products
{
    public class CreateModalModel : ProductAppPageModel  //user it instead of PageModel
    {                                             //give user useful method such no content
        [BindProperty]    //make model binding to product from body
        public CreateProductViewModel Product { get; set; }

        public List<SelectListItem> Categories { get; set; }  //define list category object

        private readonly IProductAppService _productAppService;

        public CreateModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task OnGetAsync()
        {
            //make instance
            Product = new CreateProductViewModel();
            //get list of category
            var authorLookup = await _productAppService.GetCategoryLookupAsync();
            Categories = authorLookup.Items
                .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //use helper to call function to save photo
            Product.Picture = UploadFileHelper.SaveFile(Product.PictureUrl, "Photos");
            //call create function
            await _productAppService.CreateAsync(
                ObjectMapper.Map<CreateProductViewModel, CreateUpdateProductDto>(Product)
                );
            //call index page
            return RedirectToPage("Index");
        }
        public class CreateProductViewModel
        {
            [SelectItems(nameof(Categories))]
            [DisplayName("Category")]
            public Guid CategoryId { get; set; }

            [Required]
            [StringLength(128)]
            public string Title { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public float Price { get; set; }
            
            public string Picture { get; set; }
            [Required]
            public IFormFile PictureUrl { get; set; }
        }
    }
}
