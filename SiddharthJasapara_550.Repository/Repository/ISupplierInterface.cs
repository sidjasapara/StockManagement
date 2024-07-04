using SiddharthJasapara_550.Model.DBContext;
using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Repository.Repository
{
    public interface ISupplierInterface
    {
        List<ProductsModel> GetProducts();
        string PlaceOrder(int id, int userId);
        List<OrderDetailsModel> PendingOrders(int id);
        bool Ordered(int id, List<OrderDetailsModel> orderDetailsModels);
    }
}
