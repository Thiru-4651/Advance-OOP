using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class SBAccount:IAccount
    {
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
    }
}