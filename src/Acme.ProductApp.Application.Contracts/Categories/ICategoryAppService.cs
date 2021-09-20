using Acme.ProductApp.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace Acme.ProductApp.Categories
{
    public interface ICategoryAppService :
        ICrudAppService< //Defines CRUD methods
            CategoryDto, //Used to show Categorys
            Guid, //Primary key of the product entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCategoryDto> //Used to create/update a product
    {
    }
}
