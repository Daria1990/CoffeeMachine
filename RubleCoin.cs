using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace CoffeeMachine.Models
{
    public class RubleCoin : IMoney
    {
        public static readonly List<int> admissibleNominals = new List<int> { 1, 2, 5, 10 };

        public int Nominal
        {
            get;
            private set;
        }

        public int Count { get; set; }
   
        public RubleCoin(int nominal, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", "count должен быть больше или равен нуля");

            if (admissibleNominals.Contains(nominal))
                this.Nominal = nominal;
            else
            {
                StringBuilder message = new StringBuilder();
                foreach (double vv in admissibleNominals)
                {
                    message.Append(vv);
                    message.Append(' ');
                }

                throw new ArgumentOutOfRangeException("coin",
                    "Для рубля допустимы только следующие значения " + message);
            }
        }
    }
}
