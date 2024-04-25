using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierachicalInheritance
{
    public class CustomerDetails : PersonalDetails
    {
        private static int s_customerID=400;
        public string CustomerID { get;  }
        public int Balance { get; set; }

        public CustomerDetails(string userID,string name,string fatherName,Gender gender,long phoneNumber,int balance):base(userID,name,fatherName,gender,phoneNumber)
        {
            s_customerID++;
            CustomerID="CD"+s_customerID;
            Balance=balance;
        }
    }
}