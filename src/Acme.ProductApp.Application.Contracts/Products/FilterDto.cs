using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ProductApp.Products
{
    public class FilterDto
    {
        public Guid CategoryId { get; set; }   // to make obect 1/N
        public List<ProductDto> productDtos { get; set; }
    }
}
