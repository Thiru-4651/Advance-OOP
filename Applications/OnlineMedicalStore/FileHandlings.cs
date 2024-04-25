using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class FileHandlings
    {
        /// <summary>
        /// Method for creating the CSV files
        /// </summary>
        public static void CreatCSV()
        {
            if (!Directory.Exists("OnlineMedicalStrore"))
            {
                System.Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("OnlineMedicalStrore");
            }

            if (!File.Exists("OnlineMedicalStrore/UserDetails.csv"))
            {
                System.Console.WriteLine("Creating a file");
                File.Create("OnlineMedicalStrore/UserDetails.csv");
            }

            if (!File.Exists("OnlineMedicalStrore/MedicineDetails.csv"))
            {
                System.Console.WriteLine("Creating a file");
                File.Create("OnlineMedicalStrore/MedicineDetails.csv");
            }

            if (!File.Exists("OnlineMedicalStrore/OrderDetails.csv"))
            {
                System.Console.WriteLine("Creating a file");
                File.Create("OnlineMedicalStrore/OrderDetails.csv");
            }
        }

        /// <summary>
        /// Method for writing the CSV files
        /// </summary>
        public static void WriteToCSV()
        {
            string[] userDetailsArray = new string[Operations.userList.Count];

            for (int i = 0; i < Operations.userList.Count; i++)
            {
                userDetailsArray[i] = Operations.userList[i].UserID + "," + Operations.userList[i].Name + "," + Operations.userList[i].Age + "," + Operations.userList[i].City + "," + Operations.userList[i].PhoneNumber + "," + Operations.userList[i].WalletBalance;
            }
            File.WriteAllLines("OnlineMedicalStrore/UserDetails.csv", userDetailsArray);

            string[] medicineDetailsArray = new string[Operations.medicineList.Count];

            for (int i = 0; i < Operations.medicineList.Count; i++)
            {
                medicineDetailsArray[i] = Operations.medicineList[i].MedicineID + "," + Operations.medicineList[i].MedicineName + "," + Operations.medicineList[i].AvailableCount + "," + Operations.medicineList[i].Price + "," + Operations.medicineList[i].DateOfExpiry.ToString("dd/MM/yyyy");
            }
            File.WriteAllLines("OnlineMedicalStrore/MedicineDetails.csv", medicineDetailsArray);

            string[] orderDetailsArray = new string[Operations.orderList.Count];

            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                orderDetailsArray[i] = Operations.orderList[i].OrderID + "," + Operations.orderList[i].UserID + "," + Operations.orderList[i].MedicineID + "," + Operations.orderList[i].MedicineCount + "," + Operations.orderList[i].TotalPrice + "," + Operations.orderList[i].OrderDate.ToString("dd/MM/yyyy") + "," + Operations.orderList[i].OrderStatus;
            }
            File.WriteAllLines("OnlineMedicalStrore/OrderDetails.csv", orderDetailsArray);
        }

        /// <summary>
        /// Method for read the CSV files
        /// </summary>
        public static void ReadFromCSV()
        {
            string[] userDetailsArray = File.ReadAllLines("OnlineMedicalStrore/UserDetails.csv");

            foreach (string user in userDetailsArray)
            {
                UserDetails newUser = new UserDetails(user);
                Operations.userList.Add(newUser);
            }

            string[] medicineDetailsArray = File.ReadAllLines("OnlineMedicalStrore/MedicineDetails.csv");

            foreach (string medicine in medicineDetailsArray)
            {
                MedicineDetails medicine1 = new MedicineDetails(medicine);
                Operations.medicineList.Add(medicine1);
            }

            string[] orderDetailsArray = File.ReadAllLines("OnlineMedicalStrore/OrderDetails.csv");

            foreach (string order in orderDetailsArray)
            {
                OrderDetails newOrder = new OrderDetails(order);
                Operations.orderList.Add(newOrder);
            }
        }
    }
}