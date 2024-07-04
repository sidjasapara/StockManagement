using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiddharthJasapara_550.Common
{
    public class SessionHelper
    {
        public static int Id
        {
            get
            {
                return HttpContext.Current.Session["Id"] == null ? 0 : (int)HttpContext.Current.Session["Id"];
            }
            set
            {
                HttpContext.Current.Session["Id"] = value;
            }
        }

        public static string Role
        {
            get
            {
                return HttpContext.Current.Session["Role"] == null ? "" : (string)HttpContext.Current.Session["Role"];
            }
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }
        }

        public static string Username
        {
            get
            {
                return HttpContext.Current.Session["Username"] == null ? "" : (string)HttpContext.Current.Session["Username"];
            }
            set
            {
                HttpContext.Current.Session["Username"] = value;
            }
        }
    }
}