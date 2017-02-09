using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //if (ConfigurationManager.AppSettings["Dev"] == "true")
            //{
            //    filters.Add(new HandleErrorAttribute());
            //}
            //else
            //{
            //    filters.Add(new ExceptionFilter());
            //}
        }
    }
}