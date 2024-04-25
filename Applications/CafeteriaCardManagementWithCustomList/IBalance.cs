using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafteriaCardManagementWithCustomList
{
    //Interface
    public interface IBalance
    {
        //Property
        public int WalletBalance { get; set; }

        //Methods Declaration
        public int WalletRecharge(int cash);

        public int DeductAmount(int cash);
    }
}