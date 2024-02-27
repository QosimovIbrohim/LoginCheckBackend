using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.Services.LoginServices;
using EmailSender.Domain.Entities.Exceptions;
using EmailSender.Domain.Entities.Models;
using EmailSender.Infrastruct.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Infrastruct.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var model = await _context.Logins.FirstOrDefaultAsync(x => x.Id == id);
                if (model is null)
                {
                    throw new UsernotFoundException();
                }
                _context.Logins.Remove(model);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }

        public async Task<IEnumerable<Login>> GetAll()
        {
            try
            {
                return await _context.Logins.ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<Login>();
            }
        }

        public async Task<Login> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Logins.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> InsertAsync(Login login)
        {
            try
            {
                await _context.Logins.AddAsync(login);
                await _context.SaveChangesAsync();
                return "Added";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }

        public async Task<string> UpdateAsync(int id, Login login)
        {
            try
            {
                var model = await _context.Logins.FirstOrDefaultAsync(x => x.Id == id);
                if (model is null)
                {
                    throw new UsernotFoundException();
                }
               
                model.Email = login.Email;
                model.Password = login.Password;
                await _context.SaveChangesAsync();
                return "Updated";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }
    }
}
