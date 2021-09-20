using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.ProductApp.Categories
{
    public class CategoryDto : EntityDto<Guid>
    {
        public string Title { get; set; }
    }
}
