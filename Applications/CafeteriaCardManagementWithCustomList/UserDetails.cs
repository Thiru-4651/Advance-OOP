using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafteriaCardManagementWithCustomList
{
    //Class
    public class UserDetails : PersonalDetails, IBalance
    {
        //Field
        private static int s_userID = 1000;
        public string UserID { get; }      //read-only
        public string WorkStationNumber { get; set; }
        public int WalletBalance { get; set; }

        //Constructor
        public UserDetails(string name, string fatherName, long phoneNumber, string mailID, Gender gender, string workStationNumber, int walletBalance) : base(name, fatherName, gender, phoneNumber, mailID)
        {
            s_userID++;
            UserID = "SF" + s_userID;
            WorkStationNumber = workStationNumber;
            WalletBalance = walletBalance;
        }

        //Methods
        public int WalletRecharge(int cash)
        {
            WalletBalance += cash;
            return WalletBalance;
        }
        public int DeductAmount(int cash)
        {
            WalletBalance -= cash;
            return WalletBalance;
        }

    }
}