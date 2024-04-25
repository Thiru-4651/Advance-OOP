using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public class FileHandling
    {
        //Method for creating the CSVfiles
        public static void CreateCSV()
        {
            if(!Directory.Exists("OnlineGroceryShop"))
            {
                //Creating the folder
                Directory.CreateDirectory("OnlineGroceryShop");
            }

            if(!File.Exists("OnlineGroceryShop/CustomerDetails.csv"))
            {
                //Creating the file
                File.Create("OnlineGroceryShop/CustomerDetails.csv");
            }

            if(!File.Exists("OnlineGroceryShop/ProductDetails.csv"))
            {
                //Creating the file
                File.Create("OnlineGroceryShop/ProductDetails.csv");
            }

            if(!File.Exists("OnlineGroceryShop/OrderDetails.csv"))
            {
                //Creating the file
                File.Create("OnlineGroceryShop/OrderDetails.csv");
            }

            if(!File.Exists("OnlineGroceryShop/BookingDetails.csv"))
            {
                //Creating the file
                File.Create("OnlineGroceryShop/BookingDetails.csv");
            }
        }

        public static void WriteToCSV()
        {
            //Writing the cutomer Details
            string [] stringArray1=new string[Operations.customerCustomList.Count];

            for(int i=0;i<Operations.customerCustomList.Count;i++)
            {
                stringArray1[i]=Operations.customerCustomList[i].CustomerID+","+Operations.customerCustomList[i].WalletBalance+","+Operations.customerCustomList[i].Name+","+Operations.customerCustomList[i].FatherName+","+Operations.customerCustomList[i].Gender+","+Operations.customerCustomList[i].Mobile+","+Operations.customerCustomList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.customerCustomList[i].MailID;
            }

            File.WriteAllLines("OnlineGroceryShop/CustomerDetails.csv",stringArray1);



            //Writing the Product Details
            string [] stringArray2=new string[Operations.productCustomList.Count];

            for(int i=0;i<Operations.productCustomList.Count;i++)
            {
                stringArray2[i]=Operations.productCustomList[i].ProductID+","+Operations.productCustomList[i].ProductName+","+Operations.productCustomList[i].QuantityAvailable+","+Operations.productCustomList[i].PricePerQuantity;
            }

            File.WriteAllLines("OnlineGroceryShop/ProductDetails.csv",stringArray2);


            //Writing the Booking Details
            string [] stringArray3=new string[Operations.bookingCustomList.Count];

            for(int i=0;i<Operations.bookingCustomList.Count;i++)
            {
                stringArray3[i]=Operations.bookingCustomList[i].BookingID+","+Operations.bookingCustomList[i].CustomerID+","+Operations.bookingCustomList[i].TotalPrice+","+Operations.bookingCustomList[i].DateofBooking.ToString("dd/MM/yyyy")+","+Operations.bookingCustomList[i].BookingStatus;
            }

            File.WriteAllLines("OnlineGroceryShop/BookingDetails.csv",stringArray3);


            //Writing the Order Details
            string [] stringArray4=new string[Operations.orderCustomList.Count];

            for(int i=0;i<Operations.orderCustomList.Count;i++)
            {
                stringArray4[i]=Operations.orderCustomList[i].OrderID+","+Operations.orderCustomList[i].BookingID+","+Operations.orderCustomList[i].ProductID+","+Operations.orderCustomList[i].PurchaseCount+","+Operations.orderCustomList[i].PriceOfOrder;
            }

            File.WriteAllLines("OnlineGroceryShop/OrderDetails.csv",stringArray4);
        }
    
        public static void ReadFromCSV()
        {
            //Reading the cutomer Details from csv
            string[] array1=File.ReadAllLines("OnlineGroceryShop/CustomerDetails.csv");

            foreach (string array in array1)
            {
                CustomerDetails newCustomer=new CustomerDetails(array);
                Operations.customerCustomList.Add(newCustomer);
            }

            //Reading the prduct Details from csv
            string[] array2=File.ReadAllLines("OnlineGroceryShop/ProductDetails.csv");

            foreach (string array in array2)
            {
                ProductDetails newFood=new ProductDetails(array);
                Operations.productCustomList.Add(newFood);
            }

            //Reading the booking Details from csv
            string[] array3=File.ReadAllLines("OnlineGroceryShop/BookingDetails.csv");

            foreach (string array in array3)
            {
                BookingDetails newItem=new BookingDetails(array);
                Operations.bookingCustomList.Add(newItem);
            }


            //Reading the order Details from csv
            string[] array4=File.ReadAllLines("OnlineGroceryShop/OrderDetails.csv");

            foreach (string array in array4)
            {
                OrderDetails newOrder=new OrderDetails(array);
                Operations.orderCustomList.Add(newOrder);
            }
        }
  }
 }