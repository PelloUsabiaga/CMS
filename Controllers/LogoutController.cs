using CMS02.Models;
using CMS02.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS02.Controllers
{
    public class LogoutController : Controller
    {
        private readonly MyDBContext __context;

        public LogoutController(MyDBContext context)
        {
            __context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult LogoutSend()
        {
            try
            {
                using (__context)
                {
                    HttpContext.Session.Set<User>("User", null);
                    return Content("1");
                }


            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error " + ex.Message);
            }
        }
    }
}
