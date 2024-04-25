using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum OrderStatus{Default, Initiated, Ordered, Cancelled}
    public class OrderDetails
    {
        //OrderID, CustomerID, TotalPrice, DateOfOrder, OrderStatus – {Default, Initiated, Ordered, Cancelled}.
        private static int _orderID=3000;
        public string OrderID { get;  }
        public string CustomerID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateOfOrder { get; set; }
        public OrderStatus OrderStatus{get; set;}

        public OrderDetails(string customerID,int totalPrice,DateTime dateOfOrder,OrderStatus orderStatus)
        {
            _orderID++;
            OrderID="OID"+_orderID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfOrder=dateOfOrder;
            OrderStatus=orderStatus;
        }

         public OrderDetails(string array)
        {
            string[] values=array.Split(",");
            _orderID=int.Parse(values[0].Remove(0,3));
            OrderID=values[0];
            CustomerID=values[1];
            TotalPrice=int.Parse(values[2]);
            DateOfOrder=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            OrderStatus=Enum.Parse<OrderStatus>(values[4]);
        }
    }
}