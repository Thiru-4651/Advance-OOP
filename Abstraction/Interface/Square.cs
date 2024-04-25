using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public class Square : ICalculate
    {
        //Field for stroing the property
        private int _number;
        public int Number { get{return _number;} set{_number=value;} }      //Property

        public int Calculate()
        {
            Number*=Number;
            return Number;
        }
    }
}