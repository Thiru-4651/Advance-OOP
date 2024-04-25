using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public abstract class Employee  //Abstract Classes
    {
        //Abstract class - Partial Abstracion .
        //It has fields , properties, method, constructor,destructor,indexer,events.
        //Can have both abstract declarauion and normal definitons.
        //Can only used with the inherited class.
        //Not support multiple inheritance.
        //it cannot be a static class 
        protected string _name;     //Normal Fields
        public abstract string Name { get; set; }    //Abstract 
        public double Amount { get; set; }
        public string Display()   //Normal Method
        {
            return _name;
        }
        public abstract double Salary(int dates);   //Abstract Method - Only Declaration
    }
}