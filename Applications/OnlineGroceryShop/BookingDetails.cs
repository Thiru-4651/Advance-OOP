using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    /// <summary>
    /// Booking status for stroing the enum values
    /// </summary>
    public enum BookingStatus{Default,Initiated,Booked,Cancelled}
    public class BookingDetails
    {
       
        /// <summary>
       /// AutoIncreament values cref="BookingDetails"
       /// </summary>
        private static int _bookingID=3000;
        /// <summary>
        /// Read Only Property for storing BookingID
        /// </summary>
        public string BookingID { get;  }
        /// <summary>
        /// Property for storing CustomerID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// Property for storing TotalPrice
        /// </summary>
        public int TotalPrice { get; set; }
        /// <summary>
        /// Property for storing Dateofbooking
        /// </summary>
        public DateTime DateofBooking { get; set; }
        /// <summary>
        /// Property for storing Bookingstatus
        /// </summary>
        public BookingStatus BookingStatus { get; set; }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="totalPrice"></param>
        /// <param name="dateofBooking"></param>
        /// <param name="bookingStatus"></param>
        public BookingDetails(string customerID,int totalPrice,DateTime dateofBooking,BookingStatus bookingStatus)
        {
            _bookingID++;
            BookingID="BID"+_bookingID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateofBooking=dateofBooking;
            BookingStatus=bookingStatus;
        }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="array"></param>
        public BookingDetails(string array)
        {
            string [] values=array.Split(",");
            _bookingID=int.Parse(values[0].Remove(0,3));
            BookingID=values[0];
            CustomerID=values[1];
            TotalPrice=int.Parse(values[2]);
            DateofBooking=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            BookingStatus=Enum.Parse<BookingStatus>(values[4],true);
        }

        
    }
}