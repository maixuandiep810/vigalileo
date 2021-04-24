using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using vigalileo.Data.EF;
using vigalileo.Services.System.Auth;
using vigalileo.Services.System.RolePermissions;
using vigalileo.Services.System.Users;


namespace vigalileo.BackendApi.Middlewares
{
    public class ViRBACMiddleware
    {
        private readonly RequestDelegate _next;
        public ViRBACMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext httpContext, IJWTService jWTService, IUserService userService, IRoleService roleService, IPermissionService permissionService)
        {
            var path = httpContext.Request.Path;
            var action = httpContext.Request.Method;
            if ((await permissionService.IsAuthenticatedRouteAsync(path, action) == true))
            {
                var jwtToken = httpContext.Request.Headers["Authorization"].ToString();
                var roleList = new List<string>();
                var userId = "";

                if (jwtToken == null)
                {
                    roleList.Add("Guest");
                    httpContext.Items["RoleList"] = roleList;
                }
                else
                {
                    try
                    {
                        var principal = jWTService.ValidateToken(jwtToken);
                        httpContext.User = principal;

                        userId = principal.Claims.Where(x => x.Type == "Id").Select(x => x.Value).SingleOrDefault();
                        httpContext.Items["UserId"] = userId;
                        roleList = await userService.GetRoleNameAsync(userId);
                        httpContext.Items["RoleList"] = roleList;
                    }
                    catch (System.Exception)
                    {
                        roleList.Add("Guest");
                        httpContext.Items["RoleList"] = roleList;
                    }
                }

                var checkRoleNameList = await roleService.GetRoleNameHasPermission(path, action);

                if (checkRoleNameList.Contains<string>("Guest"))
                {
                    await _next(httpContext);
                }
                else if (roleList.Contains<string>("Guest") && roleList.Count == 1)
                {
                    throw new System.Exception("You are not authenticated");
                }
                else if (checkRoleNameList.Intersect(roleList).Count() == 0)
                {
                    throw new System.Exception("You are not authorized to access this route");
                }

                await _next(httpContext);
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}