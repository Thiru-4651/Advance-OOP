using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByType
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Add method to add integer
            int result=Add(1,2);
            System.Console.WriteLine(result);
            
            string result1=Add("1","2");
            System.Console.WriteLine(result1);

            double result2=Add(3.0,2);
            System.Console.WriteLine(result2);
        }
        public static int Add(int a,int b)
        {
            return a+b;
        }
         public static double Add(double a,double b)
        {
            return a+b;
        }
        public static string Add(string a,string b)
        {
            return a+b;
        }
    }
}