using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.ProductApp.Products
{
    public class CategoryLookupDto : EntityDto<Guid>
    {
        public string Title { get; set; }
    }
}
