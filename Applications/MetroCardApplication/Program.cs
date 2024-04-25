using System;
namespace MetroCardApplication;
class Program 
{
    public static void Main(string[] args)
    {
        //Calling CreateCSV method
        FileHandling.CreateCSV();

        //Calling ReadFromCSV method
        FileHandling.ReadFromCSV();

        //Calling AddingDefaultData method
        //Operations.AddingDefaultData();

        //Calling MainMenu method
        Operations.MainMenu();

        //Calling WriteToCSV method
        FileHandling.WriteToCSV();
    }
}