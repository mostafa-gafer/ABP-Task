using Acme.ProductApp.Categories;
using Acme.ProductApp.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
namespace Acme.ProductApp.Products
{
    public class ProductAppService:
        CrudAppService<
            Product, //The product entity
            ProductDto, //Used to show books
            Guid, //Primary key of the product entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateProductDto>, //Used to create/update a product
        IProductAppService //implement the IproductAppService
    {
        private readonly IRepository<Category, Guid> _categories;

        public ProductAppService(IRepository<Product, Guid> repository,
                                 IRepository<Category, Guid> categories)
            : base(repository)
        {
            //Added code to the constructor. Base CrudAppService automatically
            //uses these permissions on the CRUD operations
            
            _categories = categories;
            GetPolicyName = ProductAppPermissions.Products.Default;
            GetListPolicyName = ProductAppPermissions.Products.Default;
            CreatePolicyName = ProductAppPermissions.Products.Create;
            UpdatePolicyName = ProductAppPermissions.Products.Edit;
            DeletePolicyName = ProductAppPermissions.Products.Delete;
        }

        public override async Task<ProductDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from product in queryable
                        join category in _categories on product.CategoryId equals category.Id
                        where product.Id == id
                        select new { product, category };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Product), id);
            }

            var ProductDto = ObjectMapper.Map<Product, ProductDto>(queryResult.product);
            ProductDto.CategoryTitle = queryResult.category.Title;
            return ProductDto;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from product in queryable
                        join category in _categories on product.CategoryId equals category.Id
                        select new { product, category };
            
            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of ProductDto objects
            var ProductDtos = queryResult.Select(x =>
            {
                var ProductDto = ObjectMapper.Map<Product, ProductDto>(x.product);
                ProductDto.CategoryTitle = x.category.Title;
                return ProductDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ProductDto>(
                totalCount,
                ProductDtos
            );
        }

        public async Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync()
        {
            var Categorys = await _categories.GetListAsync();

            return new ListResultDto<CategoryLookupDto>(
                ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(Categorys)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"product.{nameof(Product.Title)}";
            }

            if (sorting.Contains("CategoryTitle", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "CategoryTitle",
                    "category.Title",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"product.{sorting}";
        }

      //go get all product
        public async Task<List<ProductDto>> GetToListAsync()
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from product in queryable
                        join category in _categories on product.CategoryId equals category.Id
                        select new { product, category };

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of ProductDto objects
            var ProductDtos = queryResult.Select(x =>
            {
                var ProductDto = ObjectMapper.Map<Product, ProductDto>(x.product);
                ProductDto.CategoryTitle = x.category.Title;
                return ProductDto;
            }).ToList();



            return ProductDtos;
        }
        //to get products by category
        public async Task<List<ProductDto>> GetListByCategoryAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();
            var Result = queryable.Where(c => c.CategoryId == id);
            //Prepare a query to join books and authors
            var query = from product in Result
                        join category in _categories on product.CategoryId equals category.Id
                        select new { product, category };

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of ProductDto objects
            var ProductDtos = queryResult.Select(x =>
            {
                var ProductDto = ObjectMapper.Map<Product, ProductDto>(x.product);
                ProductDto.CategoryTitle = x.category.Title;
                return ProductDto;
            }).ToList();

         return ProductDtos;
        }
    }
}

