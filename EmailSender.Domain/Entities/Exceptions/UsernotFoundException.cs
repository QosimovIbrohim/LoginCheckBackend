using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Domain.Entities.Exceptions
{
    public class UsernotFoundException : Exception
    {
        public UsernotFoundException()
           : base ("User not found") { }
    }
}
