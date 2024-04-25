using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public class Syncfusion :Employee
    {
        //abstaract property definition 

        public override string Name{get{return _name;} set{_name=value;}}
        //Abstract Method Defintions
        public override double Salary(int dates)
        {
            Amount=(double)dates*1000;
            return Amount;
        }
    }
}