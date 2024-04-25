using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafteriaCardManagementWithCustomList
{
    //Class
    public class CartItem
    {
        //Field
        private static int _itemID = 100;

        //Properties
        public string ItemID { get; }      //Read-only
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int OrderPrice { get; set; }
        public int OrderQuantity { get; set; }

        //Constructor
        public CartItem(string orderID, string foodID, int orderPrice, int orderQuantity)
        {
            _itemID++;
            ItemID = "ITID" + _itemID;
            OrderID = orderID;
            FoodID = foodID;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }
    }
}