using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails:PersonalDetails,IWallet
    {
        /// <summary>
        /// AutoIncreament values cref="UserDetails"
        /// </summary>
        private static int _userID=1000;
        /// <summary>
        /// Property for storing UserID
        /// </summary>
        public string UserID { get; }
        /// <summary>
        /// Private Field for Balance
        /// </summary>
        private int _balance;
        /// <summary>
        /// Property for storing WalletBalance
        /// </summary>
        public int WalletBalance { get{return _balance;}  }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="city"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="walletBalance"></param>
        /// <returns></returns>
        public UserDetails(string name,int age,string city,string phoneNumber,int walletBalance):base(name,age,city,phoneNumber)
        {
            _userID++;
            UserID="UID"+_userID;
            _balance=walletBalance;
        }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="newUser"></param>
        public UserDetails(string newUser)
        {
            string[] values=newUser.Split(",");
            _userID=int.Parse(values[0].Remove(0,3));
            UserID=values[0];
            Name=values[1];
            Age=int.Parse(values[2]);
            City=values[3];
            PhoneNumber=values[4];
            _balance=int.Parse(values[5]);
        }

        public int WalletRecharge(int cash)
        {
            _balance+=cash;
            return WalletBalance;
        }

        public int DeductBalance(int cash)
        {
            _balance-=cash;
            return WalletBalance;
        }
    }
}