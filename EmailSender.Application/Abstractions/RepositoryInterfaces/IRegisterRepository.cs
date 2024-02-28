using EmailSender.Application.DTOs;
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
        public Task<string> InsertAsync(UserAuth reg);
        public Task<string> UpdateAsync(int id, UserAuth reg);
        public Task<string> DeleteAsync(int id);
        public Task<UserAuth> GetByIdAsync(int id);
        public Task<bool> isExists(UserDTO auth);
        public Task<UserAuth> isExists(LoginDTO auth);
        public Task<IEnumerable<UserAuth>> GetAll();
        public Task UpdateAsync(LoginDTO lg, int code);
    }
}
