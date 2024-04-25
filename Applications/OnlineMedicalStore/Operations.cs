using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public static class Operations
    {
        //CustomLIst for stroing userDetails
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();

        //CustomLIst for stroing MEddicine Details
        public static CustomList<MedicineDetails> medicineList = new CustomList<MedicineDetails>();

        //CustomLIst for stroing Order Details
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();

        //Global object for stroing details of current user 
        static UserDetails currentLoggedInUser;

        public static void MainMenu()
        {
            // Application Entrance
            System.Console.WriteLine("\n**************************Online Medical Store**************************\n");
            bool flag = true;

            do
            {
                //Mainmenu entrance
                System.Console.WriteLine("MainMenu\n1.Registeration\n2.Login\n3.Exit\n");

                //Getting the option from the user
                System.Console.Write("Enter the Option from Mainmenu: ");
                int mainOption = int.Parse(Console.ReadLine());

                //Switching mainoption to correspoding case
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("**************************Registeration Section**************************");
                            Registeration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("**************************Login Section**************************");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            System.Console.WriteLine("************************** Thank you for using this Application.Have a nice day :) **************************");
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Option");
                            break;
                        }
                }

                //Iteration until user selects exit
            } while (flag);

        }

        //Registration method
        public static void Registeration()
        {
            //Getting user details
            System.Console.Write("Enter the Name:");
            string name = Console.ReadLine();
            System.Console.Write("Enter the Age: ");
            int age = int.Parse(Console.ReadLine());
            System.Console.Write("Enter the City: ");
            string city = Console.ReadLine();
            System.Console.Write("Enter the PhoneNumber: ");
            string phoneNumber = Console.ReadLine();
            System.Console.Write("Enter the Balance: ");
            int balance = int.Parse(Console.ReadLine());

            //Creating the new object
            UserDetails user = new UserDetails(name, age, city, phoneNumber, balance);

            //Once the new user account is created and show the user ID
            System.Console.WriteLine("Registration Successfull.Your UserID is: " + user.UserID);
            userList.Add(user);
        }

        public static void Login()
        {
            //Ask for the “User ID” of the user
            System.Console.Write("Enter your UserID: ");
            string userEnteredUserID = Console.ReadLine().ToUpper();
            bool flag = true;

            //Check the “User ID” in the user list
            foreach (UserDetails user in userList)
            {
                //If “User ID” exists
                if (user.UserID.Equals(userEnteredUserID))
                {
                    flag = false;
                    currentLoggedInUser = user;
                    System.Console.WriteLine($"Welcome! {user.Name} you are logged in successfully");
                    SubMenu();
                    break;
                }
            }

            //If the user ID does not exist means, show “Invalid User ID
            if (flag)
            {
                System.Console.WriteLine("Invald UserID");
            }
        }

        //Submenu Method
        public static void SubMenu()

        {
            bool flag = true;
            do
            {
                //Submenu Entrance
                System.Console.WriteLine("SubMenu:\na.Show Medicine List\nb.Purchase medicine\nc.Modify purchase\nd.Cancel purchase\ne.Show purchase history\nf.Recharge Wallet\ng.Show Wallet Balance\nh.Exit");

                //Getting the input from the user
                System.Console.WriteLine("Enter the opetion from Submenu: ");
                char subOption = char.Parse(Console.ReadLine());
                switch (subOption)
                {
                    case 'a':
                        {
                            ShowMedicineList();
                            break;
                        }
                    case 'b':
                        {
                            PurchaseMedicine();
                            break;
                        }
                    case 'c':
                        {
                            ModifyPurchase();
                            break;
                        }
                    case 'd':
                        {
                            CancelPurchase();
                            break;
                        }
                    case 'e':
                        {
                            ShowPurchasehistory();
                            break;
                        }
                    case 'f':
                        {
                            RechargeWallet();
                            break;
                        }
                    case 'g':
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 'h':
                        {
                            flag = false;
                            break;
                        }
                }
                //Iteration until user select exit
            } while (flag);
        }

        public static void ShowMedicineList()
        {
            //traversing the medicine details list
            foreach (MedicineDetails medicine in medicineList)
            {
                System.Console.WriteLine($"MedicineID: {medicine.MedicineID}\tMedicine Name: {medicine.MedicineName}\tAvailable Count: {medicine.AvailableCount}\tPrice: {medicine.Price}\tDateOfExpire: {medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }
        }

        public static void PurchaseMedicine()
        {
            //traversing the medicine details list
            foreach (MedicineDetails medicine in medicineList)
            {
                System.Console.WriteLine($"MedicineID: {medicine.MedicineID}\tMedicine Name: {medicine.MedicineName}\tAvailable Count: {medicine.AvailableCount}\tPrice: {medicine.Price}\tDateOfExpire: {medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }

            //Ask the user to select the medicine using MedicineID
            System.Console.Write("Enter the Medicine ID: ");
            string userEnteredMedicineID = Console.ReadLine().ToUpper();

            bool flag = true;
            //bool flag1=true;

            //Check the Medicine list whether the MedicineID was available
            foreach (MedicineDetails medicine in medicineList)
            {
                if (userEnteredMedicineID.Equals(medicine.MedicineID))
                {
                    flag = false;

                    //Gettingt the medicineID
                    System.Console.Write("Enter the number count of medicine: ");
                    int userEnteredQuantity = int.Parse(Console.ReadLine());

                    ///checking count is available
                    if (userEnteredQuantity <= medicine.AvailableCount)
                    {

                        //Check the medicine was not expired
                        if (medicine.DateOfExpiry >= DateTime.Now)
                        {
                            int totalPrice = userEnteredQuantity * medicine.Price;

                            //check User has enough balance to purchase 
                            if (currentLoggedInUser.WalletBalance >= totalPrice)
                            {
                                //Reduce the number of AvailableCount
                                medicine.AvailableCount -= userEnteredQuantity;

                                //Deducting the total amount
                                currentLoggedInUser.DeductBalance(totalPrice);

                                //object for OrderDetails class 
                                OrderDetails newOrder = new OrderDetails(currentLoggedInUser.UserID, medicine.MedicineID, userEnteredQuantity, totalPrice, DateTime.Now, OrderStatus.Purchased);

                                //add it to the list
                                orderList.Add(newOrder);
                                System.Console.WriteLine("Medicine was purchased successfully");
                            }
                            else
                            {
                                System.Console.WriteLine("Insufficient Balance. Recharge and continue");
                            }
                        }

                        //If it is expired 
                        else
                        {
                            System.Console.WriteLine("Medicine was expired");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Medicine was not available");
                    }
                }
            }
            //For Invalid MedicineID
            if (flag)
            {
                System.Console.WriteLine("Invalid MedicineID");
            }
        }
        public static void ModifyPurchase()
        {
            bool flag = true;
            
            //Show the order details 
            foreach (OrderDetails order in orderList)
            {
                
                //Check whether the purchase details is present
                if (currentLoggedInUser.UserID.Equals(order.UserID) && order.OrderStatus.Equals(OrderStatus.Purchased))
                {
                    flag = false;
                    System.Console.WriteLine($"UserID: {order.UserID}\tOrderID: {order.OrderID}\tMedicineID: {order.MedicineID}\tOrderStatus: {order.OrderStatus}");
                }
            }
            if (!flag)
            {
                //Getting the ordeID
                System.Console.WriteLine("Enter the OrderID: ");
                string userEnteredOrderID = Console.ReadLine().ToUpper();
                int count = 0;
                foreach (OrderDetails order in orderList)
                {
                    if (currentLoggedInUser.UserID.Equals(order.UserID) && order.OrderStatus.Equals(OrderStatus.Purchased) && order.OrderID.Equals(userEnteredOrderID))
                    {
                        count = 1;

                        //enter the new quantity of the medicine.
                        System.Console.WriteLine("Enter the newQuantity: ");
                        int userEnteredQuantity = int.Parse(Console.ReadLine());
                        int pricePerQuanity = 0;
                        
                        //Calculate the total price of order 
                        foreach (MedicineDetails medicine in medicineList)
                        {
                            if (order.MedicineID.Equals(medicine.MedicineID) && order.OrderStatus.Equals(OrderStatus.Purchased))
                            {
                                pricePerQuanity = medicine.Price;
                            }
                        }
                        int newPrice = pricePerQuanity * userEnteredQuantity;
                        
                        //update in purchase details entry
                        order.TotalPrice = newPrice;

                        System.Console.WriteLine("Order Modified successfully");
                    }
                }
                
                //For Invalid ID
                if (count == 0)
                {
                    System.Console.WriteLine("Invalid OrderID");
                }
            }

            else
            {
                System.Console.WriteLine("You have no orders to modify");
            }
        }
        public static void CancelPurchase()
        {
            bool flag = true;
            
            //Showing the order details 
            foreach (OrderDetails order in orderList)
            {
                //checking order status is Purchased
                if (currentLoggedInUser.UserID.Equals(order.UserID) && order.OrderStatus.Equals(OrderStatus.Purchased))
                {
                    flag = false;
                    System.Console.WriteLine($"UserID: {order.UserID}\tOrderID: {order.OrderID}\tMedicineID: {order.MedicineID}\tOrderStatus: {order.OrderStatus}");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have no orders to cancel");
            }
            else
            {
                //Get the OrderID information from the user
                System.Console.Write("Enter the orderID: ");
                string orderID = Console.ReadLine().ToUpper();
                int count = 0;

                //OrderID present in the list 
                foreach (OrderDetails order in orderList)
                {
                    
                    //check its OrderStatus is Purchased
                    if (order.OrderID.Equals(orderID) && order.OrderStatus.Equals(OrderStatus.Purchased))
                    {
                        count = 1;
                        foreach (MedicineDetails medicine in medicineList)
                        {
                            if (medicine.MedicineID.Equals(order.MedicineID))
                            {
                                //increase the count of that Medicine in the medicine details
                                medicine.AvailableCount += order.MedicineCount;

                                //Return the amount to the user
                                currentLoggedInUser.WalletRecharge(order.TotalPrice);

                                //Change the Status of the order to Cancelled
                                order.OrderStatus = OrderStatus.Cancelled;
                                System.Console.WriteLine("Order cancelled successfully");
                                break;
                            }
                        }
                    }
                }

                //For invalid OrderID
                if (count == 0)
                {
                    System.Console.WriteLine("Invalid OrderID");
                }
            }
        }
        public static void ShowPurchasehistory()
        {
            bool flag = true;
            
            //traversing the OrderDetails list
            foreach (OrderDetails order in orderList)
            {
                //Checking the userID
                if (order.UserID.Equals(currentLoggedInUser.UserID))
                {
                    flag = false;
                    System.Console.WriteLine($"OrderID: {order.OrderID}\tUserID: {order.UserID}\tMedicineID: {order.MedicineID}\tMedicine Count: {order.MedicineCount}\tTotal Price: {order.TotalPrice}\tOrder Date: {order.OrderDate.ToString("dd/MM/yyyy")}\tOrderStatus: {order.OrderStatus}");
                }
            }

            //For no purchase History
            if (flag)
            {
                System.Console.WriteLine("You have no purchase history to show ");
            }
        }

        
        public static void RechargeWallet()
        {
            //Gettingt the amount from user
            System.Console.WriteLine("Enter the Amount ");
            int amount = int.Parse(Console.ReadLine());

            //Recharging the amount
            currentLoggedInUser.WalletRecharge(amount);
        }
        public static void ShowWalletBalance()
        {
            //Displaing the user balance amount
            System.Console.WriteLine("Your current balance: " + currentLoggedInUser.WalletBalance);
        }

        public static void AddingDefaultData()

        {
            
            //Adding the default data of userdetails

            UserDetails user1 = new UserDetails("Ravi", 33, "Theni", "987774440", 400);
            UserDetails user2 = new UserDetails("Baskaran", 33, "Chennai", "8847757470", 500);

            userList.Add(user1);
            userList.Add(user2);

            //Adding the default data of medicine details
            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, new DateTime(2024, 06, 30));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 10, 5, new DateTime(2024, 05, 30));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 3, 40, new DateTime(2023, 04, 30));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 5, 50, new DateTime(2024, 12, 30));
            MedicineDetails medicine5 = new MedicineDetails("Povidon Iodin", 10, 50, new DateTime(2024, 10, 30));

            medicineList.Add(medicine1);
            medicineList.Add(medicine2);
            medicineList.Add(medicine3);
            medicineList.Add(medicine4);
            medicineList.Add(medicine5);

            //Adding the default data of order details
            
            OrderDetails order1 = new OrderDetails("UID1001", "MD101", 3, 15, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails("UID1001", "MD102", 2, 10, new DateTime(2022, 11, 13), OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails("UID1001", "MD104", 2, 100, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails("UID1002", "MD103", 3, 120, new DateTime(2022, 11, 15), OrderStatus.Cancelled);
            OrderDetails order5 = new OrderDetails("UID1002", "MD105", 5, 250, new DateTime(2022, 11, 15), OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails("UID1002", "MD102", 3, 15, new DateTime(2022, 11, 15), OrderStatus.Purchased);

            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);
            orderList.Add(order4);
            orderList.Add(order5);
            orderList.Add(order6);

        }

    }
}