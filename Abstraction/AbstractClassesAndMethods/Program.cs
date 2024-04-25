using System;
namespace AbstractClassesAndMethods;
class Program
{
    public static void Main(string[] args)
    {
        Employee job1 = new Syncfusion();
        job1.Name = "Itachi";
        System.Console.WriteLine(job1.Display());
        System.Console.WriteLine(job1.Salary(20));

        Employee job2 = new Zoho();
        job2.Name = "Minato";
        System.Console.WriteLine(job2.Display());
        System.Console.WriteLine(job2.Salary(20));
        
    }
    

}