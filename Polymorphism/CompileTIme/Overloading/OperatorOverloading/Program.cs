using System;
namespace OperatorOverloading;
class Program 
{
    public static void Main(string[] args)
    {
        //Use debugging see the run progress 
        
        Box box1 = new Box(1.0,2.0,3.0);
        Box box2 = new Box(4.0,5.0,6.0);

        System.Console.WriteLine(box1.CalculateVolume());
        System.Console.WriteLine(box2.CalculateVolume());

        Box box3 = Box.Add(box1,box2);

        Box box4 = box1+box2;

        int c=1+2;
        System.Console.WriteLine(c);
    }
}