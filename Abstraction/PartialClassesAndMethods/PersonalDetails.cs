using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClassesAndMethods
{
    public enum Gender{Default,Male,Female}
    public partial class PersonalDetails
    {
        
        //Property Class
        
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }
    }
}