using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_Session.Models;

namespace Sol_Session.Controllers
{
    public class LoginController : Controller
    {

        #region Property
        [BindProperty]
        public UserModel Users { get; set; }
        #endregion 

        #region Public Methods
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {

            string userModelJson = JsonConvert.SerializeObject(this.Users);

            HttpContext.Session.SetString("userModel", userModelJson);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
        #endregion 
    }
}