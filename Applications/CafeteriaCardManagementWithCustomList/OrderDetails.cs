using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafteriaCardManagementWithCustomList
{
    //Enum creation
    public enum OrderStatus { Default, Initiated, Ordered, Cancelled }

    //class
    public class OrderDetails
    {
        //Field
        private static int _orderID = 1000;

        //Properties
        public string OrderID { get; }         //Read-Only
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }

        //Constructor
        public OrderDetails(string userID, DateTime orderDate, int totalPrice, OrderStatus orderStatus)
        {
            _orderID++;         //AutoIncreament
            OrderID = "OID" + _orderID;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = orderStatus;
        }

    }
}