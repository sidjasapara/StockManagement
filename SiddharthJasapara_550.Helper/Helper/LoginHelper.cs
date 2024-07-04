using SiddharthJasapara_550.Model.DBContext;
using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Helper.Helper
{
    public class LoginHelper
    {
        public static Users CustomToDB(UserModel userModel)
        {
            Users user = new Users();

            user.id = userModel.id;
            user.firstName = userModel.firstName;
            user.lastName = userModel.lastName;
            user.email = userModel.email;
            user.password = userModel.password;

            return user;
        }

        public static UserModel DBToCustom(Users user)
        {
            UserModel userModel = new UserModel();

            userModel.id = user.id;
            userModel.firstName = user.firstName;
            userModel.lastName = user.lastName;
            userModel.email = user.email;
            userModel.password = user.password;

            return userModel;
        }
    }
}
