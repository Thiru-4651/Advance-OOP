using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLevelInheritance
{
    public enum Gender { Select, Male, Female }
    public class PersonalDetails
    {
        private static int s_userID = 100;

        public string UserID { get; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long PhoneNumber { get; set; }

        public PersonalDetails(string name, string fatherName, Gender gender, long phoneNumber)
        {
            s_userID++;
            UserID = "PD" + s_userID;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }

        public PersonalDetails(string userID,string name, string fatherName, Gender gender, long phoneNumber)
        {
            
            UserID = userID;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }


    }
}