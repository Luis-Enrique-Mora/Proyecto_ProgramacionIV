using SamaraOrganicsSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamaraOrganicsSystem.Dtos
{
    public class UserForRegisterDto
    {
        public int PersonFk { get; set; }
        [Required]
        public string Email { get; set; }
        public int UserRoleFk { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 50 characters")]
        public string Password { get; set; }
    }
}
