using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Repository.Repository
{
    public interface ILoginInterface
    {
        string UserAdded(UserModel userModel);
        List<string> Authorized(LoginModel loginModel);
    }
}
