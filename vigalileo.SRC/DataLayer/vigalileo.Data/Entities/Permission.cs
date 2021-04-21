using System.Collections.Generic;

namespace vigalileo.Data.Entities
{
    public class Permission : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }

        public virtual List<PermissionInRole> PermissionInRoles { get; set; }
    }
}