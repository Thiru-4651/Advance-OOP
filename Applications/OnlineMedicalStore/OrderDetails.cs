using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    /// <summary>
    /// Orderstatus for stroing the enum values
    /// </summary>
    public enum OrderStatus{Purchased,Cancelled}
    public class OrderDetails
    {
       /// <summary>
       /// AutoIncreament values cref="OrderDetails"
       /// </summary>
        private static int _orderID=2000;

        /// <summary>
        /// Read Only Property for storing OrderID
        /// </summary>

        public string OrderID { get;  }
        /// <summary>
        /// Property for storing UserID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Property for storing MedicineID
        /// </summary>
        public string MedicineID { get; set; }
        /// <summary>
        /// Property for storing Medicine Count
        /// </summary>
        public int MedicineCount { get; set; }
        /// <summary>
        /// Property for storing TotalPrice
        /// </summary>
        public int TotalPrice { get; set; }
        /// <summary>
        /// Property for storing OrderDate
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Property for storing OrderStatus
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="medicineID"></param>
        /// <param name="medicineCount"></param>
        /// <param name="totalPrice"></param>
        /// <param name="orderDate"></param>
        /// <param name="orderStatus"></param>
        public OrderDetails(string userID ,string medicineID,int medicineCount,int totalPrice,DateTime orderDate,OrderStatus orderStatus)
        {
            _orderID++;
            OrderID="OID"+_orderID;
            UserID=userID;
            MedicineID=medicineID;
            MedicineCount=medicineCount;
            TotalPrice=totalPrice;
            OrderDate=orderDate;
            OrderStatus=orderStatus;
        }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="newOrder"></param>
        public OrderDetails(string newOrder)
        {
            string [] values=newOrder.Split(",");
            _orderID=int.Parse(values[0].Remove(0,3));
            OrderID=values[0];
            UserID=values[1];
            MedicineID=values[2];
            MedicineCount=int.Parse(values[3]);
            TotalPrice=int.Parse(values[4]);
            OrderDate=DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
            OrderStatus=Enum.Parse<OrderStatus>(values[6]);
        }

    }
}