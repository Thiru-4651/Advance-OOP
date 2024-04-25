using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public interface IWallet
    {
        /// <summary>
        /// Property for wallet Balance
        /// </summary>
        /// <value></value>
        public int WalletBalance { get;  }

        /// <summary>
        /// Method For Wallet Recharge
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        public int WalletRecharge(int cash);

        /// <summary>
        /// Method for Deduct balance
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        public int DeductBalance(int cash);
    }
}