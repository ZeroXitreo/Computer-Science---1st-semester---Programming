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
            return _products.Sum(o => o.Value);
        }

        //public double GetValueOfProducts(DateTime date)
        //{
        //    return _products.Where(o => DateTime.Compare(date, o.AvailableFrom) >= 0 && DateTime.Compare(date, o.AvailableTo) <= 0).Sum(o => o.Value);
        //}

        public double GetValueOfProducts(DateTime date)
        {
            return _products.Sum(o =>
            {
                if (DateTime.Compare(date, o.AvailableFrom) >= 0 && DateTime.Compare(date, o.AvailableTo) <= 0)
                {
                    return o.Value;
                }
                return 0;
            });
        }

        public List<Product> SortProductOrderByAvailableTo()
        {
            return _products.OrderBy(o => o.AvailableTo).ToList();
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

        public double GetBonus(DateTime date, Func<double, double> bonusProvider)
        {
            return bonusProvider(GetValueOfProducts(date));
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }

        public double GetTotalPrice(Func<double, double> bonusProvider)
        {
            return GetValueOfProducts() - GetBonus(bonusProvider);
        }

        public double GetTotalPrice(DateTime date, Func<double, double> bonusProvider)
        {
            return GetValueOfProducts(date) - GetBonus(date, bonusProvider);
        }
    }
}
