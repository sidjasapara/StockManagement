using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Repository.Repository
{
    public interface IAdminInterface
    {
        List<ProductsModel> GetProducts();
        bool AddProduct(ProductsModel productModel);
        List<UserModel> GetSuppliers();
        ProductsModel ProductDetails(int id);
        bool EditProduct(ProductsModel productModel);
    }
}
