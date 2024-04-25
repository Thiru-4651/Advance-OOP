using System;
namespace OnlineMedicalStore;
class Program 
{
    public static void Main(string[] args)
    {
        //Method for creating the csv files
        FileHandlings.CreatCSV();

        //method for reading the datas from the csv files
        FileHandlings.ReadFromCSV();
        
        //Method for Adding Default Data
        //Operations.AddingDefaultData();

        //For Showing Mainmenu 
        Operations.MainMenu();

        //Method for Writing in the csv files
        FileHandlings.WriteToCSV();
    }
}