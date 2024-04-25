using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    //Class
    public class FoodDetails
    {
        //Field
        private static int _foodID = 100;

        //Properties
        public string FoodID { get; }      //Read-Only
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public int AvailableQuantity { get; set; }

        //Constructor
        public FoodDetails(string foodName, int foodPrice, int availableQuantity)
        {
            _foodID++;
            FoodID = "FID" + _foodID;
            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuantity;
        }

    }
}