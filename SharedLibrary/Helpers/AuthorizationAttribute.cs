using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using SharedLibrary.Models;
using SharedLibrary.Helpers;

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
            context.Result = new JsonResult(response) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}