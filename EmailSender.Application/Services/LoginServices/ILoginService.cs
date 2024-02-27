using EmailSender.Application.DTOs;
using EmailSender.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<string> Create(LoginDTO loginDTO);
        public Task<string> Update(int id, LoginDTO loginDTO);
        public Task<string> Delete(int id);
        public Task<Login> Get(int id);
        public Task<IEnumerable<Login>> GetAll();
    }
}
