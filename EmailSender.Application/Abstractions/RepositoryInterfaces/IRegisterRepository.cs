using EmailSender.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Abstractions.RepositoryInterfaces
{
    public interface IRegisterRepository
    {
        public Task<string> InsertAsync(Register reg);
        public Task<string> UpdateAsync(int id, Register reg);
        public Task<string> DeleteAsync(int id);
        public Task<Register> GetByIdAsync(int id);
        public Task<IEnumerable<Register>> GetAll();
    }
}
