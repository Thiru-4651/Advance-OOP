using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails :PersonalDetails,IBalance
    {
        //CustomerID, WalletBalance
        private static int _customerID=1000;
        private int _balance;
        public string CustomerID { get; }
        public int WalletBalance { get{return _balance;}  }
        
        public CustomerDetails(int walletBalance,string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailID,string location):base( name, fatherName, gender, mobile, dob, mailID, location)
        {
            _customerID++;
            CustomerID="CID"+_customerID;
            _balance=walletBalance;
        }

        public CustomerDetails(string array)
        {
            string [] values=array.Split(",");
            _customerID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[0];
            _balance=int.Parse(values[1]);
            Name=values[2];
            FatherName=values[3];
            Gender=Enum.Parse<Gender>(values[4]);
            Mobile=values[5];
            DOB=DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID=values[7];
            Location=values[8];
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