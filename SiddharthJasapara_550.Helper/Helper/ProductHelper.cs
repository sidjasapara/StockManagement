using SiddharthJasapara_550.Model.DBContext;
using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Helper.Helper
{
    public class ProductHelper
    {
        public static ProductsModel DBToCustom(Products product)
        {
            ProductsModel productsModel = new ProductsModel();
            productsModel.id = product.id;
            productsModel.name = product.name;
            productsModel.description = product.description;
            productsModel.type = product.type;
            productsModel.quantity = product.quantity;
            productsModel.price = (float)product.price;

            return productsModel;
        }

        public static Products CustomToDB(ProductsModel productModel)
        {
            Products product = new Products();
            product.id = productModel.id;
            product.name = productModel.name;
            product.description = productModel.description;
            product.type = productModel.type;
            product.quantity = productModel.quantity;
            product.price = productModel.price;

            return product;
        }
    }
}
