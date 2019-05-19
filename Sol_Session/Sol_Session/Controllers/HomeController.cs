using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_Session.Models;
using Sol_Session.Models.Users;

namespace Sol_Session.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Read Single Data
            String emailid = HttpContext.Session.GetString("emailId");
            ViewBag.EmailId = emailid;

            // Read Json Data
            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("UserModel1"));
            ViewBag.UserModel1 = userModel;

            // Read Complex Data (Using Session Complex Class -> Extension Method)
            userModel = HttpContext.Session.GetData<UserModel>("UserModel2");
            ViewBag.UserModel2 = userModel;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}