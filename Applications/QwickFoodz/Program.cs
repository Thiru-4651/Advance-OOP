using System;
namespace QwickFoodz;
class Program 
{
    public static void Main(string[] args)
    {
        FileHandling.CreateCSV();

        FileHandling.ReadFromCSV();

        //Operations.AddingDefaultData();

        Operations.MainMenu();

        FileHandling.WriteToCSV();
    }
}
