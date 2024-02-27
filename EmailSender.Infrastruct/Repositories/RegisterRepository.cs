using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Infrastruct.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Register>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Register> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertAsync(Register reg)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id, Register reg)
        {
            throw new NotImplementedException();
        }
    }
}
