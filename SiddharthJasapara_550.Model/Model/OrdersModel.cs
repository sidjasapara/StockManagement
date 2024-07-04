using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Model.Model
{
    public class OrdersModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public System.DateTime date { get; set; }
        public double total { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}
