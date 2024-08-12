using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TramiteGoreu.Persistence
{
    public class TramiteGoreuUserIdentity : IdentityUser
    {
        [StringLength(100)]
        public string FirstName { get; set; } = default!;
        [StringLength(100)]
        public string LastName { get; set; } = default!;
    }
}
