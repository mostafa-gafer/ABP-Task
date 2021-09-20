using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.ProductApp.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
        public string Picture { get; set; }

        public Guid CategoryId { get; set; }   // to make obect 1/N
    }
}
