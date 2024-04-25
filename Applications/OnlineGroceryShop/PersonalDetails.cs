using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public enum Gender{Male,Female,Transgender}
    public class PersonalDetails
    {
        /// <summary>
        /// Property for storing Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property for storing FatherName
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// Property for storing Gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Property for storing Mobile
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// Property for storing DOB
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Property for storing MailID
        /// </summary>
        public string MailID { get; set; }

        /// <summary>
        /// Constrcutor for assiging values to the properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="gender"></param>
        /// <param name="mobile"></param>
        /// <param name="dob"></param>
        /// <param name="mailID"></param>
        public PersonalDetails(string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            DOB=dob;
            MailID=mailID;
        }

        /// <summary>
        /// Default Constrcutor for assiging values to the properties
        /// 
        /// </summary>
        public PersonalDetails()
        {
            
        }
    }
}