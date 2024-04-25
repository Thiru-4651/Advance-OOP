using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public class ProductDetails
    {
        /// <summary>
        /// AutoIncreament values cref="ProductDetails"
        /// </summary>
        private static int _productID = 2000;
        /// <summary>
        /// Read Only Property for storing ProductID
        /// </summary>
        public string ProductID { get; }
        /// <summary>
        /// Property for storing CustomerID
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Property for storing CustomerID
        /// </summary>
        public int QuantityAvailable { get; set; }
        /// <summary>
        /// Property for storing PricePerQuanity
        /// </summary>
        public int PricePerQuantity { get; set; }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="quantityAvailable"></param>
        /// <param name="pricePerQuantity"></param>
        public ProductDetails(string productName, int quantityAvailable, int pricePerQuantity)
        {
            _productID++;
            ProductID = "PID" + _productID;
            ProductName = productName;
            QuantityAvailable = quantityAvailable;
            PricePerQuantity = pricePerQuantity;
        }

        /// <summary>
        /// Constructor for assiging values to properties
        /// </summary>
        /// <param name="array"></param>
        public ProductDetails(string array)
        {
            string[] values = array.Split(",");
            _productID = int.Parse(values[0].Remove(0, 3));
            ProductID = values[0];
            ProductName = values[1];
            QuantityAvailable = int.Parse(values[2]);
            PricePerQuantity = int.Parse(values[3]);
        }



        public void ShowProductDetails(CustomList<ProductDetails> elements)
        {
            foreach (ProductDetails product in elements)
            {

            }
        }
    }
}