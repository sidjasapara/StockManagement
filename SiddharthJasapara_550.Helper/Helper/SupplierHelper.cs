using SiddharthJasapara_550.Model.DBContext;
using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Helper.Helper
{
    public class SupplierHelper
    {
        public static OrderDetailsModel DBToCustom(OrderDetails order)
        {
            OrderDetailsModel orderDetails = new OrderDetailsModel();
            orderDetails.id = order.id;
            orderDetails.orderId = (int)order.orderId;
            orderDetails.productId = (int)order.productId;
            orderDetails.productName = order.name;
            orderDetails.quantity = order.quantity;
            orderDetails.type = order.type;
            orderDetails.price = (float)order.price;

            return orderDetails;
        }
    }
}
