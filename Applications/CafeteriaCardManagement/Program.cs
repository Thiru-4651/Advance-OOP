using System;
using CafeteriaCardManagement;
namespace CafteriaCardManagement;
class Program
{
    public static void Main(string[] args)
    {
        //Calling AddingDefaultData method 
        Operations.AddingDefaultData();

        //Calling MainMenu method
        Operations.MainMenu();
    }
}