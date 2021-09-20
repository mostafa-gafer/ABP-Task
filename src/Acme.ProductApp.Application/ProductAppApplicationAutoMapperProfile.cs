using Acme.ProductApp.Categories;
using Acme.ProductApp.Products;
using AutoMapper;

namespace Acme.ProductApp
{
    public class ProductAppApplicationAutoMapperProfile : Profile
    {
        public ProductAppApplicationAutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryLookupDto>();
            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<ProductDto, CreateUpdateProductDto>();
             /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}
