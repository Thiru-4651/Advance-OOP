using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public class CustomerDetails :PersonalDetails,IBalance
    {

        /// <summary>
       /// AutoIncreament values cref="BookingDetails"
       /// </summary>
        private static int _customerID=1000;

        public string CustomerID { get; }

        /// <summary>
        /// Property for storing WalletBalance
        /// </summary>
        public int WalletBalance { get; set; }

        /// <summary>
        /// Constructor for assiging values to properties
        /// 
        /// </summary>
        /// <param name="walletBalance"></param>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="gender"></param>
        /// <param name="mobile"></param>
        /// <param name="dob"></param>
        /// <param name="mailID"></param>
        /// <returns></returns>
        public CustomerDetails(int walletBalance,string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailID):base( name, fatherName,gender, mobile, dob,mailID)
        {
            _customerID++;
            CustomerID="CID"+_customerID;
            WalletBalance=walletBalance;
        }

        /// <summary>
        /// Constructor for assiging values to properties
        /// 
        /// </summary>
        /// <param name="array"></param>
        public CustomerDetails(string array)
        {
            string[] values=array.Split(",");
            _customerID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[0];
            WalletBalance=int.Parse(values[1]);
            Name=values[2];
            FatherName=values[3];
            Gender=Enum.Parse<Gender>(values[4]);
            Mobile=values[5];
            DOB=DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID=values[7];
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="cash"></param>
       /// <returns></returns>
        public int WalletRecharge(int cash) 
        {
            WalletBalance+=cash;
            return WalletBalance;
        }

        
    }
}