using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class OrderDetails
    {
        public string orderId { get; set; }
        public double totalAmount { get; set; }
        public string currency { get; set; }
        public Item[] items { get; set; }
    }
}
