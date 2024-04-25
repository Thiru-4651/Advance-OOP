using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public class Circle : ICalculate
    {
        private int _number;

        public int Number { get; set; }

        public int Calculate()
        {
            _number = (int)Math.PI * (int)Math.Pow(Number, 2);
            return _number;
        }
    }
}