using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Models
{
    public interface IProduct
    {
        string Name { get; }
        int Price { get; }
        int Count { get; set; }
    }
}
