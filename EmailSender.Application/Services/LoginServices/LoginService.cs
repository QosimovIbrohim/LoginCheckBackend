using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.DTOs;
using EmailSender.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        public ILoginRepository _log;
        public LoginService(ILoginRepository log)
        {
            _log = log;
        }

        public Task<string> Create(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Login>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(int id, LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}
