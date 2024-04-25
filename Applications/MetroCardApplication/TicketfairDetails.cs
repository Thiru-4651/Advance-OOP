using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    
    public class TicketfairDetails
    {
        /// <summary>
        /// Private Field for TicketID
        /// </summary>
        private static int _ticketID=3000;
        /// <summary>
        /// Read only Property for accessing the private field 
        /// </summary>
        public string TicketID { get;  }
        /// <summary>
        /// Property for accessing the From Location
        /// </summary>
        public string FromLocation { get; set; }
        /// <summary>
        /// Property for accessing the To Location
        /// </summary>
        public string ToLocation { get; set; }
        /// <summary>
        /// Property for accessing the Ticket Price
        /// </summary>        
        public int TicketPrice { get; set; }

        /// <summary>
        /// Constructor for assiging the values to the properties
        /// </summary>
        /// <param name="fromLocation"></param>
        /// <param name="toLocation"></param>
        /// <param name="ticketPrice"></param>
        public TicketfairDetails(string fromLocation,string toLocation,int ticketPrice)
        {
            _ticketID++;
            TicketID="MR"+_ticketID;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            TicketPrice=ticketPrice;
        }

        /// <summary>
        /// Constructor for FileHandlling
        /// </summary>
        /// <param name="newTicketfair"></param>
        public TicketfairDetails(string newTicketfair)
        {
            string[] values=newTicketfair.Split(",");
            _ticketID=int.Parse(values[0].Remove(0,2));
            TicketID=values[0];
            FromLocation=values[1];
            ToLocation=values[2];
            TicketPrice=int.Parse(values[3]);
        }
    }
}