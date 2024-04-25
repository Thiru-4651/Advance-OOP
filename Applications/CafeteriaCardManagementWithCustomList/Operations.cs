using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaCardManagementWithCustomList;

namespace CafteriaCardManagementWithCustomList
{
    public static class Operations
    {
        static UserDetails currentLoggedInUser;
        static CustomList<FoodDetails> FoodList = new CustomList<FoodDetails>();
        static CustomList<UserDetails> UsersList = new CustomList<UserDetails>();
        static CustomList<OrderDetails> OrdersList = new CustomList<OrderDetails>();
        static List<CartItem> CartItemsList = new List<CartItem>();

        //MainMenu 
        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                //Application Enterance
                System.Console.WriteLine();
                System.Console.WriteLine("***************************Weclome TO The Cafeteria Appliation***************************");
                System.Console.WriteLine();

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
        }//MainMenu Ends

        //Registration
        public static void UserRegistration()
        {
            //Getting the user details
            System.Console.Write("Enter the Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter your Father Name: ");
            string fatherName = Console.ReadLine();

            System.Console.Write("Enter the Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.Write("Enter the MailID: ");
            string mailID = Console.ReadLine();

            System.Console.Write("Enter Your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter the Work Station Number: ");
            string workStationNumber = Console.ReadLine();

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

            //creating the object with input details
            UserDetails user = new UserDetails(name, fatherName, mobileNumber, mailID, gender, workStationNumber, balance);

            //Adding the user details to the list
            UsersList.Add(user);

            //showing auto generated usedID to the user
            System.Console.WriteLine("You are successfully registered :)\nYour UserID is: " + user.UserID);

        }//Registration ends

        //Login
        public static void UserLogin()
        {
            //Need ask the user ID
            System.Console.Write("Enter your User ID: ");
            string loginID = Console.ReadLine().ToUpper();

            //check whether it is in the list 
            bool isInside = true;
            foreach (UserDetails user in UsersList)
            {
                if (loginID.Equals(user.UserID))
                {
                    isInside = false;

                    //Assigning Current user to global variable
                    currentLoggedInUser = user;
                    System.Console.WriteLine("Welcome! " + currentLoggedInUser.Name + " You are Logged in Successfully :) ");

                    //Need to call SubMenu
                    Submenu();
                    break;
                }

            }
            //If not print Invalid
            if (isInside)
            {
                System.Console.WriteLine("Invalid user ID or ID is not present ");
            }

        }//Login ends

        //Submenu
        public static void Submenu()
        {
            bool subFlag = true;
            do
            {
                System.Console.WriteLine("******************SubMenu******************");

                //Need to show SubMenu Options
                System.Console.WriteLine("a.Show MyProfile\nb.Food Order\nc.Modify Order\nd.Cancel Order\ne.Order History\nf.Wallet Recharge\ng.Show Wallet Balance\nh.Exit");

                //Getting User option
                System.Console.Write("Enter the option from SubMenu: ");
                char subOption = char.Parse(Console.ReadLine().ToLower());

                //Switching the suboption to the coresponding case
                switch (subOption)
                {
                    case 'a':
                        {
                            //Show MyProfile
                            System.Console.WriteLine("****************Show MyProfile****************");
                            ShowMyProfile();
                            break;
                        }
                    case 'b':
                        {
                            //Food Order
                            System.Console.WriteLine("****************Food Order****************");
                            FoodOrder();
                            break;
                        }
                    case 'c':
                        {
                            //Modify Order
                            System.Console.WriteLine("****************Modify Order****************");
                            ModifyOrder();
                            break;
                        }
                    case 'd':
                        {
                            //Cancel Order
                            System.Console.WriteLine("****************Cancel Order****************");
                            CancelOrder();
                            break;
                        }
                    case 'e':
                        {
                            //Order History
                            System.Console.WriteLine("****************Order History****************");
                            OrderHistory();
                            break;
                        }
                    case 'f':
                        {
                            //Wallet Recharge
                            System.Console.WriteLine("****************Wallet Recharge****************");
                            WalletRecharge();
                            break;
                        }
                    case 'g':
                        {
                            //Show Wallet Balance
                            System.Console.WriteLine("****************Show Wallet Balance****************");
                            ShowWalletBalance();
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
        }//Submenu ends

        //Show MyProfile 
        public static void ShowMyProfile()
        {
            //Printing the heading of the user details
            System.Console.WriteLine("UserID\tUserName\tFatherName\tMobileNumber\tMailID\t\tGender\tWorkStationNumber\tBalance");
            foreach (UserDetails user in UsersList)
            {
                if (user.Equals(currentLoggedInUser))
                {
                    //Printing the user details
                    System.Console.WriteLine($"{user.UserID}\t{user.Name}\t{user.FatherName}\t{user.PhoneNumber}\t{user.MailID}\t{user.Gender}\t{user.WorkStationNumber}\t\t\t{user.WalletBalance}");
                    break;
                }
            }
            System.Console.WriteLine();
        }//Show MyProfile ends

        //Food Order
        public static void FoodOrder()
        {
            string toCountinue = "";

            //Local Cartitem List creation
            List<CartItem> localCartItem = new List<CartItem>();

            //New order object creation
            OrderDetails newOrder = new OrderDetails(currentLoggedInUser.UserID, DateTime.Now, 0, OrderStatus.Initiated);

            int userTotalPrice = 0;
            int cartItemTotalPrice = 0;
            do
            {

                System.Console.WriteLine();

                //Headings of the food details
                System.Console.WriteLine("Food ID\tFood Name\tPrice\tAvailable Quantity");

                foreach (FoodDetails food in FoodList)
                {
                    //Checking the available food quantity is greaeter than 0
                    if (food.AvailableQuantity > 0)
                    {
                        //Printing only the foods which has available quantity greater than zero
                        System.Console.WriteLine($"{food.FoodID}\t{food.FoodName}\t\t{food.FoodPrice}\t{food.AvailableQuantity}");
                    }
                }
                System.Console.WriteLine();

                //Getting thhe food id from the user and stroing it
                System.Console.Write("Enter the FoodID from above List: ");
                string userEnteredFoodID = Console.ReadLine().ToUpper();

                //Getting thhe food id from the user and stroing it
                System.Console.Write("Enter the amount of quantity: ");
                int userEnteredQuantity = int.Parse(Console.ReadLine());

                //Traversing the userEnteredFoodID 
                bool flag = true;
                foreach (FoodDetails food in FoodList)
                {
                    //checking the userEnteredFoodID is available on the foodlist 
                    if (food.FoodID.Equals(userEnteredFoodID))
                    {
                        flag = false;

                        //Checking the available quantity is greater than userEnteredQuantity
                        if (food.AvailableQuantity >= userEnteredQuantity)
                        {
                            //Calculating the total price
                            userTotalPrice += food.FoodPrice * userEnteredQuantity;

                            //Reducing the quantity
                            food.AvailableQuantity -= userEnteredQuantity;

                            CartItem wishList = new CartItem(newOrder.OrderID, food.FoodID, food.FoodPrice, userEnteredQuantity);

                            localCartItem.Add(wishList);
                        }

                        //printing available is quanity was less
                        else
                        {
                            System.Console.WriteLine("Quantity not available. Only " + food.AvailableQuantity + " was available");
                        }
                    }
                }

                //Printing the invalid user ID
                if (flag)
                {
                    System.Console.WriteLine("Invalid User ID :( ");
                }

                //Asking the user if they want to purchase more
                System.Console.Write("Do You Want to purchase more thing (yes/no): ");
                toCountinue = Console.ReadLine().ToLower();

                //Iterating until user select no
            } while (toCountinue == "yes");

            //Asking the user to purchase the cartitems
            System.Console.Write("Do you want the purchase the things in Cart (yes/no): ");
            string wishListInput = Console.ReadLine().ToLower();

            //Checking the wishListInput is "yes"
            if (wishListInput == "yes")
            {
                //Traversing the cart to get the total price
                foreach (CartItem cartItem in localCartItem)
                {
                    cartItemTotalPrice += cartItem.OrderPrice * cartItem.OrderQuantity;
                }

                //Checking the total price was less than user wallet balance
                if (cartItemTotalPrice <= currentLoggedInUser.WalletBalance)
                {
                    //Reducing the cart amount form the current user balnce
                    currentLoggedInUser.DeductAmount(cartItemTotalPrice);

                    //Adding the local cartitem list to the global cartitem list
                    CartItemsList.AddRange(localCartItem);

                    //Adding the total price to the order list
                    newOrder.TotalPrice = cartItemTotalPrice;

                    //Changing the status of the order to orderd
                    newOrder.OrderStatus = OrderStatus.Ordered;

                    //Adding the neworder object to the order list
                    OrdersList.Add(newOrder);

                    //Order Placed successful message
                    System.Console.WriteLine("Your order placed successfully and your OrderID is: " + newOrder.OrderID);
                    System.Console.WriteLine();

                }
                else
                {
                    //Printing the insufficient balance with asking willing to recharge
                    System.Console.Write("You didn't have enough balance to purchase\nAre you willing to recharge " + cartItemTotalPrice + " (yes/no): ");
                    string userRechargeInput = Console.ReadLine().ToLower();

                    //Checking the userRechargeInput
                    if (userRechargeInput == "yes")
                    {
                        //Recharging the amount to the user wallet balance
                        currentLoggedInUser.WalletRecharge(cartItemTotalPrice);

                        //Reducing the cart amount form the current user balnce
                        currentLoggedInUser.WalletBalance -= cartItemTotalPrice;

                        //Adding the local cartitem list to the global cartitem list
                        CartItemsList.AddRange(localCartItem);

                        //Adding the total price to the order list
                        newOrder.TotalPrice = cartItemTotalPrice;

                        //Changing the status of the order to orderd
                        newOrder.OrderStatus = OrderStatus.Ordered;

                        //Adding the neworder object to the order list
                        OrdersList.Add(newOrder);

                        //Order Placed successful message
                        System.Console.WriteLine("Your order placed successfully and your OrderID is: " + newOrder.OrderID);
                        System.Console.WriteLine();

                    }
                    else
                    {
                        //printing the user exited with insufficient balance
                        System.Console.WriteLine("Exiting without Order due to insufficient balance");
                        System.Console.WriteLine();

                        //Travering the both cartItem and foodlist to return the quantity
                        foreach (CartItem cartItem in localCartItem)
                        {
                            foreach (FoodDetails food in FoodList)
                            {
                                if (food.FoodID.Equals(cartItem.FoodID))
                                {
                                    //Returning the availble quentity in the food list
                                    food.AvailableQuantity += cartItem.OrderQuantity;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //Travering the both cartItem and foodlist to return the quantity
                foreach (CartItem cartItem in localCartItem)
                {
                    foreach (FoodDetails food in FoodList)
                    {
                        if (food.FoodID.Equals(cartItem.FoodID))
                        {
                            //Returning the availble quentity in the food list
                            food.AvailableQuantity += cartItem.OrderQuantity;
                        }
                    }
                }
            }


        }//Food Order ends

        //ModifyOrder 
        public static void ModifyOrder()
        {
            bool flag = true;
            //Traversing orderlist 
            foreach (OrderDetails order1 in OrdersList)
            {
                //Checking the currentLoggedInUser with OrderStatus Ordered
                if (order1.OrderStatus.Equals(OrderStatus.Ordered) && currentLoggedInUser.UserID.Equals(order1.UserID))
                {
                    //If true then printing the order List headings
                    flag = false;
                    System.Console.WriteLine();
                    System.Console.WriteLine("OrderID\tUserID\tOrderDate\tTotal Price\tOrder Status");
                    foreach (OrderDetails order in OrdersList)
                    {
                        if (order.OrderStatus.Equals(OrderStatus.Ordered) && currentLoggedInUser.UserID.Equals(order.UserID))
                        {
                            //If true then printing the ordered list of the customer
                            System.Console.WriteLine($"{order.OrderID}\t{order.UserID}\t{order.OrderDate.ToString("dd/MM/yyyy")}\t{order.TotalPrice}\t\t{order.OrderStatus}");
                            System.Console.WriteLine();
                        }
                    }

                    //If true then printing the order CartItem List headings
                    System.Console.WriteLine("ItemID\tOrderID\tFoodID\tOrder Price\tOrder Quantity");

                    foreach (CartItem cartItem in CartItemsList)
                    {
                        if (cartItem.OrderID.Equals(order1.OrderID))
                        {
                            //If true then printing the cartItem list of the customer
                            System.Console.WriteLine($"{cartItem.ItemID}\t{cartItem.OrderID}\t{cartItem.FoodID}\t{cartItem.OrderPrice}\t\t{cartItem.OrderQuantity}");
                        }
                    }
                    System.Console.WriteLine();

                    //Asking the user to get the itemID from the cartItem list
                    System.Console.Write("Enter the itemID: ");
                    string userEnteredItemID = Console.ReadLine().ToUpper();

                    bool isTrue = true;
                    int newPrice = 0;
                    int totalCartPrice = 0;

                    //Traversing the CartItem list 
                    foreach (CartItem cartitem in CartItemsList)
                    {
                        //Checking the userEnteredItemID cartItem ID
                        if (userEnteredItemID.Equals(cartitem.ItemID))
                        {
                            isTrue = false;

                            //Asking the user to get the quantity of food
                            System.Console.Write("Enter the new quantity of the food: ");
                            int newQuantity = int.Parse(Console.ReadLine());

                            //Assiging the newQuanity to the  OrderQuantity
                            cartitem.OrderQuantity = newQuantity;

                            //Traversing foodlist
                            foreach (FoodDetails food in FoodList)
                            {
                                //Checking the food id with the cartitem food id
                                if (cartitem.FoodID.Equals(food.FoodID))
                                {
                                    //Assiging the foodprice to the new price
                                    newPrice = food.FoodPrice;
                                    break;
                                }
                            }

                            //Calculating the orderprice with newquantity and newprice
                            int orderPrice = newQuantity * newPrice;

                            //Assinging new price to cartItem list
                            cartitem.OrderPrice = orderPrice;

                            //Traversing the cartItemList to Calculate the totalprice with the cart orderprice
                            foreach (CartItem cart in CartItemsList)
                            {
                                //Checking the orderID with the cart orderID
                                if (cartitem.OrderID.Equals(cart.OrderID))
                                {
                                    //Calculating the totalprice with the cart orderprice
                                    totalCartPrice += cart.OrderPrice;
                                }
                            }

                            //Traversing the orderList
                            foreach (OrderDetails order in OrdersList)
                            {
                                //Checking the orderID with the cartitem orderID
                                if (order.OrderID.Equals(cartitem.OrderID))
                                {
                                    //Assiging the total cart price to the order total price
                                    order.TotalPrice = totalCartPrice;
                                }
                            }

                            //Pring the successfull message
                            System.Console.WriteLine("Order Modified Successfully :) ");
                            break;
                        }
                    }

                    //If the item ID not present in the list
                    if (isTrue)
                    {
                        System.Console.WriteLine("Invalid ItemID :( ");
                    }
                }

            }
            //If no orders then no order message printing
            if (flag)
            {
                System.Console.WriteLine("You have no order to Modify :( ");
            }

        }//ModifyOrder ends

        //CancelOrder 
        public static void CancelOrder()
        {
            bool flag = true;

            //For checking the whether user ordered atleast one order or not
            foreach (OrderDetails order1 in OrdersList)
            {
                if (order1.OrderStatus.Equals(OrderStatus.Ordered) && currentLoggedInUser.UserID.Equals(order1.UserID))
                {
                    //If true then printing the order history headings
                    flag = false;
                    System.Console.WriteLine();
                    System.Console.WriteLine("OrderID\tUserID\tOrderDate\tTotal Price\tOrder Status");

                    //Traversing the orderList
                    foreach (OrderDetails order in OrdersList)
                    {
                        //Checking the currentLoggedInUser ID with the orderstatus orderd
                        if (order.OrderStatus.Equals(OrderStatus.Ordered) && currentLoggedInUser.UserID.Equals(order.UserID))
                        {
                            //If true then printing the ordered list of the customer
                            System.Console.WriteLine($"{order.OrderID}\t{order.UserID}\t{order.OrderDate.ToString("dd/MM/yyyy")}\t{order.TotalPrice}\t\t{order.OrderStatus}");
                            System.Console.WriteLine();

                            //Asking the orderID to the user
                            System.Console.Write("Enter the orderID to cancel: ");
                            string userEnteredOrderID = Console.ReadLine();
                            bool isTrue = true;

                            //Traversing the orderList 
                            foreach (OrderDetails order2 in OrdersList)
                            {
                                //Checking the orderid with the userEnteredOrderID
                                if (order2.OrderID.Equals(userEnteredOrderID))
                                {
                                    isTrue = false;

                                    //Increasing the wallet balance
                                    currentLoggedInUser.WalletRecharge(order2.TotalPrice);

                                    //changing orderstatus to the cancelled
                                    order2.OrderStatus = OrderStatus.Cancelled;

                                    //Traversing the both food and cartItem list
                                    foreach (FoodDetails food in FoodList)
                                    {
                                        foreach (CartItem cartitem in CartItemsList)
                                        {
                                            //checking the orderID with the food ID
                                            if (cartitem.OrderID.Equals(order2.OrderID) && food.FoodID.Equals(cartitem.FoodID))
                                            {
                                                //Increasing the food availble quantity 
                                                food.AvailableQuantity += cartitem.OrderQuantity;
                                            }
                                        }
                                    }

                                    //Printing the ordercancelled successful message
                                    System.Console.WriteLine("Order Cancelled Successfully");
                                    System.Console.WriteLine();
                                    break;
                                }
                            }

                            // if Order id not present in the list
                            if (isTrue)
                            {
                                System.Console.WriteLine("Invalid Order ID :( ");
                                System.Console.WriteLine("*****************************You are Rediracted to SubMenu*****************************");
                                System.Console.WriteLine();
                            }
                        }
                    }
                    break;
                }
            }
            //If false printing you have no orders to show
            if (flag)
            {
                System.Console.WriteLine("You have no order to Cancel :( ");
            }
        }//CancelOrder ends

        //OrderHistory 
        public static void OrderHistory()
        {
            bool flag = false;

            //For checking the whether user ordered atleast one order or not
            foreach (OrderDetails order1 in OrdersList)
            {
                if (order1.UserID.Equals(currentLoggedInUser.UserID))
                {
                    //If true then printing the order history headings
                    flag = true;
                    System.Console.WriteLine();
                    System.Console.WriteLine("OrderID\tUserID\tOrderDate\tTotal Price\tOrder Status");
                    foreach (OrderDetails order in OrdersList)
                    {
                        if (order.UserID.Equals(currentLoggedInUser.UserID))
                        {
                            //If true then printing the order history of the customer

                            System.Console.WriteLine($"{order.OrderID}\t{order.UserID}\t{order.OrderDate.ToString("dd/MM/yyyy")}\t{order.TotalPrice}\t\t{order.OrderStatus}");
                            System.Console.WriteLine();
                        }
                    }
                    break;
                }
            }

            //If false printing you have no orders to show
            if (!flag)
            {
                System.Console.WriteLine("You havn't placed no order to show :( ");
            }
        }//OrderHistory ends

        //WalletRecharge 
        public static void WalletRecharge()
        {
            //Asking the user for deposit cash
            System.Console.Write("Enter the cash to deposit: ");
            int cash = int.Parse(Console.ReadLine());

            //Printing the updated the balance
            System.Console.WriteLine("Your Updated Balance is: " + currentLoggedInUser.WalletRecharge(cash));
            System.Console.WriteLine();
        }//WalletRecharge ends

        //Show Wallet Balance 
        public static void ShowWalletBalance()
        {
            //Printing the wallet balance
            System.Console.WriteLine("Your Account Balance is: " + currentLoggedInUser.WalletBalance);
            System.Console.WriteLine();
        }//Show Wallet Balance ends

        //Adding Default Data
        public static void AddingDefaultData()
        {
            //Creating the food objects with default details

            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            FoodDetails food3 = new FoodDetails("Biscuit", 10, 100);
            FoodDetails food4 = new FoodDetails("Juice", 50, 100);
            FoodDetails food5 = new FoodDetails("Puff", 40, 100);
            FoodDetails food6 = new FoodDetails("Milk", 10, 100);
            FoodDetails food7 = new FoodDetails("Popcorn", 20, 20);

            //Adding Default Food Details

            FoodList.Add(food1);
            FoodList.Add(food2);
            FoodList.Add(food3);
            FoodList.Add(food4);
            FoodList.Add(food5);
            FoodList.Add(food6);
            FoodList.Add(food7);

            //Creating the user objects with default details

            UserDetails user1 = new UserDetails("Ravichandran", "Ettapparajan", 8857777575, "ravi@gmail.com", Gender.Male, "WS101", 400);
            UserDetails user2 = new UserDetails("Baskaran", "Sethurajan", 9577747744, "baskaran@gmail.com", Gender.Male, "WS105", 500);

            //Adding default User Details
            UsersList.Add(user1);
            UsersList.Add(user2);

            //Creating the order objects with default details

            OrderDetails order1 = new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("SF1002", new DateTime(2022, 06, 15), 100, OrderStatus.Ordered);

            //Adding Default order details

            OrdersList.Add(order1);
            OrdersList.Add(order2);

            //Creating the caritem objects with default details

            CartItem cartItem1 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cartItem2 = new CartItem("OID1001", "FID103", 10, 1);
            CartItem cartItem3 = new CartItem("OID1001", "FID105", 40, 1);
            CartItem cartItem4 = new CartItem("OID1002", "FID103", 10, 1);
            CartItem cartItem5 = new CartItem("OID1002", "FID104", 50, 1);
            CartItem cartItem6 = new CartItem("OID1002", "FID105", 40, 1);

            //Adding default cart item details

            CartItemsList.Add(cartItem1);
            CartItemsList.Add(cartItem2);
            CartItemsList.Add(cartItem3);
            CartItemsList.Add(cartItem4);
            CartItemsList.Add(cartItem5);
            CartItemsList.Add(cartItem6);


        }
    }
}