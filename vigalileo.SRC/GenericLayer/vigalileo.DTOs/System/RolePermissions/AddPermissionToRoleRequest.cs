using System;
using FluentValidation;

namespace vigalileo.DTOs.System.RolePermissions
{
    public class AddPermissionToRoleRequest
    {
        public int PermissionId { get; set; }
        public Guid ApplicationRoleId { get; set; }
    }

    public class AddPermissionToRoleRequestValidator : AbstractValidator<AddPermissionToRoleRequest>
    {
        public AddPermissionToRoleRequestValidator()
        {
            // RuleFor(x => x.RoleId). .WithMessage("Rolename length must be between 4 and 14 characters.");
        }
    }
}