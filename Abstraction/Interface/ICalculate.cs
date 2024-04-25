using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICalculate
    {
        //No fields and constructors
        
        //Property
        public int Number { get; set; }     //Declartion only

        int Calculate();//Method - Declaretion
        //Fully abstracion - No definition

    }
}