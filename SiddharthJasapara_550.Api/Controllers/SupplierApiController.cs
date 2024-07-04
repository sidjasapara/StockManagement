using SiddharthJasapara_550.Api.JWT;
using SiddharthJasapara_550.Model.DBContext;
using SiddharthJasapara_550.Model.Model;
using SiddharthJasapara_550.Repository.Repository;
using SiddharthJasapara_550.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiddharthJasapara_550.Api.Controllers
{
    [JwtAuthorizeAttribute]
    public class SupplierApiController : ApiController
    {
        private ISupplierInterface _SupplierServices;
        public SupplierApiController()
        {
            _SupplierServices = new SupplierServices();
        }

        [HttpGet]
        [Route("api/SupplierApi/Products")]
        public List<ProductsModel> Products()
        {
            return _SupplierServices.GetProducts();
        }

        [HttpGet]
        [Route("api/SupplierApi/Order")]
        public string Order(int id, int userId)
        {
            return _SupplierServices.PlaceOrder(id, userId);
        }

        [HttpGet]
        [Route("api/SupplierApi/PendingOrders")]
        public List<OrderDetailsModel> PendingOrders(int id)
        {
            return _SupplierServices.PendingOrders(id);
        }

        [HttpPost]
        [Route("api/SupplierApi/PlaceOrder")]
        public bool PlaceOrder(int id, List<OrderDetailsModel> orderDetailsModels)
        {
            return _SupplierServices.Ordered(id, orderDetailsModels);
        }

        [HttpGet]
        [Route("api/SupplierApi/Orders")]
        public List<OrdersModel> Orders(int id)
        {
            return _SupplierServices.GetOrders(id);
        }
    }
}