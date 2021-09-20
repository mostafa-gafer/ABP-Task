using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace Acme.ProductApp.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
        public Guid CategoryId { get; set; }  //to make object from category
        public string CategoryTitle { get; set; }
    }
}
