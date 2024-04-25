using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CCAccount ccAccount = new CCAccount();
            ccAccount.AccountNumber = 123;
            ccAccount.Name = "Thiru";
            ccAccount.Balance = 10000;

        }
    }
}