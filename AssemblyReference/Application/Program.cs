using System;
using CollegeDetails;
namespace Application;
public class Program
{
    public static void Main(string[] args)
    {
        //Default Data Calling
        Operations.AddingDefaultData();

        //MainMenu Calling
        Operations.MainMenu();
    }
}