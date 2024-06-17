using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class Item
    {
        public string itemId { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}
