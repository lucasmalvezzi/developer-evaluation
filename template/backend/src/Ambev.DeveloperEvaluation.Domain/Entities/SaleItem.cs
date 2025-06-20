using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity<int>
    {
        public Product? Product { get; set; }
        public Guid ProductId { get; set; } = Guid.Empty;

        public Sale? Sale { get; set; }
        public int SaleId { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount => CalculateDiscountPercentage() * UnitPrice * Quantity;
        public decimal Total => (Quantity * UnitPrice) - Discount ;

        protected SaleItem() { }

        public SaleItem(Product product, int quantity, decimal unitPrice, decimal discountPercentage)
        {
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
        private decimal CalculateDiscountPercentage()
        {
            if (Quantity >= 4 && Quantity < 10)
            {
                return 0.1m;
            } else if (Quantity >= 10 && Quantity <= 20)
            {
                return 0.2m;
            }
            return 0;
        }

    }
}
