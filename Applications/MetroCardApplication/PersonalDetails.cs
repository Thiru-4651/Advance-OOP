using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class PersonalDetails
    {
        /// <summary>
        /// Property for storing the User Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property for storing the User PhoneNumber
        /// </summary>
        public long PhoneNumber{ get; set; }

        /// <summary>
        /// Parameterized Constructor For assiging values to the Properites
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public PersonalDetails(string name,long phoneNumber)
        {
            Name=name;
            PhoneNumber=phoneNumber;
        }

        /// <summary>
        /// Default Constructor for FileHandling
        /// </summary>
        public PersonalDetails()
        {

        }
    }
}