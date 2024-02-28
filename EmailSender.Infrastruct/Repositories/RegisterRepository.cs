using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.DTOs;
using EmailSender.Domain.Entities.Models;
using EmailSender.Infrastruct.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Infrastruct.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        public ApplicationDbContext _context;

        public RegisterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> isExists(UserDTO auth)
        {
            try
            {
                if ((await _context.UserAuths.ToListAsync()).Any(x => x.Email == auth.Email))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        public async Task<UserAuth> isExists(LoginDTO auth)
        {
            try
            {
                if ((await _context.UserAuths.ToListAsync()).Any(x => x.Email == auth.Email))
                {
                    return await _context.UserAuths.FirstOrDefaultAsync(s => s.Email.Equals(auth.Email));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var model = await _context.UserAuths.FirstOrDefaultAsync(x => x.Id == id);
                if (model is null)
                {
                    return "Not Exists";
                }
                _context.UserAuths.Remove(model);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }

        public async Task<IEnumerable<UserAuth>> GetAll()
        {
            try
            {
                return await _context.UserAuths.ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<UserAuth>();
            }
        }

        public async Task<UserAuth> GetByIdAsync(int id)
        {
            try
            {
                return await _context.UserAuths.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> InsertAsync(UserAuth reg)
        {
            try
            {
                await _context.UserAuths.AddAsync(reg);
                await _context.SaveChangesAsync();
                return "Added";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }

        public async Task<string> UpdateAsync(int id, UserAuth reg)
        {
            try
            {
                var model = await _context.UserAuths.FirstOrDefaultAsync(x => x.Id == id);
                if (model is null)
                {
                    return "Not Exists";
                }

                model.Email = reg.Email;
                model.Password = reg.Password;
                await _context.SaveChangesAsync();
                return "Updated";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }
        public async Task UpdateAsync(LoginDTO lg, int code)
        {
            var model = await _context.UserAuths.FirstOrDefaultAsync(x => x.Email == lg.Email);
            if (model is null)
            {
                return;
            }

            model.Email = lg.Email;
            model.Password = lg.Password;
            model.Code = code;
            await _context.SaveChangesAsync();

        }
    }
}
