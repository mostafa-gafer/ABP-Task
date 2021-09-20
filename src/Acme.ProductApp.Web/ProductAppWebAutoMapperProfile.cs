using Acme.ProductApp.Products;
using AutoMapper;

namespace Acme.ProductApp.Web
{
    public class ProductAppWebAutoMapperProfile : Profile
    {
        public ProductAppWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<Pages.Products.CreateModalModel.CreateProductViewModel, CreateUpdateProductDto>();
            CreateMap<ProductDto, Pages.Products.EditModalModel.EditProductViewModel>();
            CreateMap<Pages.Products.EditModalModel.EditProductViewModel, CreateUpdateProductDto>();
            CreateMap<Pages.Products.IndexModel.FilterViewModel, FilterDto>();

        }
    }
}
