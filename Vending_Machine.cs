using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Models
{
    public class Vending_Machine
    {
        public Pouch Pouch
        {
            get;
            private set;
        }

        public double AmountDeposited
        {
            get;
            private set;
        }

        private Dictionary<string, IProduct> products;

        public Vending_Machine(Pouch pouch, List<IProduct> products)
        {
            this.Pouch = pouch;
            this.products = products.ToDictionary(p => p.Name);
        }

        public IEnumerable<IProduct> GetProducts()
        {
            return products.Values;
        }

        public void TakeMoney(IMoney m)
        {
            Pouch.TakeMoney(m);
            AmountDeposited += m.Nominal;
        }

        public IProduct GiveProduct(string productName)
        {
            IProduct product = products[productName];
            if (product.Count <= 0)
                throw new Exception("Товара нет в наличии");

            if (product.Price > AmountDeposited)
                throw new Exception("Недостаточно средств");

            AmountDeposited -= product.Price;
            product.Count--;
            return product;
        }

        public void GiveChange()
        {
            if (AmountDeposited > 0)
            {
                Pouch.GiveMoney(AmountDeposited);
                AmountDeposited = 0;
            }
            else
                throw new Exception("Сдача Вам не полагается");
        }
  
    }
}
