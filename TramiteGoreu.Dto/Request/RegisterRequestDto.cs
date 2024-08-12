using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Dto.Request
{
    public class RegisterRequestDto
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = default!;
        [EmailAddress]
        public string Email { get; set; } = default!;
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; } = default!;
        public int Age { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; } = default!;


    }
}
