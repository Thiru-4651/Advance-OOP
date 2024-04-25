using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        /// <summary>
        /// AutoIncreament values cref="MedicineDetails"
        /// </summary>
        private static int _medicineID = 100;
        /// <summary>
        /// Property for storing MedicineID
        /// </summary>
        public string MedicineID { get; }
        /// <summary>
        /// Property for storing MedicineName
        /// </summary>
        public string MedicineName { get; set; }
        /// <summary>
        /// Property for storing Available Count
        /// </summary>
        public int AvailableCount { get; set; }
        /// <summary>
        /// Property for storing Price
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Property for storing DateOfExpiry
        /// </summary>
        public DateTime DateOfExpiry { get; set; }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="medicineName"></param>
        /// <param name="availableCount"></param>
        /// <param name="price"></param>
        /// <param name="dateOfExpiry"></param>
        public MedicineDetails(string medicineName, int availableCount, int price, DateTime dateOfExpiry)
        {
            _medicineID++;
            MedicineID = "MD" + _medicineID;
            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;
        }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="medicineString"></param>
        public MedicineDetails(string medicineString)
        {
            string[] values = medicineString.Split(",");
            _medicineID = int.Parse(values[0].Remove(0, 2));
            MedicineID = values[0];
            MedicineName = values[1];
            AvailableCount = int.Parse(values[2]);
            Price = int.Parse(values[3]);
            DateOfExpiry = DateTime.ParseExact(values[4], "dd/MM/yyyy", null);
        }

    }
}