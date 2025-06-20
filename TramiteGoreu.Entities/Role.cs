using Microsoft.AspNetCore.Identity;

namespace TramiteGoreu.Entities
{
    public class Role:  IdentityRole
    {
        public bool CanCreate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanSearch { get; set; }
        public ICollection<MenuRol> MenuRoles { get; set; }
        public bool Status { get; set; } = true;

    }
}
