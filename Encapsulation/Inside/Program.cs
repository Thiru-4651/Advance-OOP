using System;
using Outside;

namespace Inside;
public class Program 
{
    public static void Main(string[] args)
    {
        First first=new First();
        System.Console.WriteLine(first.PirvateOut);

        System.Console.WriteLine(first.PublicNumber);

        Second second=new Second();
        System.Console.WriteLine(second.ProtectedNumberOut);

        System.Console.WriteLine(first.internalProtectedNumberOut);

        System.Console.WriteLine(first.PrivateNumberOut);
   
    }
}