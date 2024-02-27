using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Domain.Entities.Exceptions.RegisterExceptions
{
    public class EmailAlreadyExistsException : Exception
    { 
        public EmailAlreadyExistsException()
            : base ("This Email Already registered") { }
    }
}
