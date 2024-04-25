using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class CCAccount :IAccount
    {
        public int AccountNumber{get;set;} 
        public string Name  { get; set; }
        public double Balance { get; set; }
    }
}