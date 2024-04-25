using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public class OrderDetails
    {
        /// <summary>
       /// AutoIncreament values cref="OrderDetails"
       /// </summary>
        private static int _orderID=4000;
        public string OrderID { get;  }
        /// <summary>
        /// Property for storing BookingID
        /// </summary>
        public string BookingID { get; set; }
        /// <summary>
        /// Property for storing ProductID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// Property for storing PurchaseCount
        /// </summary>
        public int PurchaseCount { get; set; }
        /// <summary>
        /// Property for storing PriceofOrder
        /// </summary>
        public int PriceOfOrder { get; set; }

        /// <summary>
        /// Constructor for assiging values to properties
        /// 
        /// </summary>
        /// <param name="bookingID"></param>
        /// <param name="productID"></param>
        /// <param name="purchaseCount"></param>
        /// <param name="priceOfOrder"></param>
        public OrderDetails(string bookingID,string productID,int purchaseCount,int priceOfOrder)
        {
            _orderID++;
            OrderID="OID"+_orderID;
            BookingID=bookingID;
            ProductID=productID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;
        }

        /// <summary>
        /// Constructor for assiging values to properties
        /// 
        /// </summary>
        /// <param name="array"></param>
        public OrderDetails(string array)
        {
            string[] values=array.Split(",");
            _orderID=int.Parse(values[0].Remove(0,3));
            OrderID=values[0];
            BookingID=values[1];
            ProductID=values[2];
            PurchaseCount=int.Parse(values[3]);
            PriceOfOrder=int.Parse(values[4]);
        }
    }
}