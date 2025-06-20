using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public Product() { }
        public Product(string title, decimal price)
        {
            Title = title;
            Price = price;
        }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}
