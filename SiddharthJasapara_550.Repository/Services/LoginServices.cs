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
    public class LoginServices : ILoginInterface
    {
        private SiddharthJasapara1Entities DBContext = new SiddharthJasapara1Entities();

        public string UserAdded(UserModel userModel)
        {
            try
            {
                if (userModel != null)
                {
                    Admin admin = DBContext.Admin.FirstOrDefault(a => a.email == userModel.email);
                    Users user = DBContext.Users.FirstOrDefault(u => u.email == userModel.email);
                    if(admin != null || user != null)
                    {
                        return "exist";
                    }
                    DBContext.Users.Add(LoginHelper.CustomToDB(userModel));
                    DBContext.SaveChanges();

                    return "added";
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public List<string> Authorized(LoginModel loginModel)
        {
            try
            {
                List<string> list = new List<string>();
                if(loginModel != null)
                {
                    if(loginModel.role == "Supplier")
                    {
                        Users user = DBContext.Users.FirstOrDefault(u => u.email == loginModel.email && u.password == loginModel.password);
                        if(user != null)
                        {
                            list.Add(Convert.ToString(user.id));
                            list.Add(user.email);
                            list.Add("Supplier");
                        }
                        return list;
                    }
                    else if (loginModel.role == "Admin")
                    {
                        Admin admin = DBContext.Admin.FirstOrDefault(a => a.email == loginModel.email && a.password == loginModel.password);
                        if (admin != null)
                        {
                            list.Add(Convert.ToString(admin.id));
                            list.Add(admin.email);
                            list.Add("Admin");
                        }
                        return list;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
