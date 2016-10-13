using System.Web;

namespace CoffeeMachine.Models
{
    public class Pouch
    {
        private List <IMoney> money;

        public int TotalSum
        {
            get
            {
                int result = 0;
                foreach (IMoney m in money)
                    result += m.Nominal * m.Count;

                return result;
            }
        }

        public Pouch(List<IMoney> newMoney)
        {
            money = newMoney;
        }

        
        public IEnumerable<IMoney> GetAllMoney()
        {
            return money;
        }

        public void TakeMoney(IMoney m)
        {
            if (money.Contains(m))
                money.Find(o => o.Nominal == m.Nominal).Count++;
            else
                money.Add(m);
        }

        public void TakeMoney(IEnumerable<IMoney> newMoney)
        {
            foreach (IMoney m in newMoney)
                TakeMoney(m);
        }

        public IMoney GiveMoney(IMoney m)
        {
            IMoney result = money.Find(o => o.Nominal == m.Nominal);
            if (result == null || result.Count == 0)
                throw new Exception("Монет этого номинала нет в кошельке");
            else
            {
                money.Find(o => o.Nominal == m.Nominal).Count--;
                return m;
            }
        }
        
    }
}
