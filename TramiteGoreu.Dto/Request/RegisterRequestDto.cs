﻿using System;
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

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; } = default!;


    }
}
