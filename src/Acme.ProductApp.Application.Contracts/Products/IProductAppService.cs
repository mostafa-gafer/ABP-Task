using Acme.ProductApp.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace Acme.ProductApp.Products
{
    public interface IProductAppService :
        ICrudAppService< //Defines CRUD methods
            ProductDto, //Used to show products
            Guid, //Primary key of the product entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateProductDto> //Used to create/update a product
    {
        Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync(); //define fun to get all category
        Task<List<ProductDto>> GetToListAsync();  //define fun to get all product
        Task<List<ProductDto>> GetListByCategoryAsync(Guid id); //define fun to get products by category
    }
}
