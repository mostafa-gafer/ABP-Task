using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.ProductApp.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
    }
}
