using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.DTOs;
using EmailSender.Domain.Entities.Models;

namespace EmailSender.Application.Services.RegisterServices
{
    public interface IRegisterService
    {
        public Task<string> Create(RegisterDTO loginDTO);
        public Task<string> Update(int id, RegisterDTO loginDTO);
        public Task<string> Delete(int id);
        public Task<Register> Get(int id);
        public Task<IEnumerable<Register>> GetAll();
    }
}
