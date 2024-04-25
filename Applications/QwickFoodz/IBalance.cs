using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public interface IBalance
    {
        public int WalletBalance { get;  }
        public int WalletRecharge(int cash);
        public int DeductBalance(int cash);

    }
}