using CMS02.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS02.Extensions;
using Microsoft.AspNetCore.Mvc;
using CMS02.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace CMS02.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext FilterContext)
        {
            User oUser = FilterContext.HttpContext.Session.Get<User>("User") as User;
            if (oUser == null)
            {
                if ((FilterContext.Controller is not AccessController) && (FilterContext.Controller is not HomeController))
                {
                    var Request = FilterContext.HttpContext.Request;
                    var baseUrl = $"{Request.Scheme}://{Request.Host.Value.ToString()}{Request.PathBase.Value.ToString()}";
                    FilterContext.HttpContext.Response.Redirect(baseUrl + "/Access/Login");
                }
            }
            else
            {
                if (FilterContext.Controller is AccessController)
                {
                    var Request = FilterContext.HttpContext.Request;
                    var baseUrl = $"{Request.Scheme}://{Request.Host.Value.ToString()}{Request.PathBase.Value.ToString()}";
                    FilterContext.HttpContext.Response.Redirect(baseUrl + "/Home/Index");
                }
            }

            base.OnActionExecuting(FilterContext);
        }
    }
}
