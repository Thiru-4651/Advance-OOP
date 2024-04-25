using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    //Static Class Creation
    public static class Operations
    {
        //Custom List For storing the user details
        public static CustomList<UserDetails> userCustomList = new CustomList<UserDetails>();

        //Custom List For storing the travel details
        public static CustomList<TravelDetails> travelCustomList = new CustomList<TravelDetails>();

        //Custom List For storing the ticket fair details
        public static CustomList<TicketfairDetails> ticketFairCustomList = new CustomList<TicketfairDetails>();

        //For storing the user details
        static UserDetails currentLoggedInUser;

        //MainMenu
        public static void MainMenu()
        {
            System.Console.WriteLine("\n      Welcome To the MetroCard Management Application      \n");
            bool flag = true;
            do
            {
                //MainMenu entrance
                System.Console.WriteLine("**************************MainMenu**************************\n\n1.New User Registration\n2.Login User\n3.Exit");
                System.Console.Write("Enter the option from the MainMenu: ");
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("**************************New User Registration**************************");
                            newUserRegistration();
                            break;
                        }

                    case 2:
                        {
                            System.Console.WriteLine("**************************Login User**************************");
                            LoginUser();
                            break;
                        }

                    case 3:
                        {
                            flag = false;
                            System.Console.WriteLine("Thank you for using this application. Have a nice day :) ");
                            System.Console.WriteLine("**************************Application Closing....**************************");
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid option");
                            break;
                        }
                }
            } while (flag);
        }//MainMenu Ends

        //newUserRegistration
        public static void newUserRegistration()
        {
            //Getting the user details

            System.Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter your PhoneNumber: ");
            long phoneNumber = long.Parse(Console.ReadLine());

            System.Console.Write("Enter the Balance: ");
            int balance = int.Parse(Console.ReadLine());

            //For checking balance is greater 15
            while (!(balance >= 15))
            {
                System.Console.WriteLine("Low Balance..Minimum Balance 15 required ");
                System.Console.Write("Re-Enter the Balance: ");
                balance = int.Parse(Console.ReadLine());
            }

            //Creating the new userdetails object
            UserDetails newUser = new UserDetails(name, phoneNumber, balance);

            //Adding the object to the list
            userCustomList.Add(newUser);

            //Printing the cardNumber to the user
            System.Console.WriteLine("Registration Successfull  :) \nYour CardNumber is: " + newUser.CardNumber);

        }//newUserRegistration ends

        //Login User
        public static void LoginUser()
        {
            //Getting the cardnumber from the user
            System.Console.Write("Enter your CardNumber: ");
            string userEnteredCardNumber = Console.ReadLine().ToUpper();

            int count = 0;

            //Checking is it valid or not
            foreach (UserDetails user in userCustomList)
            {
                if (user.CardNumber.Equals(userEnteredCardNumber))
                {
                    //Welcom message
                    System.Console.WriteLine($"Welcome {user.Name} you are logged in sucessfully :) ");
                    count = 1;

                    //Assinging the user details to the global userdetails object
                    currentLoggedInUser = user;

                    //SubMenu method 
                    SubMenu();
                    break;
                }
            }

            //for not valid id
            if (count == 0)
            {
                System.Console.WriteLine("The card number you entered is not a valid one");
            }

        }//LoginUser ends

        //SubMenu
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                //Submenu Entrance
                System.Console.WriteLine("\n**************************SubMenu**************************\n\na.Balance Check\nb.Recharge\nc.View Travel History\nd.Travel\ne.Exit\n");

                //Getting the option from the user 
                System.Console.Write("Enter the option from SubMenu:");
                char subOption = char.Parse(Console.ReadLine().ToLower());

                //Switching the option
                switch (subOption)
                {
                    case 'a':
                        {
                            System.Console.WriteLine("**************************Balance Check Section**************************");
                            BalanceCheck();
                            break;
                        }

                    case 'b':
                        {
                            System.Console.WriteLine("**************************Recharge Section**************************");
                            Recharge();
                            break;
                        }

                    case 'c':
                        {
                            System.Console.WriteLine("**************************Travel History Section**************************");
                            TravelHistory();
                            break;
                        }

                    case 'd':
                        {
                            System.Console.WriteLine("**************************Travel Section**************************");
                            Travel();
                            break;
                        }

                    case 'e':
                        {
                            flag = false;
                            System.Console.WriteLine("Exited Successfully.You are Redirected to MainMenu");
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid Option");
                            break;
                        }
                }
            } while (flag);

        }//SubMenu ends

        //Balance Check
        public static void BalanceCheck()
        {
            //Showing the current balance to the user
            System.Console.WriteLine("You Current Balance is: " + currentLoggedInUser.Balance);

        } //BalanceCheck ends

        //Recharge
        public static void Recharge()
        {
            //Getting the amount to be recharged from the user
            System.Console.Write("Enter the Amount to be Recharged: ");
            int amount = int.Parse(Console.ReadLine());

            //Showing the updated balance 
            System.Console.WriteLine("Your Updated Balance is: " + currentLoggedInUser.WalletRecharge(amount));

        }//Recharge ends

        //TravelHistory
        public static void TravelHistory()
        {
            int count = 0;
            foreach (TravelDetails travel in travelCustomList)
            {
                if (travel.CardNumber.Equals(currentLoggedInUser.CardNumber))
                {
                    count++;
                    System.Console.WriteLine($"{travel.TravelId}\t{travel.CardNumber}\t{travel.FromLocation}\t\t{travel.ToLocation}\t\t{travel.Date.ToString("dd/MM/yyyy")}\t{travel.TravelCost}");
                }
            }
            if (count == 0)
            {
                System.Console.WriteLine("You didn't traveled any places");
            }
        }//TravelHistory ends

        //Travel
        public static void Travel()
        {
            //Printing the default travel details
            foreach (TicketfairDetails ticketfair in ticketFairCustomList)
            {
                System.Console.WriteLine($"{ticketfair.TicketID}\t{ticketfair.FromLocation}\t\t{ticketfair.ToLocation}\t\t{ticketfair.TicketPrice}");
            }

            //Getting the Ticket ID from the user
            System.Console.Write("Enter the TicketID to travel: ");
            string userEnteredTicketID = Console.ReadLine().ToUpper();

            bool flag = true;

            foreach (TicketfairDetails ticketfair in ticketFairCustomList)
            {
                //Checking the userEnteredTicketID is valid or not
                if (ticketfair.TicketID.Equals(userEnteredTicketID))
                {
                    flag = false;

                    //Checking the user has the enough balance to continue
                    if (currentLoggedInUser.Balance >= ticketfair.TicketPrice)
                    {
                        //Deducting the amount from the user
                        currentLoggedInUser.DeductBalance(ticketfair.TicketPrice);

                        //Creating the new travel object
                        TravelDetails newTravel = new TravelDetails(currentLoggedInUser.CardNumber, ticketfair.FromLocation, ticketfair.ToLocation, DateTime.Now, ticketfair.TicketPrice);

                        //Adding the new object to the list
                        travelCustomList.Add(newTravel);
                        System.Console.WriteLine("Booking successfull");
                    }

                    //Insufficient balance
                    else
                    {
                        //Asking the user to recharge
                        System.Console.Write("Do you want to Recharge and continue (yes/no): ");
                        string toRecharge = Console.ReadLine().ToLower();

                        if (toRecharge == "yes")
                        {
                            //Recharging the ticket price
                            currentLoggedInUser.WalletRecharge(ticketfair.TicketPrice);

                            //Deducting the ticket price the wallet balance
                            currentLoggedInUser.DeductBalance(ticketfair.TicketPrice);

                            //Creating the new travel object
                            TravelDetails newTravel = new TravelDetails(currentLoggedInUser.CardNumber, ticketfair.FromLocation, ticketfair.ToLocation, DateTime.Now, ticketfair.TicketPrice);

                            //Adding the new object to the list
                            travelCustomList.Add(newTravel);
                            System.Console.WriteLine("Booking successfull");
                        }
                        else
                        {
                            //Exiting from the travel section
                            System.Console.WriteLine("Exiting User service");
                        }

                    }
                    break;
                }
            }

            //For not valid ID
            if (flag)
            {
                System.Console.WriteLine("Invalid Ticked ID");
            }
        }//Travel ends

        //AddingDefaultData
        public static void AddingDefaultData()
        {
            //Creating the userdetails with default values
            UserDetails user1 = new UserDetails("Ravi", 9848812345, 1000);
            UserDetails user2 = new UserDetails("Baskaran", 9948854321, 1000);

            //Adding the default values to the list
            userCustomList.Add(user1);
            userCustomList.Add(user2);


            //Creating the traveldetails with default values
            TravelDetails travel1 = new TravelDetails("CMRL1001", "AirPort", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelDetails travel2 = new TravelDetails("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 32);
            TravelDetails travel3 = new TravelDetails("CMRL1002", "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 25);
            TravelDetails travel4 = new TravelDetails("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);


            //Adding the default values to the list
            travelCustomList.Add(travel1);
            travelCustomList.Add(travel2);
            travelCustomList.Add(travel3);
            travelCustomList.Add(travel4);


            //Creating the ticketfairdetails with default values
            TicketfairDetails ticketfair1 = new TicketfairDetails("Airport", "Egmore", 55);
            TicketfairDetails ticketfair2 = new TicketfairDetails("Airport", "Koyambedu", 25);
            TicketfairDetails ticketfair3 = new TicketfairDetails("Alandur", "Koyambedu", 25);
            TicketfairDetails ticketfair4 = new TicketfairDetails("Koyambedu", "Egmore", 32);
            TicketfairDetails ticketfair5 = new TicketfairDetails("Vadapalani", "Egmore", 45);
            TicketfairDetails ticketfair6 = new TicketfairDetails("Arumbakkam", "Egmore", 25);
            TicketfairDetails ticketfair7 = new TicketfairDetails("Vadapalani", "Koyambedu", 25);
            TicketfairDetails ticketfair8 = new TicketfairDetails("Arumbakkam", "Koyambedu", 16);

            //Adding the default values to the list
            ticketFairCustomList.Add(ticketfair1);
            ticketFairCustomList.Add(ticketfair2);
            ticketFairCustomList.Add(ticketfair3);
            ticketFairCustomList.Add(ticketfair4);
            ticketFairCustomList.Add(ticketfair5);
            ticketFairCustomList.Add(ticketfair6);
            ticketFairCustomList.Add(ticketfair7);
            ticketFairCustomList.Add(ticketfair8);

        }//AddingDefaultData ends
    }
}