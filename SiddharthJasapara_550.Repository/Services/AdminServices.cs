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
    public class AdminServices : IAdminInterface
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

        public bool AddProduct(ProductsModel productModel)
        {
            try
            {
                if(productModel != null)
                {
                    DBContext.Products.Add(ProductHelper.CustomToDB(productModel));
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
    
        public List<UserModel> GetSuppliers()
        {
            try
            {
                List<UserModel> suppliersList = new List<UserModel>();
                List<Users> users = DBContext.Users.ToList();
                if(users.Count > 0)
                {
                    foreach(Users u in users)
                    {
                        suppliersList.Add(LoginHelper.DBToCustom(u));
                    }
                }
                return suppliersList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public ProductsModel ProductDetails(int id)
        {
            try
            {
                ProductsModel productModel = new ProductsModel();
                if(id > 0)
                {
                    Products product = DBContext.Products.FirstOrDefault(p => p.id == id);
                    if(product != null)
                    {
                        return ProductHelper.DBToCustom(product);
                    }
                }
                return productModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditProduct(ProductsModel productModel)
        {
            try
            {
                if(productModel != null)
                {
                    Products product = DBContext.Products.FirstOrDefault(p => p.id == productModel.id);
                    product.name = productModel.name;
                    product.description = productModel.description;
                    product.type = productModel.type;
                    product.quantity = productModel.quantity;
                    product.price = productModel.price;

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
