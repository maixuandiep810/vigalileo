using Microsoft.AspNetCore.Identity;
using System;

namespace vigalileo.Data.Entities
{
    public class ApplicationRole : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public string Description { get; set; }
    }
}
