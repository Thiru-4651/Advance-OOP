using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class TravelDetails
    {
        /// <summary>
        /// Private Field for storing TravelID
        /// </summary>
        private static int _travelID = 2000;
        /// <summary>
        /// Property For Accessing the TeavelID
        /// </summary>
        public string TravelId { get; }
        /// <summary>
        /// Property For Storing the CardNumber
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// Property For Storing the FromLocation
        /// </summary>
        public string FromLocation { get; set; }
        /// <summary>
        /// Property For Storing the ToLocation
        /// </summary>
        public string ToLocation { get; set; }
        /// <summary>
        /// Property For Storing the Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Property For Storing the TeavelCost
        /// </summary>
        public int TravelCost { get; set; }

        /// <summary>
        /// Constructor assiging values to the properties
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="fromLocation"></param>
        /// <param name="toLocation"></param>
        /// <param name="date"></param>
        /// <param name="travelCost"></param>
        public TravelDetails(string cardNumber, string fromLocation, string toLocation, DateTime date, int travelCost)
        {
            _travelID++;
            TravelId = "TID" + _travelID;
            CardNumber = cardNumber;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            Date = date;
            TravelCost = travelCost;
        }
        /// <summary>
        /// Constructor for the File Handling
        /// </summary>
        /// <param name="newTravelDetail"></param>
        public TravelDetails(string newTravelDetail)
        {
            string[] values = newTravelDetail.Split(",");
            _travelID = int.Parse(values[0].Remove(0, 3));
            TravelId = values[0];
            CardNumber = values[1];
            FromLocation = values[2];
            ToLocation = values[3];
            Date = DateTime.ParseExact(values[4], "dd/MM/yyyy", null);
            TravelCost = int.Parse(values[5]);
        }
    }
}