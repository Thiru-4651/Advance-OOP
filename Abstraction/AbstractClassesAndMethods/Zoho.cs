using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public class Zoho :Employee
    {
        //Abstract Property Definitions
        public override string Name{get{return _name;}set{_name=value;}}
        //Abstract Method Defintions
        public override double Salary(int dates)
        {
            Amount=(double)dates*2000;
            return Amount;
        }
    }
}