using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public interface IBalance
    {
        /// <summary>
        /// Property for stroing walletbalance
        /// </summary>
        /// <value></value>
        public int WalletBalance { get; set; }

        /// <summary>
        /// Method for wallet Recharge
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        public int WalletRecharge(int cash);
    }
}