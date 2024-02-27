using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.Services.LoginServices;
using EmailSender.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Infrastruct.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Login>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertAsync(Login login)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id, Login login)
        {
            throw new NotImplementedException();
        }
    }
}
