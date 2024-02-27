using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Domain.Entities.Models
{
    public class Register
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6),MaxLength(17)]
        public string Password { get; set; }
    }
}
