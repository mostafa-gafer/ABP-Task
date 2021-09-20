using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
namespace Acme.ProductApp.Categories
{
    public class CategoryAppService :
        CrudAppService<
            Category, //The product entity
            CategoryDto, //Used to show books
            Guid, //Primary key of the product entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCategoryDto>, //Used to create/update a product
        ICategoryAppService //implement the IproductAppService
    {
        private readonly IRepository<Category, Guid> _repository;

        public CategoryAppService(IRepository<Category, Guid> repository)
            : base(repository)
        {
           _repository = repository;
        }

        
    }
}

