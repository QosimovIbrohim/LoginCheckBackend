using EmailSender.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Abstractions.RepositoryInterfaces
{
    public interface ILoginRepository
    {
        public Task<string> InsertAsync(Login login);
        public Task<string> UpdateAsync(int id,Login login);
        public Task DeleteAsync(int id);
        public Task<Login> GetByIdAsync(int id);
        public Task<IEnumerable<Login>> GetAll();
    }
}
