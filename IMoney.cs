using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Models
{
    public interface IMoney
    {
        int Nominal { get; }
        //создан на случай, если  еще появятся бумажные деньги
        //возможно некоторые деньги автомат принимать не будет, например 10 рублей бумажными деньгами
        int Count { get; set; }
    }
}
