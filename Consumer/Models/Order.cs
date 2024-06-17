using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class Order
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public OrderDetails order { get; set; }
        public Payment payment { get; set; }
    }
}
