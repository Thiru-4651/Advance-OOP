using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public interface IBalance
    {
        public int Balance { get; }

        public int WalletRecharge(int cash);
        public int DeductBalance(int cash);

    }
}