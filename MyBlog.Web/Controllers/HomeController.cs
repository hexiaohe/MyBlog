using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using MyBlog.EF.Repositories;
using MyBlog.Entity;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var user = new UserRepo {Name = "大刀王五", Sex = true};
            //var us = new UserRepository();
            //us.Add(user);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            Expression<Func<UserRepo, bool>> exp = user => user.Name == "大刀王五";
            var s = new UserRepository().Exist(exp);

            return View();
        }
    }
}