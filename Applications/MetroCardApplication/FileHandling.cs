using System;
using System.IO;
using System.Collections.Generic;

namespace MetroCardApplication
{
    public class FileHandling
    {
        public static void CreateCSV()
        {
            //Checking the folder exits or not
            if (!Directory.Exists("MertoCardApplication"))
            {
                System.Console.WriteLine("Creating the folder");
                Directory.CreateDirectory("MertoCardApplication");
            }

            //Checking the file exits or not
            if (!File.Exists("MertoCardApplication/UserDetails.csv"))
            {
                System.Console.WriteLine("Creating the file");
                File.Create("MertoCardApplication/UserDetails.csv");
            }

            //Checking the file exits or not            
            if (!File.Exists("MertoCardApplication/TravelDetails.csv"))
            {
                System.Console.WriteLine("Creating the file");
                File.Create("MertoCardApplication/TravelDetails.csv");
            }

            //Checking the file exits or not
            if (!File.Exists("MertoCardApplication/TicketfairDetails.csv"))
            {
                System.Console.WriteLine("Creating the file");
                File.Create("MertoCardApplication/TicketfairDetails.csv");
            }
        }

        public static void WriteToCSV()
        {
            //Writing the user details to the files
            string[] userDetailsArray = new string[Operations.userCustomList.Count];

            for (int i = 0; i < Operations.userCustomList.Count; i++)
            {
                userDetailsArray[i] = Operations.userCustomList[i].CardNumber + "," + Operations.userCustomList[i].Name + "," + Operations.userCustomList[i].PhoneNumber + "," + Operations.userCustomList[i].Balance;
            }

            File.WriteAllLines("MertoCardApplication/UserDetails.csv", userDetailsArray);


            //Writing the travel details to the files

            string[] travelDetailsArray = new string[Operations.travelCustomList.Count];

            for (int i = 0; i < Operations.travelCustomList.Count; i++)
            {
                travelDetailsArray[i] = Operations.travelCustomList[i].TravelId + "," + Operations.travelCustomList[i].CardNumber + "," + Operations.travelCustomList[i].FromLocation + "," + Operations.travelCustomList[i].ToLocation + "," + Operations.travelCustomList[i].Date.ToString("dd/MM/yyyy") + "," + Operations.travelCustomList[i].TravelCost;
            }

            File.WriteAllLines("MertoCardApplication/TravelDetails.csv", travelDetailsArray);


            //Writing the ticketfair details to the files

            string[] ticketfairDetailsArray = new string[Operations.ticketFairCustomList.Count];

            for (int i = 0; i < Operations.ticketFairCustomList.Count; i++)
            {
                ticketfairDetailsArray[i] = Operations.ticketFairCustomList[i].TicketID + "," + Operations.ticketFairCustomList[i].FromLocation + "," + Operations.ticketFairCustomList[i].ToLocation + "," + Operations.ticketFairCustomList[i].TicketPrice;
            }

            File.WriteAllLines("MertoCardApplication/TicketfairDetails.csv", ticketfairDetailsArray);

        }

        public static void ReadFromCSV()
        {
            //Reading the user details from the file
            string[] userDetailsArray = File.ReadAllLines("MertoCardApplication/UserDetails.csv");

            foreach (string user in userDetailsArray)
            {
                UserDetails newUser = new UserDetails(user);
                Operations.userCustomList.Add(newUser);
            }
            
            //Reading the user details from the file

            string[] travelDetailsArray = File.ReadAllLines("MertoCardApplication/TravelDetails.csv");

            foreach (string travel in travelDetailsArray)
            {
                TravelDetails newtravelDetail = new TravelDetails(travel);
                Operations.travelCustomList.Add(newtravelDetail);
            }
            //Reading the user details from the file

            string[] ticketfairDetailsArray = File.ReadAllLines("MertoCardApplication/TicketfairDetails.csv");

            foreach (string ticketfair in ticketfairDetailsArray)
            {
                TicketfairDetails newticketfairDetail = new TicketfairDetails(ticketfair);
                Operations.ticketFairCustomList.Add(newticketfairDetail);
            }
        }
    }
}