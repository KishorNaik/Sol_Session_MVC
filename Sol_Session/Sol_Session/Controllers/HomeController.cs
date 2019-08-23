using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_Session.Models;

namespace Sol_Session.Controllers
{
    public class HomeController : Controller
    {

        [BindProperty]
        public UserModel Users { get; set; }

        public IActionResult Index()
        {
            string userModelJson = HttpContext.Session.GetString("userModel");
         
            this.Users = JsonConvert.DeserializeObject<UserModel>(userModelJson);

            ViewBag.UsersModel = this.Users;

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
