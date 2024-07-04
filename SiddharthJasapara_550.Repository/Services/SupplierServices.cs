using SiddharthJasapara_550.Helper.Helper;
using SiddharthJasapara_550.Model.DBContext;
using SiddharthJasapara_550.Model.Model;
using SiddharthJasapara_550.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Repository.Services
{
    public class SupplierServices : ISupplierInterface
    {
        private SiddharthJasapara1Entities DBContext = new SiddharthJasapara1Entities();

        public List<ProductsModel> GetProducts()
        {
            try
            {
                List<ProductsModel> productsList = new List<ProductsModel>();
                List<Products> products = DBContext.Products.ToList();
                if (products.Count > 0)
                {
                    foreach (Products p in products)
                    {
                        productsList.Add(ProductHelper.DBToCustom(p));
                    }
                }
                return productsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PlaceOrder(int id, int userId)
        {
            try
            {
                Products product = DBContext.Products.FirstOrDefault(p => p.id == id);
                if (product == null)
                {
                    return "NoSuchProduct";
                }
                if (id > 0 && userId > 0 && product.quantity > 0)
                {
                    Orders order = DBContext.Orders.FirstOrDefault(o => o.ordDate == null && o.userId == userId);
                    if (order == null)
                    {
                        Orders orders = new Orders();
                        orders.userId = userId;
                        orders.total = product.price;
                        DBContext.Orders.Add(orders);
                        DBContext.SaveChanges();

                        OrderDetails orderDetails = new OrderDetails();
                        orderDetails.orderId = orders.id;
                        orderDetails.productId = id;
                        orderDetails.name = product.name;
                        orderDetails.type = product.type;
                        orderDetails.quantity = 1;
                        orderDetails.price = product.price;

                        DBContext.OrderDetails.Add(orderDetails);
                        product.quantity -= 1;
                        DBContext.SaveChanges();

                        return "NewOrder";
                    }
                    else
                    {
                        OrderDetails orderDetails = DBContext.OrderDetails.FirstOrDefault(o => o.productId == id && o.orderId == order.id);
                        if (orderDetails == null)
                        {
                            OrderDetails orderDetail = new OrderDetails();
                            orderDetail.orderId = order.id;
                            orderDetail.productId = id;
                            orderDetail.name = product.name;
                            orderDetail.type = product.type;
                            orderDetail.quantity = 1;
                            orderDetail.price = product.price;

                            DBContext.OrderDetails.Add(orderDetail);
                            product.quantity -= 1;
                            DBContext.SaveChanges();

                            return "Ordered";
                        }
                        return "Already";
                    }
                }
                return "Error";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderDetailsModel> PendingOrders(int id)
        {
            try
            {
                List<OrderDetailsModel> orderDetails = new List<OrderDetailsModel>();
                if (id > 0)
                {
                    Orders order = DBContext.Orders.FirstOrDefault(o => o.userId == id && o.ordDate == null);
                    if (order != null)
                    {
                        List<OrderDetails> orders = DBContext.OrderDetails.Where(o => o.orderId == order.id).ToList();
                        if (orders.Count > 0)
                        {
                            foreach (OrderDetails o in orders)
                            {
                                OrderDetailsModel orderDetailsModel = SupplierHelper.DBToCustom(o);
                                Products product = DBContext.Products.FirstOrDefault(p => p.id == o.productId);
                                orderDetailsModel.available = product.quantity;
                                orderDetails.Add(orderDetailsModel);
                            }
                        }
                    }
                }
                return orderDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Ordered(int id, List<OrderDetailsModel> orderDetailsModels)
        {
            try
            {
                if (id > 0 && orderDetailsModels.Count > 0)
                {
                    float total = 0;
                    int i = 0;
                    foreach (OrderDetailsModel o in orderDetailsModels)
                    {
                        OrderDetails orderDetail = DBContext.OrderDetails.FirstOrDefault(od => od.id == o.id);
                        i = o.orderId;
                        orderDetail.quantity = o.quantity;

                        Products product = DBContext.Products.FirstOrDefault(p => p.id == o.productId);
                        product.quantity = product.quantity - o.quantity + 1;

                        float sum = (float)(product.price * o.quantity);
                        total += sum;
                        DBContext.SaveChanges();
                    }
                    Orders order = DBContext.Orders.FirstOrDefault(o => o.id == i);
                    order.ordDate = DateTime.Now;
                    order.total = total;
                    DBContext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}