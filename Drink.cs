using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace CoffeeMachine.Models
{
    public class Drink : IProduct
    {
        public static readonly Dictionary<string, int> admissibleDrinks = new Dictionary<string, int>
        {
            { "Cofeee", 18 }, { "Coffee with milk", 21}, { "Juice", 35}, { "Tea", 13}
        };

        public string Name
        {
            get;
            private set;
        }

        public int Price
        {
            get;
            private set;
        }

        public int Count
        {
            get;
            set;
        }

        public Drink(string drinkName, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", "count должен быть больше или равен нуля");

            if (admissibleDrinks.Keys.Contains(drinkName))
            {
                this.Name = drinkName;
                this.Price = admissibleDrinks[drinkName];
                this.Count = count;
            }
            else
            {
                StringBuilder message = new StringBuilder();
                foreach (string vv in admissibleDrinks.Keys)
                {
                    message.Append(vv);
                    message.Append(' ');
                }

                throw new ArgumentOutOfRangeException("drinkName",
                    "Для напитков допустимы только следующие названия " + message);
            }
        }
    }
}
