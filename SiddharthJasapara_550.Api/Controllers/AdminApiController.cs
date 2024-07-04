using SiddharthJasapara_550.Api.JWT;
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
    public class AdminApiController : ApiController
    {
        private IAdminInterface _AdminServices;
        public AdminApiController()
        {
            _AdminServices = new AdminServices();
        }

        [HttpGet]
        [Route("api/AdminApi/Products")]
        public List<ProductsModel> Products()
        {
            return _AdminServices.GetProducts();
        }

        [HttpPost]
        [Route("api/AdminApi/AddProduct")]
        public bool AddProduct(ProductsModel productModel)
        {
            return _AdminServices.AddProduct(productModel);
        }

        [HttpGet]
        [Route("api/AdminApi/EditProduct")]
        public ProductsModel EditProduct(int id)
        {
            return _AdminServices.ProductDetails(id);
        }

        [HttpPost]
        [Route("api/AdminApi/EditProduct")]
        public bool EditProduct(ProductsModel productModel)
        {
            return _AdminServices.EditProduct(productModel);
        }

        [HttpGet]
        [Route("api/AdminApi/Suppliers")]
        public List<UserModel> Suppliers()
        {
            return _AdminServices.GetSuppliers();
        }
    }
}