using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class UserDetails :PersonalDetails,IBalance
    {
        private static int _balance;
        
        /// <summary>
        /// Private Field for stroring CardNumber
        /// </summary>
        private static int _cardNumber=1000;

        /// <summary>
        /// Read only Property for accessing the private field 
        /// </summary>
        public string CardNumber { get; }
        /// <summary>
        /// Property for accessing the user Balance
        /// </summary>
        public int Balance { get{return _balance;}  }

        /// <summary>
        /// Constructor assiging values to the Properites
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public UserDetails(string name,long phoneNumber,int balance):base(name,phoneNumber)
        {
            _cardNumber++;
            CardNumber="CMRL"+_cardNumber;
            _balance=balance;
        }

        /// <summary>
        /// Constructor for File Handling
        /// </summary>
        /// <param name="newUser"></param>
        public UserDetails(string newUser)
        {
            string [] values=newUser.Split(",");
            _cardNumber=int.Parse(values[0].Remove(0,4));
            CardNumber=values[0];
            Name=values[1];
            PhoneNumber=long.Parse(values[2]);
            _balance=int.Parse(values[3]);
        }

        /// <summary>
        /// Method For Wallet Recharge
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        public int WalletRecharge(int cash)
        {
            _balance+=cash;
            return Balance;
        }

        /// <summary>
        /// Method For Deducting the amount from the user balance
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        public int DeductBalance(int cash)
        {
            _balance-=cash;
            return Balance;
        }
    }
}