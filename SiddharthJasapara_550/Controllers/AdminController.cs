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
    [AdminRoleFilter]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Products()
        {
            string url = "api/AdminApi/Products";
            string response = await WebApiHelper.HttpRequestResponse(url);

            List<ProductsModel> list = JsonConvert.DeserializeObject<List<ProductsModel>>(response);

            return View(list);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductsModel productModel)
        {
            productModel.id = 0;
            if (ModelState.IsValid)
            {
                string jsonContent = JsonConvert.SerializeObject(productModel);
                string url = "api/AdminApi/AddProduct";
                string response = await WebApiHelper.HttpPostRequestResponse(jsonContent, url);

                bool added = JsonConvert.DeserializeObject<bool>(response);

                if (added)
                {
                    TempData["added"] = "New Product Added";
                    return RedirectToAction("Products");
                }

                ViewBag.error = "Unable to add. Please try again";
                return View();
            }
            ViewBag.fill = "Please all details correctly";
            return View();
        }

        public async Task<ActionResult> EditProduct(int id)
        {
            string url = "api/AdminApi/EditProduct?id=" + id;
            string response = await WebApiHelper.HttpRequestResponse(url);

            ProductsModel productsModel = JsonConvert.DeserializeObject<ProductsModel>(response);

            if(productsModel != null)
            {
                return View(productsModel);
            }
            TempData["noProduct"] = "No such Product Found";
            return RedirectToAction("Products");
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(ProductsModel productModel)
        {
            if (ModelState.IsValid)
            {
                string jsonContent = JsonConvert.SerializeObject(productModel);
                string url = "api/AdminApi/EditProduct";
                string response = await WebApiHelper.HttpPostRequestResponse(jsonContent, url);

                bool edited = JsonConvert.DeserializeObject<bool>(response);

                if (edited)
                {
                    TempData["edited"] = "Product Details Updated";
                    return RedirectToAction("Products");
                }

                ViewBag.error = "Unable to edit. Please try again";
                return View();
            }
            ViewBag.fill = "Please all details correctly";
            return View();
        }

        public async Task<ActionResult> Orders()
        {
            string url = "api/AdminApi/Orders";
            string response = await WebApiHelper.HttpRequestResponse(url);

            return View();
        }

        public async Task<ActionResult> Suppliers()
        {
            string url = "api/AdminApi/Suppliers";
            string response = await WebApiHelper.HttpRequestResponse(url);

            List<UserModel> list = JsonConvert.DeserializeObject<List<UserModel>>(response);

            return View(list);
        }
    }
}