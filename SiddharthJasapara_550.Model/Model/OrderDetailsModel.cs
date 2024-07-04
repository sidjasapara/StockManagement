using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Model.Model
{
    public class OrderDetailsModel
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public string productName { get; set; }
        public int productId { get; set; }
        public float price { get; set; }
        public string type { get; set; }
        public int available { get; set; }
        public int quantity { get; set; }
    }
}
