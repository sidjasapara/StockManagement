﻿using System.Web;
using System.Web.Mvc;

namespace SiddharthJasapara_550.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
