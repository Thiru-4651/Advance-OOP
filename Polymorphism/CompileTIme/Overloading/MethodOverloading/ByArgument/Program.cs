using System;
namespace ByArgument;
class Program 
{
    public static void Main(string[] args)
    {
        Add(1,2);
        Add(1,2,3);
    }
    public static void Add(int a,int b,int c)
    {
        System.Console.WriteLine(a+b+c);
    }
    public static void Add(int a,int b)
    {
        System.Console.WriteLine(a+b);
    }
}