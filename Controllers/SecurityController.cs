using Abc.Northwind.MvcWebbUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Northwind.MvcWebbUI.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        /*
        public ActionResult Login(Kullanici kullanici)
        {
            return View();
        }
        */
    }
}
