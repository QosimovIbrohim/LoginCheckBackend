using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Domain.Entities.Models
{
    public class Login
    {
        public int Id { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(6),MaxLength(17)]
        public required string Password { get; set; }
    }
}
