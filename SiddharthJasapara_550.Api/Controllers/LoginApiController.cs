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
    public class LoginApiController : ApiController
    {
        private ILoginInterface _LoginServices;
        public LoginApiController()
        {
            _LoginServices = new LoginServices();
        }

        [HttpPost]
        [Route("api/LoginApi/Login")]
        public List<string> Login(LoginModel loginModel)
        {
            string token = Authentication.GenerateToken(loginModel.email);
            List<string> ls = _LoginServices.Authorized(loginModel);
            if(ls.Count > 0)
            {
                ls.Add(token);
            }
            return ls;
        }

        [HttpPost]
        [Route("api/LoginApi/Register")]
        public string Register(UserModel userModel)
        {
            return _LoginServices.UserAdded(userModel);
        }
    }
}