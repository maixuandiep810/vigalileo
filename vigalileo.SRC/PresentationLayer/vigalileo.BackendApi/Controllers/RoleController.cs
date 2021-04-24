using System;
using Microsoft.AspNetCore.Mvc;
using vigalileo.Services.System.Users;
using vigalileo.Services.System.RolePermissions;
using vigalileo.DTOs.System.Users;
using System.Threading.Tasks;
using vigalileo.DTOs.Common;
using vigalileo.Utilities.Constants;
using Microsoft.Extensions.Primitives;
using System.Linq;
using vigalileo.BackendApi.Extensions;

namespace vigalileo.BackendApi.Controllers
{

    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
    }
}