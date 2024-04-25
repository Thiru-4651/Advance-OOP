using System;
namespace OnlineGroceryShop;
class Program 
{
    public static void Main(string[] args)
    {
        //Calling the CreateCSV method
        FileHandling.CreateCSV();

        //Calling the ReadFrom CSV method
        FileHandling.ReadFromCSV();

        //Calling the AddingDeafaultData method
        //Operations.AddingDeafaultData();

        //Caling the mainmenu method
        Operations.MainMenu();

        //Calling the WtiteTo CSV method
        FileHandling.WriteToCSV();
    }
}