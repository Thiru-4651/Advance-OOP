using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafteriaCardManagementWithCustomList
{
    //Enum
    public enum Gender { Select, Male, Female, Transgender }

    //Class
    public class PersonalDetails
    {
        //Properties
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string MailID { get; set; }

        //Constructor
        public PersonalDetails(string name, string fatherName, Gender gender, long phoneNumber, string mailID)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            MailID = mailID;
        }

    }
}