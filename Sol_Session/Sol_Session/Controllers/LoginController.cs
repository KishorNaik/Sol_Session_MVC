using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Import
using Sol_Session.Models.Users;
using Newtonsoft.Json;

namespace Sol_Session.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            // Single Data
            HttpContext.Session.SetString("emailId", "kishor.naik011.net@gmail.com");

            // Send Json Data
            var userModel = new UserModel()
            {
                UserName = "Kishor",
                Password = "1234"
            };

            HttpContext.Session.SetString("UserModel1", JsonConvert.SerializeObject(userModel));

            // send Complex Data  (SessionComplex Class -> Extension Method)
            HttpContext.Session.SetData<UserModel>("UserModel2", userModel);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("emailId");
            HttpContext.Session.Remove("UserModel1");
            HttpContext.Session.Remove("UserModel2");

            return View("Index");
        }
    }
}