using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class PersonalDetails
    {
        /// <summary>
        /// Property for storing Name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
         /// <summary>
        /// Property for storing Age
        /// </summary>
        public int Age { get; set; }
         /// <summary>
        /// Property for storing City
        /// </summary>
        public string City{ get; set; }
         /// <summary>
        /// Property for storing PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="city"></param>
        /// <param name="phoneNumber"></param>
        public PersonalDetails(string name,int age,string city,string phoneNumber)
        {
            Name=name;
            Age=age;
            City=city;
            PhoneNumber=phoneNumber;
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PersonalDetails()
        {
            
        }
    }
}