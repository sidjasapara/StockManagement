using Newtonsoft.Json;
using SiddharthJasapara_550.Common;
using SiddharthJasapara_550.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SiddharthJasapara_550.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                string jsonContent = JsonConvert.SerializeObject(loginModel);
                string url = "api/LoginApi/Login";
                string response = await WebApiHelper.HttpPostRequestResponse(jsonContent, url);

                List<string> list = JsonConvert.DeserializeObject<List<string>>(response);

                if (list.Count > 0)
                {
                    SessionHelper.Id = Convert.ToInt32(list[0]);
                    SessionHelper.Username = list[1];
                    SessionHelper.Role = list[2];

                    HttpCookie cookie = new HttpCookie("jwt")
                    {
                        Value = list[3],
                        HttpOnly = true,
                        Secure = false,
                    };
                    Response.Cookies.Add(cookie);

                    if (list[2] == "Admin")
                    {
                        TempData["loggedIn"] = "Logged In Successfully";
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (list[2] == "Supplier")
                    {
                        TempData["loggedIn"] = "Logged In Successfully";
                        return RedirectToAction("Index", "Supplier");
                    }
                }
                ViewBag.invalid = "Invalid Credentials";
                return View();
            }
            ViewBag.fill = "Please fill all details correctly";
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserModel userModel)
        {
            userModel.id = 0;
            if (ModelState.IsValid)
            {
                string jsonContent = JsonConvert.SerializeObject(userModel);
                string url = "api/LoginApi/Register";
                string response = await WebApiHelper.HttpPostRequestResponse(jsonContent, url);

                string added = JsonConvert.DeserializeObject<string>(response);

                if (added == "added")
                {
                    TempData["added"] = "User Registered";
                    return RedirectToAction("Login");
                }
                else if (added == "exist")
                {
                    ViewBag.exist = "Email Alredy Taken";
                    return View();
                }
                else
                {
                    ViewBag.error = "There is some error. Please try again";
                    return View();
                }
            }

            ViewBag.invalid = "Please fill all Details Correctly";
            return View();
        }
    
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}