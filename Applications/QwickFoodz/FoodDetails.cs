using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FoodDetails
    {

        private static int _foodID=2000;
        public string FoodID { get;  }
        public string FoodName { get; set; }
        public int PricePerQuantity { get; set; }
        public int QuantityAvailable { get; set; }
        public FoodDetails(string foodName,int pricePerQuantity,int quantityAvailable)
        {
            _foodID++;
            FoodID="FID"+_foodID;
            FoodName=foodName;
            PricePerQuantity=pricePerQuantity;
            QuantityAvailable=quantityAvailable;
        }

        public FoodDetails(string array)
        {
            string[] values=array.Split(",");
            _foodID=int.Parse(values[0].Remove(0,3));
            FoodID=values[0];
            FoodName=values[1];
            PricePerQuantity=int.Parse(values[2]);
            QuantityAvailable=int.Parse(values[3]);
        }
    }
}