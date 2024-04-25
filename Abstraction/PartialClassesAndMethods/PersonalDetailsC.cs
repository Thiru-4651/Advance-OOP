using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClassesAndMethods
{
    public partial class PersonalDetails
    {
        //Methods Definition Class

        public partial int CalculateAge()      //Partial Method used here
        {
            TimeSpan span=DateTime.Now-DOB;
            int age=span.Days/365;
            return age;
        }
    }
}