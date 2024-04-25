using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FileHandling
    {
        public static void CreateCSV()
        {
            if(!Directory.Exists("QwickFoodz"))
            {
                Directory.CreateDirectory("QwickFoodz");
            }

            if(!File.Exists("QwickFoodz/CustomerDetails.csv"))
            {
                File.Create("QwickFoodz/CustomerDetails.csv");
            }

            if(!File.Exists("QwickFoodz/FoodDetails.csv"))
            {
                File.Create("QwickFoodz/FoodDetails.csv");
            }

            if(!File.Exists("QwickFoodz/OrderDetails.csv"))
            {
                File.Create("QwickFoodz/OrderDetails.csv");
            }

            if(!File.Exists("QwickFoodz/ItemDetails.csv"))
            {
                File.Create("QwickFoodz/ItemDetails.csv");
            }
        }

        public static void WriteToCSV()
        {
            string [] stringArray1=new string[Operations.customerCustomList.Count];

            for(int i=0;i<Operations.customerCustomList.Count;i++)
            {
                stringArray1[i]=Operations.customerCustomList[i].CustomerID+","+Operations.customerCustomList[i].WalletBalance+","+Operations.customerCustomList[i].Name+","+Operations.customerCustomList[i].FatherName+","+Operations.customerCustomList[i].Gender+","+Operations.customerCustomList[i].Mobile+","+Operations.customerCustomList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.customerCustomList[i].MailID+","+Operations.customerCustomList[i].Location;
            }

            File.WriteAllLines("QwickFoodz/CustomerDetails.csv",stringArray1);



            string [] stringArray2=new string[Operations.foodCustomList.Count];

            for(int i=0;i<Operations.foodCustomList.Count;i++)
            {
                stringArray2[i]=Operations.foodCustomList[i].FoodID+","+Operations.foodCustomList[i].FoodName+","+Operations.foodCustomList[i].PricePerQuantity+","+Operations.foodCustomList[i].PricePerQuantity;
            }

            File.WriteAllLines("QwickFoodz/FoodDetails.csv",stringArray2);


            string [] stringArray3=new string[Operations.itemCustomList.Count];

            for(int i=0;i<Operations.itemCustomList.Count;i++)
            {
                stringArray3[i]=Operations.itemCustomList[i].ItemID+","+Operations.itemCustomList[i].OrderID+","+Operations.itemCustomList[i].FoodID+","+Operations.itemCustomList[i].PurchaseCount+","+Operations.itemCustomList[i].PriceOfOrder;
            }

            File.WriteAllLines("QwickFoodz/ItemDetails.csv",stringArray3);


            string [] stringArray4=new string[Operations.orderCustomList.Count];

            for(int i=0;i<Operations.orderCustomList.Count;i++)
            {
                stringArray4[i]=Operations.orderCustomList[i].OrderID+","+Operations.orderCustomList[i].CustomerID+","+Operations.orderCustomList[i].TotalPrice+","+Operations.orderCustomList[i].DateOfOrder.ToString("dd/MM/yyyy")+","+Operations.orderCustomList[i].OrderStatus;
            }

            File.WriteAllLines("QwickFoodz/OrderDetails.csv",stringArray4);
        }
    
        public static void ReadFromCSV()
        {
            string[] array1=File.ReadAllLines("QwickFoodz/CustomerDetails.csv");

            foreach (string array in array1)
            {
                CustomerDetails newCustomer=new CustomerDetails(array);
                Operations.customerCustomList.Add(newCustomer);
            }

            string[] array2=File.ReadAllLines("QwickFoodz/FoodDetails.csv");

            foreach (string array in array2)
            {
                FoodDetails newFood=new FoodDetails(array);
                Operations.foodCustomList.Add(newFood);
            }

            string[] array3=File.ReadAllLines("QwickFoodz/ItemDetails.csv");

            foreach (string array in array3)
            {
                ItemDetails newItem=new ItemDetails(array);
                Operations.itemCustomList.Add(newItem);
            }


            string[] array4=File.ReadAllLines("QwickFoodz/OrderDetails.csv");

            foreach (string array in array4)
            {
                OrderDetails newOrder=new OrderDetails(array);
                Operations.orderCustomList.Add(newOrder);
            }
        }
    }
}