using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.DTOs;
using EmailSender.Domain.Entities.Models;

namespace EmailSender.Application.Services.RegisterServices
{
    public interface IRegisterService
    {
        public Task<string> Create(UserDTO loginDTO);
        public Task<IEnumerable<UserAuth>> GetAll();
    }
}
