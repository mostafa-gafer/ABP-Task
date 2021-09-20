using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Acme.ProductApp.Helper;
using Acme.ProductApp.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.ProductApp.Web.Pages.Products
{
    public class EditModalModel : ProductAppPageModel
    {
        private readonly IProductAppService _productAppService;

        [BindProperty]   //to make bind between wiew and action
        public EditProductViewModel Product { get; set; } //define product object
        public List<SelectListItem> Categories { get; set; } //define category list object

        public EditModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task OnGetAsync(Guid id)
        {
            //get product by id to edit
            var productDto = await _productAppService.GetAsync(id);
            //make mappine to convert from prductdto to editviewmodel
            Product = ObjectMapper.Map<ProductDto, EditProductViewModel>(productDto);
            //get list of category
            var authorLookup = await _productAppService.GetCategoryLookupAsync();
            Categories = authorLookup.Items
                .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Product.PictureUrl != null)
            {
                //to delete old photo from folder
                UploadFileHelper.RemoveFile("Photos/", Product.Picture);
                //use helper to call function to save new photo
                Product.Picture = UploadFileHelper.SaveFile(Product.PictureUrl, "Photos");
            }
            //update funtion with id and model paramter
            await _productAppService.UpdateAsync(
                Product.Id,
                ObjectMapper.Map<EditProductViewModel, CreateUpdateProductDto>(Product)
            );
            //call index page
            return RedirectToPage("Index");
        }
        public class EditProductViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

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
            public IFormFile PictureUrl { get; set; }
        }
    }
}
