using Newtonsoft.Json;
using SiddharthJasapara_550.Common;
using SiddharthJasapara_550.CustomFilters;
using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SiddharthJasapara_550.Controllers
{
    [SupplierRoleFilter]
    public class SupplierController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string url = "api/SupplierApi/Products";
            string response = await WebApiHelper.HttpRequestResponse(url);

            List<ProductsModel> list = JsonConvert.DeserializeObject<List<ProductsModel>>(response);

            return View(list);
        }

        [HttpGet]
        public async Task<ActionResult> Order(int id)
        {
            string url = "api/SupplierApi/Order?id=" + id + "&userId=" + SessionHelper.Id;
            string response = await WebApiHelper.HttpRequestResponse(url);

            string order = JsonConvert.DeserializeObject<string>(response);

            if (order == "NoSuchProduct")
            {
                ViewBag.noproduct = "No such Product available";
            }
            else if (order == "Ordered")
            {
                ViewBag.ordered = "Added to Cart";
            }
            else if (order == "NewOrder")
            {
                ViewBag.neworder = "Cart Created";
            }
            else if (order == "Already")
            {
                ViewBag.already = "Product already exist in cart";
            }
            else if (order == "Error")
            {
                ViewBag.error = "This product is not available at this time";
            }

            string url2 = "api/SupplierApi/PendingOrders?id=" + SessionHelper.Id;
            string response2 = await WebApiHelper.HttpRequestResponse(url2);

            List<OrderDetailsModel> orders = JsonConvert.DeserializeObject<List<OrderDetailsModel>>(response2);

            return View(orders);
        }

        [HttpPost]
        public async Task<ActionResult> Order(List<OrderDetailsModel> orderDetailsModels)
        {
            if (orderDetailsModels != null && orderDetailsModels.Count > 0)
            {
                string jsonContent = JsonConvert.SerializeObject(orderDetailsModels);
                string url = "api/SupplierApi/PlaceOrder?id=" + SessionHelper.Id;
                string response = await WebApiHelper.HttpPostRequestResponse(jsonContent, url);

                bool placed = JsonConvert.DeserializeObject<bool>(response);

                if (placed)
                {
                    TempData["ordered"] = "Order Placed";
                    return RedirectToAction("Orders");
                }
            }
            ViewBag.unable = "Unable to place the order";
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Orders()
        {
            string url = "api/SupplierApi/Orders?id=" + SessionHelper.Id;
            string response = await WebApiHelper.HttpRequestResponse(url);

            List<OrdersModel> orders = JsonConvert.DeserializeObject<List<OrdersModel>>(response);

            return View(orders);
        }
    }
}