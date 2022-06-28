using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using IdentityApi.Models;
using IdentityApi.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class LoginRequiredAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.Items["User"];
        if (user == null)
        {
            var response = new TDResponse();
            response.SetError("Unauthorized");
            // not logged in
            context.Result = new JsonResult(response){ StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AdminRequiredAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.Items["User"];
        if (user == null)
        {
            var response = new TDResponse();
            response.SetError("Unauthorized");
            // not logged in
            context.Result = new JsonResult(response){ StatusCode = StatusCodes.Status401Unauthorized };
        }else if (((UserDto)user).Id!=1)
        {
            var response = new TDResponse();
            response.SetError("UnPermitted");
            // not admin
            context.Result = new JsonResult(response){ StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}