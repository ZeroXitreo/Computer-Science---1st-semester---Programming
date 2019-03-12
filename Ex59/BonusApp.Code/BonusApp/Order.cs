using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        private List<Product> _products = new List<Product>();

        public BonusProvider Bonus { get; set; }

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }

        public double GetValueOfProducts()
        {
            double valueOfProducts = 0.0;

            foreach (Product p in _products)
            {
                valueOfProducts += p.Value;
            }

            return valueOfProducts;
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        //public double GetBonus(BonusProvider bonusProvider)
        //{
        //    return bonusProvider(GetValueOfProducts());
        //}

        public double GetBonus(Func<double, double> bonusProvider)
        {
            return bonusProvider(GetValueOfProducts());
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }

        public double GetTotalPrice(Func<double, double> bonusProvider)
        {
            return GetValueOfProducts() - GetBonus(bonusProvider);
        }
    }
}
