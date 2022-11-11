using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CMS02.Models;
using CMS02.Extensions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CMS02.Controllers
{
    public class AccessController : Controller
    {
        private readonly MyDBContext __context;
        public AccessController(MyDBContext context)
        {
            __context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterSend (string User, string Email, string Password, string PasswordConfirm)
        {
            try
            {
                using (__context)
                {
                    if (Password != PasswordConfirm)
                    {
                        return Content("Write the password well.");
                    }
                    var lst = from d in __context.User
                              where d.Email == Email
                              select d;
                    if(lst.Count() > 0)
                    {
                        return Content("There is already a user registered with this Email.");
                    }
                    else
                    {
                        User oUser = new User();
                        oUser.Email = Email;
                        oUser.Username = User;
                        oUser.Password = Password;
                        oUser.StateId = 1;

                        __context.User.Add(oUser);
                        __context.SaveChanges();

                        IQueryable<User> Users = from user in __context.User
                                                 where user.Email == Email
                                                 select user;
                        List<User> UserList = Users.ToList();
                        User currentUser = UserList[0];

                        Roles oRoles = new Roles();
                        oRoles.UserId = currentUser.UserId;
                        oRoles.RoleId = 1;

                        __context.Roles.Add(oRoles);
                        __context.SaveChanges();

                        return Content("1");
                    }
                }

               
            }
            catch(Exception ex)
            {
                return Content("An error hapend " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult LoginSend (string Email, string Password)
        {
            try
            {
                using (__context)
                {
                    var lst = from d in __context.User
                              where d.Email == Email && d.Password == Password && d.StateId == 1
                              select d;
                    if(lst.Count() > 0)
                    {
                        User oUser = lst.First();
                        HttpContext.Session.Set<User>("User", oUser);
                        return Content("1");
                    }
                    else
                    {
                        return Content("Invalid User.");
                    }
                }

               
            }
            catch(Exception ex)
            {
                return Content("An error hapend " + ex.Message);
            }
        }
    }
}
