using CMS02.Extensions;
using CMS02.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class BecomePremiumController : Controller
    {
        private MyDBContext __context;

        public BecomePremiumController(MyDBContext context)
        {
            __context = context;
        }

        public IActionResult Index()
        {
            User CurrentUser = HttpContext.Session.Get<User>("User");

            Roles oRoles = __context.Roles.FirstOrDefault(item => item.UserId == CurrentUser.UserId);
            __context.Remove(oRoles);
            Roles newRole = new Roles();
            newRole.RoleId = 2;
            newRole.UserId = CurrentUser.UserId;
            __context.Add(newRole);
            __context.SaveChanges();
            return View();
        }
    }
}
