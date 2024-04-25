using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class Operations
    {
        //Custom List for Customer Details
        public static CustomList<CustomerDetails> customerCustomList = new CustomList<CustomerDetails>();
        
        //Custom List for Food Details
        public static CustomList<FoodDetails> foodCustomList = new CustomList<FoodDetails>();
        
        //Custom List for order Details
        public static CustomList<OrderDetails> orderCustomList = new CustomList<OrderDetails>();
        
        //Custom List for Item Details
        public static CustomList<ItemDetails> itemCustomList = new CustomList<ItemDetails>();

        //Global object for currentLoggedInCustomer
        static CustomerDetails currentLoggedInCustomer;

        public static void MainMenu()
        {
            //Mainmenu Entrance
            System.Console.WriteLine("Food Delivery Application\n");
            bool flag = true;
            do
            {
                System.Console.WriteLine("Mainmenu\n1.Customer Registration\n2.Customer Login\n3.Exit");
                System.Console.Write("Enter the option from MainMenu: ");
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine();
                            CustomerRegistration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine();
                            CustomerLogin();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            System.Console.WriteLine("Thank You!");
                            break;
                        }
                }
            } while (flag);
        }

        public static void CustomerRegistration()
        {
            System.Console.Write("Enter name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter Fathername: ");
            string fatherName = Console.ReadLine();

            System.Console.Write("Enter Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter MobileNumber: ");
            string mobile = Console.ReadLine();

            System.Console.Write("Enter DOB(dd/MM/yyyy): ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            System.Console.Write("Enter the MailID: ");
            string mailID = Console.ReadLine();

            System.Console.Write("Enter the location: ");
            string location = Console.ReadLine();

            System.Console.Write("Enter you WalletBalance: ");
            int balance = int.Parse(Console.ReadLine());

            CustomerDetails customer = new CustomerDetails(balance, name, fatherName, gender, mobile, dob, mailID, location);

            customerCustomList.Add(customer);

            System.Console.WriteLine("Customer registration successful Your Customer ID: " + customer.CustomerID);
        }

        public static void CustomerLogin()
        {
            System.Console.Write("Enter the CustomerID: ");
            string userEnteredCustomerID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (CustomerDetails customer in customerCustomList)
            {
                if (userEnteredCustomerID.Equals(customer.CustomerID))
                {
                    currentLoggedInCustomer = customer;
                    System.Console.WriteLine($"Welcome! {currentLoggedInCustomer.Name} you are Logged In Successfully\n");
                    flag = false;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid User ID\n");
            }
        }

        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("SubMenu:\n1.ShowMyProfile\n2.Order Food\n3.Cancel Order\n4.Modify Order\n5.Order History\n6.Recharge Wallet\n7.Show Wallet Balance\n8.Exit");
                System.Console.Write("Enter the Option: ");
                int subOption = int.Parse(Console.ReadLine());

                switch (subOption)
                {
                    case 1:
                        {
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            RechargeWallet();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            flag = false;
                            System.Console.WriteLine("Rediretected to the mainmenu");
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Option");
                            break;
                        }
                }
            } while (flag);
        }

        public static void ShowMyProfile()
        {
            System.Console.WriteLine($"{currentLoggedInCustomer.CustomerID}\n{currentLoggedInCustomer.Name}\n{currentLoggedInCustomer.FatherName}\n{currentLoggedInCustomer.Gender}\n{currentLoggedInCustomer.Mobile}\n{currentLoggedInCustomer.DOB.ToString("dd/MM/yyyy")}\n{currentLoggedInCustomer.MailID}\n{currentLoggedInCustomer.Location}\n");
        }

        public static void OrderFood()
        {
            OrderDetails neworder = new OrderDetails(currentLoggedInCustomer.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);

            CustomList<ItemDetails> localItemCustomList = new CustomList<ItemDetails>();

            string orderMore = "yes";

            int TotalPurchaseAmount = 0;

            do
            {

                foreach (FoodDetails food in foodCustomList)
                {
                    if (food.QuantityAvailable > 0)
                    {
                        System.Console.WriteLine($"FoodID: {food.FoodID}\tFoodName: {food.FoodName}\t\t\tPricePerQuantity: {food.PricePerQuantity}\tQuantityAvailable: {food.QuantityAvailable}");
                    }
                }

                System.Console.WriteLine("Enter the FoodID: ");
                string userEnteredFoodID = Console.ReadLine().ToUpper();

                bool foodIDcheck = true;
                //bool foodQuantitycheck=true;

                foreach (FoodDetails food in foodCustomList)
                {
                    if (userEnteredFoodID.Equals(food.FoodID))
                    {
                        foodIDcheck = false;
                        System.Console.Write("Enter the Order Quantity: ");
                        int userEnteredFoodQuantity = int.Parse(Console.ReadLine());
                        if (userEnteredFoodQuantity <= food.QuantityAvailable)
                        {
                            int priceOfOrder = userEnteredFoodQuantity * food.PricePerQuantity;
                            //foodQuantitycheck=false;
                            ItemDetails newItem = new ItemDetails(neworder.OrderID, userEnteredFoodID, userEnteredFoodQuantity, priceOfOrder);

                            food.QuantityAvailable -= userEnteredFoodQuantity;

                            localItemCustomList.Add(newItem);

                            System.Console.Write("Do you want to order more (yes/no): ");
                            orderMore = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            System.Console.WriteLine("FoodQuantity unavailable");
                        }

                        break;
                    }
                }
                if (foodIDcheck)
                {
                    System.Console.WriteLine("Invalid Food ID");
                }
            } while (orderMore == "yes");

            System.Console.WriteLine("Do you want to confirm purchase (yes/no): ");
            string confirmPurchase = Console.ReadLine().ToLower();
            if (confirmPurchase == "yes")
            {
                foreach (ItemDetails item in localItemCustomList)
                {
                    TotalPurchaseAmount += item.PriceOfOrder;
                }
                bool flag = true;
                do
                {

                    if (TotalPurchaseAmount <= currentLoggedInCustomer.WalletBalance)
                    {
                        flag = false;
                        neworder.TotalPrice = TotalPurchaseAmount;
                        neworder.OrderStatus = OrderStatus.Ordered;

                        currentLoggedInCustomer.DeductBalance(TotalPurchaseAmount);

                        itemCustomList.AddRange(localItemCustomList);
                        orderCustomList.Add(neworder);
                        System.Console.WriteLine("Order Successfully placed\n");
                    }
                    else
                    {
                        System.Console.Write("Insufficient Balance.Do you want Recharge (yes/no): ");
                        string toRecharge = Console.ReadLine().ToLower();
                        if (toRecharge == "yes")
                        {
                            System.Console.WriteLine("Enter the amount to be Recharge: ");
                            int rechargeAmount = int.Parse(Console.ReadLine());
                            currentLoggedInCustomer.WalletRecharge(rechargeAmount);
                        }
                        else
                        {
                            foreach (ItemDetails item in localItemCustomList)
                            {
                                foreach (FoodDetails food in foodCustomList)
                                {
                                    if (food.FoodID.Equals(item.FoodID))
                                    {
                                        food.QuantityAvailable += item.PurchaseCount;
                                    }
                                }
                            }
                            break;
                        }
                    }
                } while (flag);
            }
            else
            {
                foreach (ItemDetails item in localItemCustomList)
                {
                    foreach (FoodDetails food in foodCustomList)
                    {
                        if (food.FoodID.Equals(item.FoodID))
                        {
                            food.QuantityAvailable += item.PurchaseCount;
                        }
                    }
                }
            }
        }
        public static void CancelOrder()
        {
            int count = 0;
            foreach (OrderDetails order in orderCustomList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    count++;
                    System.Console.WriteLine($"{order.OrderID}\t{order.CustomerID}\t{order.TotalPrice}\t{order.DateOfOrder.ToString("dd/MM/yyyy")}\t{order.OrderStatus}");
                }
            }
            if (count > 0)
            {
                System.Console.WriteLine("Enter the orderID");
                string userEnteredOrderID = Console.ReadLine().ToUpper();
                foreach (OrderDetails order1 in orderCustomList)
                {
                    if (currentLoggedInCustomer.CustomerID.Equals(order1.CustomerID) && order1.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        order1.OrderStatus = OrderStatus.Cancelled;
                        currentLoggedInCustomer.WalletRecharge(order1.TotalPrice);
                        foreach (ItemDetails item in itemCustomList)
                        {
                            foreach (FoodDetails food in foodCustomList)
                            {
                                if (order1.OrderID.Equals(item.OrderID) && item.FoodID.Equals(food.FoodID))
                                {
                                    int orderQuantity = item.PriceOfOrder / food.PricePerQuantity;
                                    food.QuantityAvailable += orderQuantity;
                                }
                            }
                        }
                        System.Console.WriteLine("Order cancelled successfully");
                    }

                }
            }
            else
            {
                System.Console.WriteLine("you have no orders to cancel");
            }
        }
        public static void ModifyOrder()
        {
            int count = 0;

            foreach (OrderDetails order in orderCustomList)
            {
                if (currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    count++;
                    System.Console.WriteLine($"{order.OrderID}\t{order.CustomerID}\t{order.TotalPrice}\t{order.DateOfOrder.ToString("dd/MM/yyyy")}\t{order.OrderStatus}");
                }
            }
            if (count > 0)
            {
                System.Console.WriteLine("Enter the orderID");
                string userEnteredOrderID = Console.ReadLine().ToUpper();
                foreach (OrderDetails order1 in orderCustomList)
                {
                    if (currentLoggedInCustomer.CustomerID.Equals(order1.CustomerID) && order1.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        foreach (ItemDetails item in itemCustomList)
                        {
                            if (item.OrderID.Equals(order1.OrderID))
                            {
                                System.Console.WriteLine($"{item.ItemID}\t{item.OrderID}\t{item.FoodID}\t{item.PurchaseCount}\t{item.PriceOfOrder}");
                            }
                        }

                        System.Console.Write("Enter the ItemID: ");
                        string userEnteredItemID = Console.ReadLine().ToUpper();
                        bool flag = true;
                        foreach (ItemDetails item1 in itemCustomList)
                        {
                            if (item1.ItemID.Equals(userEnteredItemID))
                            {
                                flag = false;
                                System.Console.Write("Enter the new Quantity: ");
                                int newQuantity = int.Parse(Console.ReadLine());

                                if (newQuantity > item1.PurchaseCount)
                                {
                                    int pricePerQuantity = item1.PriceOfOrder / item1.PurchaseCount;
                                    int increasedQuanity = newQuantity - item1.PurchaseCount;
                                    int newPrice = increasedQuanity * pricePerQuantity;

                                    bool flag1 = true;
                                    do
                                    {
                                        if (newPrice <= currentLoggedInCustomer.WalletBalance)
                                        {
                                            flag1 = false;
                                            currentLoggedInCustomer.DeductBalance(newPrice);
                                            item1.PriceOfOrder += newPrice;
                                            item1.PurchaseCount = newQuantity;

                                            int newTotalAmount = 0;
                                            foreach (OrderDetails order in orderCustomList)
                                            {
                                                foreach (ItemDetails item in itemCustomList)
                                                {
                                                    if (order.OrderID.Equals(item.OrderID) && currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                                                    {
                                                        newTotalAmount += item.PriceOfOrder;

                                                    }
                                                }

                                            }
                                            foreach (OrderDetails order in orderCustomList)
                                            {
                                                if (order.OrderID.Equals(item1.OrderID))
                                                {
                                                    order.TotalPrice = newTotalAmount;
                                                    break;
                                                }
                                            }
                                            System.Console.WriteLine("Order Modified successfully");

                                        }
                                        else
                                        {
                                            System.Console.Write("Insufficient Balance.Do you want Recharge (yes/no): ");
                                            string toRecharge = Console.ReadLine().ToLower();
                                            if (toRecharge == "yes")
                                            {
                                                System.Console.WriteLine("Enter the amount to be Recharge: ");
                                                int rechargeAmount = int.Parse(Console.ReadLine());
                                                currentLoggedInCustomer.WalletRecharge(rechargeAmount);
                                            }
                                        }
                                    } while (flag1);
                                }
                                else if (newQuantity < item1.PurchaseCount)
                                {
                                    int pricePerQuantity = item1.PriceOfOrder / item1.PurchaseCount;
                                    int decreasedQuanity = item1.PurchaseCount - newQuantity;
                                    int newPrice = decreasedQuanity * pricePerQuantity;
                                    currentLoggedInCustomer.WalletRecharge(newPrice);

                                    item1.PurchaseCount = decreasedQuanity;
                                    item1.PriceOfOrder -= newPrice;

                                    int newTotalAmount = 0;
                                    foreach (OrderDetails order in orderCustomList)
                                    {
                                        foreach (ItemDetails item in itemCustomList)
                                        {
                                            if (order.OrderID.Equals(item.OrderID) && currentLoggedInCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                                            {
                                                newTotalAmount += item.PriceOfOrder;

                                            }
                                        }

                                    }
                                    foreach (OrderDetails order in orderCustomList)
                                    {
                                        if (order.OrderID.Equals(item1.OrderID))
                                        {
                                            order.TotalPrice = newTotalAmount;
                                            break;
                                        }
                                    }
                                    System.Console.WriteLine("Order Modified successfully");

                                }
                                else
                                {
                                    System.Console.WriteLine("Same Quanity Entered");
                                }
                                break;
                            }
                        }
                        if (flag)
                        {
                            System.Console.WriteLine("Invaild ItemID");
                        }
                        break;
                    }
                }
            }
            else
            {
                System.Console.WriteLine("You have no ordere to Modify");
            }
        }
        public static void OrderHistory()
        {
            int count = 0;
            foreach (OrderDetails order in orderCustomList)
            {
                if (order.CustomerID.Equals(currentLoggedInCustomer.CustomerID))
                {
                    count = 1;
                    System.Console.WriteLine($"{order.OrderID}\t{order.CustomerID}\t{order.TotalPrice}\t{order.DateOfOrder.ToString("dd/MM/yyyy")}\t{order.OrderStatus}");
                }
            }
            if (count == 0)
            {
                System.Console.WriteLine("You have no order history\n");
            }
        }
        public static void RechargeWallet()
        {
            System.Console.WriteLine("Enter the amount to be Recharged: ");
            int rechargeAmount = int.Parse(Console.ReadLine());
            currentLoggedInCustomer.WalletRecharge(rechargeAmount);
        }
        public static void ShowWalletBalance()
        {
            System.Console.WriteLine("Your WalletBalance is: " + currentLoggedInCustomer.WalletBalance);
            System.Console.WriteLine();
        }
        public static void AddingDefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails(10000, "Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai");
            CustomerDetails customer2 = new CustomerDetails(15000, "Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai");

            customerCustomList.Add(customer1);
            customerCustomList.Add(customer2);

            FoodDetails food1 = new FoodDetails("Chicken Briyani 1Kg", 100, 12);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1Kg", 150, 10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals", 80, 30);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            FoodDetails food6 = new FoodDetails("Idly (2 pieces)", 20, 50);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani", 80, 15);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            FoodDetails food11 = new FoodDetails("Chicken 65 (200 Grams)", 75, 30);

            foodCustomList.Add(food1);
            foodCustomList.Add(food2);
            foodCustomList.Add(food3);
            foodCustomList.Add(food4);
            foodCustomList.Add(food5);
            foodCustomList.Add(food6);
            foodCustomList.Add(food7);
            foodCustomList.Add(food8);
            foodCustomList.Add(food9);
            foodCustomList.Add(food10);
            foodCustomList.Add(food11);

            OrderDetails order1 = new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order3 = new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled);

            orderCustomList.Add(order1);
            orderCustomList.Add(order2);
            orderCustomList.Add(order3);

            ItemDetails item1 = new ItemDetails("OID3001", "FID2001", 2, 200);
            ItemDetails item2 = new ItemDetails("OID3001", "FID2002", 2, 300);
            ItemDetails item3 = new ItemDetails("OID3001", "FID2003", 1, 80);
            ItemDetails item4 = new ItemDetails("OID3002", "FID2001", 1, 100);
            ItemDetails item5 = new ItemDetails("OID3002", "FID2002", 4, 600);
            ItemDetails item6 = new ItemDetails("OID3002", "FID2010", 1, 120);
            ItemDetails item7 = new ItemDetails("OID3002", "FID2009", 1, 50);
            ItemDetails item8 = new ItemDetails("OID3003", "FID2002", 2, 300);
            ItemDetails item9 = new ItemDetails("OID3003", "FID2008", 4, 320);
            ItemDetails item10 = new ItemDetails("OID3003", "FID2001", 2, 200);

            itemCustomList.Add(item1);
            itemCustomList.Add(item2);
            itemCustomList.Add(item3);
            itemCustomList.Add(item4);
            itemCustomList.Add(item5);
            itemCustomList.Add(item6);
            itemCustomList.Add(item7);
            itemCustomList.Add(item8);
            itemCustomList.Add(item9);
            itemCustomList.Add(item10);




        }

    }
}