using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        private readonly List<Product> products = new List<Product>();

        public BonusProvider Bonus { get; set; }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetValueOfProducts()
        {
            double total = 0;

            products.ForEach(o => total += o.Value);

            return total;
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }
    }
}
