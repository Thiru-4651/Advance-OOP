using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        
        private static int _itemID=4000;
        public string ItemID { get;  }
        public string OrderID { get;  }
        public string FoodID { get; set; }
        public int PurchaseCount { get; set; }
        public int PriceOfOrder { get; set; }

        public ItemDetails(string orderID,string foodID ,int purchaseCount,int priceOfOrder)
        {
            _itemID++;
            ItemID="ITID"+_itemID;
            OrderID=orderID;
            FoodID=foodID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;
        }

        public ItemDetails(string array)
        {
            string [] values=array.Split(",");
            _itemID=int.Parse(values[0].Remove(0,4));
            ItemID=values[0];
            OrderID=values[1];
            FoodID=values[2];
            PurchaseCount=int.Parse(values[3]);
            PriceOfOrder=int.Parse(values[4]);
        }
    }
}