using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Item
    {
        public string SlotLocation { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; } = 5;
        public int NumberSold { get; set; }

        public Item()
        {

        }

        public Item(string slotLocation, string productName, decimal price, string type)
        {
            this.SlotLocation = slotLocation;
            this.ProductName = productName;
            this.Price = price;
            this.Type = type;
        }
    }
}
