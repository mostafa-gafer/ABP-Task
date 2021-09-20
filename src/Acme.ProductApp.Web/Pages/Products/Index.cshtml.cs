using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.ProductApp.Categories;
using Acme.ProductApp.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.ProductApp.Web.Pages.Products
{
    public class IndexModel : ProductAppPageModel
    {

        private readonly ICategoryAppService _categoryAppService;
        private readonly IProductAppService _productAppService;

        [BindProperty(SupportsGet = true)] //bind
        public FilterViewModel filterProducts { get; set; }  //define product object
        [BindProperty]   //bind property from viem and model
        public List<ProductDto> productlist { get; set; }
        public List<SelectListItem> Categories { get; set; } //define category list object
        public IndexModel(ICategoryAppService categoryAppService,
                          IProductAppService productAppService)
        {
            //define interface app service to act with function
            _categoryAppService = categoryAppService;  
            _productAppService = productAppService;
        }
        public async Task OnGetAsync(Guid id)
        {
            //define instance from FilterViewModel
            filterProducts = new FilterViewModel();
            //define Guid variable to compare it with input id 
            //if true that select all from list if false that getlist by category
            Guid initalGuid = new Guid("{00000000-0000-0000-0000-000000000000}");
            if (initalGuid.Equals(id))
            {
                //get all product
                filterProducts.productDtos = await _productAppService.GetToListAsync();
                filterProducts.CategoryId = id;  //put categoryid to select category title from select


            }
            else
            {  //get list of product by each category
                filterProducts.productDtos =  await _productAppService.GetListByCategoryAsync(id);
                filterProducts.CategoryId = id;   //put categoryid to select category title from select
               
            }
            //to get select list from category
            var authorLookup = await _productAppService.GetCategoryLookupAsync();
            Categories = authorLookup.Items
                .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();





        }
       
        public class FilterViewModel
        {
            [SelectItems(nameof(Categories))]
            [DisplayName("Category")]
            public Guid CategoryId { get; set; }

            public List<ProductDto> productDtos { get; set; }


        }
    }
}
