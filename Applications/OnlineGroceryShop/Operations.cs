using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public static class Operations
    {
        //Lists for stroing the values
        public static CustomList<CustomerDetails> customerCustomList = new CustomList<CustomerDetails>();
        public static CustomList<ProductDetails> productCustomList = new CustomList<ProductDetails>();
        public static CustomList<BookingDetails> bookingCustomList = new CustomList<BookingDetails>();
        public static CustomList<OrderDetails> orderCustomList = new CustomList<OrderDetails>();

        //Global object for storing the details of the currentLoggedInUser
        static CustomerDetails currentLoggedInUser;

        public static void MainMenu()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Welcome to the Online Grocery Shop Application");
            System.Console.WriteLine();
            bool flag = true;

            do
            {
                //Mainmenu Enterance
                System.Console.WriteLine("MainMenu: \n\n1.Registration\n2.Login\n3.Exit");
                System.Console.WriteLine();

                //Getting the mainmenu option from the user
                System.Console.Write("Enter the option from the MainMenu: ");
                //Tryparsing the option
                int mainOption;
                bool tempMainOption = int.TryParse(Console.ReadLine(), out mainOption);
                while (!tempMainOption)
                {
                    System.Console.Write("Invalid Input. Enter a correct option: ");
                    tempMainOption = int.TryParse(Console.ReadLine(), out mainOption);
                }

                //Switching the option to the responding the case
                switch (mainOption)
                {
                    case 1:
                        {
                            //Registration Section
                            System.Console.WriteLine();
                            System.Console.WriteLine("**********************Registration Section**********************");
                            System.Console.WriteLine();
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            //Login Section
                            System.Console.WriteLine("**********************Login Section**********************");
                            System.Console.WriteLine();
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            //Changing the flag to false
                            flag = false;
                            System.Console.WriteLine("Thank you for reaching US. Have Nice Day!!!");
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Input :( ");
                            System.Console.WriteLine();
                            break;
                        }
                }
            } while (flag);
        }

        public static void UserRegistration()
        {
            //Getting the user details
            System.Console.Write("Enter the Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter your Father Name: ");
            string fatherName = Console.ReadLine();

            System.Console.Write("Enter Your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter the Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            System.Console.Write("Enter the DOB: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            System.Console.Write("Enter the MailID: ");
            string mailID = Console.ReadLine();

            System.Console.Write("Enter the Balance: ");
            int balance = int.Parse(Console.ReadLine());

            bool flag = false;
            do
            {
                //Checking the balance is greater than 50
                if (balance <= 50)
                {
                    System.Console.WriteLine("Minunum balance required RS.50");
                    System.Console.Write("Re-Enter the Balance: ");
                    balance = int.Parse(Console.ReadLine());
                }
                else
                {
                    flag = true;
                }
            } while (!flag);

            //Creating the object for customer
            CustomerDetails customer = new CustomerDetails(balance, name, fatherName, gender, mobileNumber, dob, mailID);

            //Adding the object to the list
            customerCustomList.Add(customer);

            System.Console.WriteLine("You are successfully registered :)\nYour CustomerID is: " + customer.CustomerID);

        }

        public static void UserLogin()
        {
            //Need ask the user ID
            System.Console.Write("Enter your User ID: ");
            string loginID = Console.ReadLine().ToUpper();

            //check whether it is in the CustomCustomList 
            bool isInside = true;
            foreach (CustomerDetails user in customerCustomList)
            {
                if (loginID.Equals(user.CustomerID))
                {
                    isInside = false;

                    //Assigning Current user to global variable
                    currentLoggedInUser = user;
                    System.Console.WriteLine("Welcome! " + currentLoggedInUser.Name + " You are Logged in Successfully :) ");

                    //Need to call SubMenu
                    SubMenu();
                    break;
                }

            }
            //If not print Invalid
            if (isInside)
            {
                System.Console.WriteLine("Invalid user ID or ID is not present ");
            }
        }

        public static void SubMenu()
        {
            bool subFlag = true;
            do
            {
                System.Console.WriteLine("******************SubMenu******************");

                //Need to show SubMenu Options
                System.Console.WriteLine("a.Show Customer Details\nb.Show Product Details\nc.Wallet Recharge\nd.Take Order\ne.Modify Order Quantity\nf.Cancel Order\ng.Show Balance\nh.Exit");

                //Getting User option
                System.Console.Write("Enter the option from SubMenu: ");
                char subOption = char.Parse(Console.ReadLine().ToLower());

                //Switching the suboption to the coresponding case
                switch (subOption)
                {
                    case 'a':
                        {
                            //Show MyProfile
                            System.Console.WriteLine("****************Show Customer Details****************");
                            ShowCustomerDetails();
                            break;
                        }
                    case 'b':
                        {
                            //product Order
                            System.Console.WriteLine("****************Show Product Details****************");
                            ShowProductDetails();
                            break;
                        }
                    case 'c':
                        {
                            //Modify Order
                            System.Console.WriteLine("****************Wallet Recharge****************");
                            WalletRecharge();
                            break;
                        }
                    case 'd':
                        {
                            //Cancel Order
                            System.Console.WriteLine("****************Take Order****************");
                            TakeOrder();
                            break;
                        }
                    case 'e':
                        {
                            //Order History
                            System.Console.WriteLine("****************Modify Order Quantity****************");
                            ModifyOrderQuantity();
                            break;
                        }
                    case 'f':
                        {
                            //Wallet Recharge
                            System.Console.WriteLine("****************Cancel Order****************");
                            CancelOrder();
                            break;
                        }
                    case 'g':
                        {
                            //Show Wallet Balance
                            System.Console.WriteLine("****************Show Balance****************");
                            ShowBalance();
                            break;
                        }
                    case 'h':
                        {
                            System.Console.WriteLine("****************You are Redirected to the Main Menu****************");

                            //Changing the subflag to false
                            subFlag = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Option :( ");
                            System.Console.WriteLine("You Are Redirected to the SubMenu");
                            break;
                        }
                }
                //Iterate till the option is exit

            } while (subFlag);
        }

        public static void ShowCustomerDetails()
        {
            //pring the details of the of customer
            System.Console.WriteLine("CustomerID\tWalletBalance\tName\tFatherName\tGender\tMobile\tDOB\tMailID");
            System.Console.WriteLine($"{currentLoggedInUser.CustomerID}\t{currentLoggedInUser.WalletBalance}\t{currentLoggedInUser.Name}\t{currentLoggedInUser.FatherName}\t{currentLoggedInUser.Gender}\t{currentLoggedInUser.Mobile}\t{currentLoggedInUser.DOB.ToString("dd/MM/yyyy")}\t{currentLoggedInUser.MailID}");
        }

        public static void ShowProductDetails()
        {
            foreach (ProductDetails product in productCustomList)
            {
                //Checking the available product quantity is greaeter than 0
                if (product.QuantityAvailable > 0)
                {
                    //Printing only the products which has available quantity greater than zero
                    System.Console.WriteLine($"{product.ProductID}\t\t{product.ProductName}\t\t\t{product.QuantityAvailable}\t\t\t{product.PricePerQuantity}");
                }
            }
            System.Console.WriteLine();
        }

        public static void WalletRecharge()
        {
            //Getting the amount from the user
            System.Console.Write("Enter the amount to recharge: ");
            int cash = int.Parse(Console.ReadLine());

            //Processing the amount for recharge
            System.Console.WriteLine("Updated wallet balance is: " + currentLoggedInUser.WalletRecharge(cash));
        }

        public static void TakeOrder()
        {
            //Adsking the user to continue
            System.Console.Write("Do you want to purchase(yes/no): ");
            string tocontinue = Console.ReadLine().ToLower();
            if (tocontinue.Equals("yes"))
            {
                //Creating the temp booking object
                BookingDetails booking = new BookingDetails(currentLoggedInUser.CustomerID, 0, DateTime.Now, BookingStatus.Initiated);

                //Creating the temporary customlist
                CustomList<OrderDetails> tempOrderCustomList = new CustomList<OrderDetails>();

                string purchaseMore = "yes";
                int totalPurchaseAmount = 0;

                do
                {

                    System.Console.WriteLine("product ID\tproduct Name\t\tAvailable Quantity\tPrice");

                    foreach (ProductDetails product in productCustomList)
                    {
                        //Checking the available product quantity is greaeter than 0
                        if (product.QuantityAvailable > 0)
                        {
                            //Printing only the products which has available quantity greater than zero
                            System.Console.WriteLine($"{product.ProductID}\t\t{product.ProductName}\t\t\t{product.QuantityAvailable}\t\t\t{product.PricePerQuantity}");
                        }
                    }
                    System.Console.WriteLine();

                    //Getting the product ID
                    System.Console.Write("Enter the productID: ");
                    string userEnteredProductID = Console.ReadLine().ToUpper();

                    bool flag = true;
                    foreach (ProductDetails product in productCustomList)
                    {
                        if (userEnteredProductID.Equals(product.ProductID))
                        {
                            flag = false;
                            
                            //Getting the quntity from the user
                            System.Console.Write("Enter the quantity of the product");
                            int userEnteredquantity = int.Parse(Console.ReadLine());
                            
                            //Checking the quantity is avalible or not
                            if (userEnteredquantity <= product.QuantityAvailable)
                            {
                                //Calculating the total price
                                int priceOfOrder = product.PricePerQuantity * userEnteredquantity;
                                OrderDetails newOrder = new OrderDetails(booking.BookingID, product.ProductID, userEnteredquantity, priceOfOrder);
                                
                                //Adding the orderdetails to the list
                                tempOrderCustomList.Add(newOrder);
                                
                                //Redcing the quanity 
                                product.QuantityAvailable -= userEnteredquantity;
                                System.Console.WriteLine();
                                System.Console.WriteLine("Product successfully added to the cart");
                                System.Console.WriteLine();
                                
                                //Asking the user to purchase more
                                System.Console.Write("Do you purchase more (yes/no): ");
                                purchaseMore = Console.ReadLine().ToLower();
                            }
                            break;
                        }
                    }

                    //For invalid product ID
                    if (flag)
                    {
                        System.Console.WriteLine("Invalid ProductID :( ");
                    }
                } while (purchaseMore.Equals("yes"));

                //Asking the customer to confirm the wsihlist
                System.Console.Write("Do you want to confirm the order (yes/no): ");
                string confirmOrder = Console.ReadLine().ToLower();
                if (confirmOrder.Equals("yes"))
                {
                    foreach (OrderDetails order in tempOrderCustomList)
                    {
                        
                        //Calculating the total amount
                        totalPurchaseAmount += order.PriceOfOrder;
                    }

                    //Checcking the user have th enugh balance to purcahse
                    if (totalPurchaseAmount <= currentLoggedInUser.WalletBalance)
                    {
                        currentLoggedInUser.WalletBalance -= totalPurchaseAmount;
                        
                        //Cahnging the status
                        booking.BookingStatus = BookingStatus.Booked;
                        booking.TotalPrice = totalPurchaseAmount;

                        //Adding the booking details to the list
                        bookingCustomList.Add(booking);

                        orderCustomList.AddRange(tempOrderCustomList);

                        System.Console.WriteLine("Booking successful :) ");
                    }
                    else
                    {
                        while (currentLoggedInUser.WalletBalance >= totalPurchaseAmount)
                        {
                            //For Insufficient balance
                            System.Console.WriteLine("Insufficient account balance recharge with" + totalPurchaseAmount);
                            System.Console.WriteLine("Do you want to recharge (yes/no): ");
                            string toRecharge = Console.ReadLine().ToLower();
                            if (toRecharge.Equals("yes"))
                            {
                                //For recharge
                                currentLoggedInUser.WalletRecharge(totalPurchaseAmount);
                                System.Console.WriteLine("Recharged successfully");
                            }
                        }

                    }
                }
                else
                {
                    foreach (OrderDetails order in tempOrderCustomList)
                    {
                        foreach (ProductDetails product in productCustomList)
                        {
                            if (order.ProductID.Equals(product.ProductID))
                            {
                                //incrating the product quantity
                                product.QuantityAvailable += order.PurchaseCount;

                            }
                        }
                    }
                    System.Console.WriteLine("Cart Removed Successfully");
                }

            }

        }

        public static void ModifyOrderQuantity()
        {
            bool flag = true;
            foreach (BookingDetails bookingHead in bookingCustomList)
            {
                //Checking the customerID and the status
                if (bookingHead.BookingStatus.Equals(BookingStatus.Booked) && currentLoggedInUser.CustomerID.Equals(bookingHead.CustomerID))
                {
                    flag = false;
                    
                    //Printing the booking details
                    System.Console.WriteLine("BookingID\tCustomerID\tTotal Price\tDateOfBooking\tBooking status");
                    foreach (BookingDetails booking in bookingCustomList)
                    {
                        if (booking.BookingStatus.Equals(BookingStatus.Booked) && currentLoggedInUser.CustomerID.Equals(booking.CustomerID))
                        {
                            flag = false;
                            System.Console.WriteLine($"{booking.BookingID}\t\t{booking.CustomerID}\t{booking.TotalPrice}\t{booking.DateofBooking.ToString("dd/MM/yyyy")}\t{booking.BookingStatus}");
                        }
                    }

                    //GEtting the booking ID 
                    System.Console.Write("Enter the bookingID: ");
                    string userEnteredBookingID = Console.ReadLine().ToUpper();
                    bool isTrue = true;
                    foreach (BookingDetails booking in bookingCustomList)
                    {

                        if (booking.BookingID.Equals(userEnteredBookingID))
                        {
                            isTrue = false;
                            foreach (OrderDetails order in orderCustomList)
                            {
                                if (order.BookingID.Equals(booking.BookingID))
                                {
                                    System.Console.WriteLine($"{order.OrderID}\t{order.BookingID}\t{order.ProductID}\t{order.PurchaseCount}\t{order.PriceOfOrder}");
                                }
                            }

                            //Gettingt the orderId to cancel 
                            System.Console.Write("Enter the orderID: ");
                            string userEnteredorderID = Console.ReadLine().ToUpper();
                            bool isOrder = true;
                            foreach (OrderDetails order in orderCustomList)
                            {
                                if (order.OrderID.Equals(userEnteredorderID))
                                {
                                    isOrder = false;

                                    //Getting the price quantity
                                    int pricePerQuanity = order.PriceOfOrder / order.PurchaseCount;
                                    System.Console.Write("Enter the new Quantity of the Product: ");
                                    int userEnteredQuantity = int.Parse(Console.ReadLine());

                                    //Calculating thr new price
                                    int newPrice = userEnteredQuantity * pricePerQuanity;
                                    order.PurchaseCount = userEnteredQuantity;
                                    booking.TotalPrice = booking.TotalPrice - order.PriceOfOrder + newPrice;
                                    order.PriceOfOrder = newPrice;
                                    System.Console.WriteLine("Order Modified Successfully");
                                }
                            }
                            if (isOrder)
                            {
                                System.Console.WriteLine("Invalid Order ID");
                            }
                        }
                    }

                    //for invalid booking ID
                    if (isTrue)
                    {
                        System.Console.WriteLine("Invalid booking id");
                    }
                }
            }

            //If no orders
            if (flag)
            {
                System.Console.WriteLine("You have no order to modify");
            }
        }


        public static void CancelOrder()
        {
            int count = 0;
            foreach (BookingDetails booking in bookingCustomList)
            {
                //Checking the customerID and status
                if (currentLoggedInUser.CustomerID.Equals(booking.CustomerID) && booking.BookingStatus.Equals(BookingStatus.Booked))
                {
                    count = 1;
                    System.Console.WriteLine($"{booking.BookingID}\t{booking.BookingStatus}\t{booking.TotalPrice}\t{booking.DateofBooking.ToString("dd/MM/yyyy")}\t{booking.BookingStatus}\t");
                }
            }
            if (count > 0)
            {
                //getitn the bookingID from the user
                bool flag = true;
                System.Console.Write("Enter the Booking ID to cancel: ");
                string userEnteredBookingID = Console.ReadLine().ToUpper();
                foreach (BookingDetails booking in bookingCustomList)
                {
                    //Checking the id with the list
                    if (booking.BookingID.Equals(userEnteredBookingID))
                    {
                        flag = false;
                        booking.BookingStatus = BookingStatus.Cancelled;
                        currentLoggedInUser.WalletRecharge(booking.TotalPrice);
                        foreach (OrderDetails order in orderCustomList)
                        {
                            foreach (ProductDetails product in productCustomList)
                            {
                                if (order.BookingID.Equals(booking.BookingID) && booking.BookingStatus.Equals(BookingStatus.Booked)&&product.ProductID.Equals(order.ProductID))
                                {
                                    //Increasing teh count
                                    order.PurchaseCount +=product.QuantityAvailable;
                                }
                            }

                        }
                        System.Console.WriteLine("Product Cancelled Sucessfully");
                        break;
                    }
                }
                //For invalid booking ID
                if (flag)
                {
                    System.Console.WriteLine("Invalid Booking ID");
                }
            }
            //If no orders
            else
            {
                System.Console.WriteLine("You have No orders to cancel");
            }
        }
        public static void ShowBalance()
        {
            //Printing the balance
            System.Console.WriteLine("Your Wallet Balance is: " + currentLoggedInUser.WalletBalance);
        }

        public static void AddingDeafaultData()
        {
            //Adding the default data of the customer
            CustomerDetails customer1 = new CustomerDetails(10000, "Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com");
            CustomerDetails customer2 = new CustomerDetails(15000, "Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmail.com");

            customerCustomList.Add(customer1);
            customerCustomList.Add(customer2);

            //Adding the default data of the products

            ProductDetails product1 = new ProductDetails("Sugar", 20, 40);
            ProductDetails product2 = new ProductDetails("Rice", 100, 50);
            ProductDetails product3 = new ProductDetails("Milk", 10, 40);
            ProductDetails product4 = new ProductDetails("Coffee", 10, 10);
            ProductDetails product5 = new ProductDetails("Tea", 10, 10);
            ProductDetails product6 = new ProductDetails("Masala Powder", 10, 20);
            ProductDetails product7 = new ProductDetails("Salt", 10, 10);
            ProductDetails product8 = new ProductDetails("Turmeric Powder", 10, 25);
            ProductDetails product9 = new ProductDetails("Chilli Powder", 10, 20);
            ProductDetails product10 = new ProductDetails("Groundnut Oil", 10, 140);

            productCustomList.Add(product1);
            productCustomList.Add(product2);
            productCustomList.Add(product3);
            productCustomList.Add(product4);
            productCustomList.Add(product5);
            productCustomList.Add(product6);
            productCustomList.Add(product7);
            productCustomList.Add(product8);
            productCustomList.Add(product9);
            productCustomList.Add(product10);

            //Adding the default data of the Booking details

            BookingDetails booking1 = new BookingDetails("CID1001", 220, new DateTime(2022, 07, 26), BookingStatus.Booked);
            BookingDetails booking2 = new BookingDetails("CID1002", 400, new DateTime(2022, 07, 26), BookingStatus.Booked);
            BookingDetails booking3 = new BookingDetails("CID1001", 280, new DateTime(2022, 07, 26), BookingStatus.Cancelled);
            BookingDetails booking4 = new BookingDetails("CID1002", 0, new DateTime(2022, 07, 26), BookingStatus.Initiated);

            bookingCustomList.Add(booking1);
            bookingCustomList.Add(booking2);
            bookingCustomList.Add(booking3);
            bookingCustomList.Add(booking4);

            //Adding the default data of the Order Details

            OrderDetails order1 = new OrderDetails("BID3001", "PID2001", 2, 80);
            OrderDetails order2 = new OrderDetails("BID3001", "PID2002", 2, 100);
            OrderDetails order3 = new OrderDetails("BID3001", "PID2003", 1, 40);
            OrderDetails order4 = new OrderDetails("BID3002", "PID2001", 1, 40);
            OrderDetails order5 = new OrderDetails("BID3002", "PID2002", 4, 200);
            OrderDetails order6 = new OrderDetails("BID3002", "PID2010", 1, 140);
            OrderDetails order7 = new OrderDetails("BID3002", "PID2009", 1, 20);
            OrderDetails order8 = new OrderDetails("BID3003", "PID2002", 2, 100);
            OrderDetails order9 = new OrderDetails("BID3003", "PID2008", 4, 100);
            OrderDetails order10 = new OrderDetails("BID3003", "PID2001", 2, 80);

            orderCustomList.Add(order1);
            orderCustomList.Add(order2);
            orderCustomList.Add(order3);
            orderCustomList.Add(order4);
            orderCustomList.Add(order5);
            orderCustomList.Add(order6);
            orderCustomList.Add(order7);
            orderCustomList.Add(order8);
            orderCustomList.Add(order9);
            orderCustomList.Add(order10);


        }
    }
}