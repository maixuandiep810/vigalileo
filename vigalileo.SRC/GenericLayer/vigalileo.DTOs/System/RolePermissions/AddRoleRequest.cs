using FluentValidation;

namespace vigalileo.DTOs.System.RolePermissions
{
    public class AddRoleRequest
    {
        public string Name { get; set; }
    }
    public class AddRoleRequestValidator : AbstractValidator<AddRoleRequest>
    {
        public AddRoleRequestValidator()
        {
            RuleFor(x => x.Name).Length(4, 32).WithMessage("Rolename length must be between 4 and 14 characters.");
        }
    }
}