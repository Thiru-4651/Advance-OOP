using System;
namespace Interface;
class Program 
{
    public static void Main(string[] args)
    {
        Square area=new Square();   //class variable as object
        area.Number=20;
        System.Console.WriteLine(area.Calculate()); 

        Circle circleArea=new Circle();
        circleArea.Number=5;
        System.Console.WriteLine(circleArea.Calculate());
    }
}