using EmailSender.Application.Abstractions.RepositoryInterfaces;
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
    public class RegisterRepository : IRegisterRepository
    {
        public ApplicationDbContext _context;

        public RegisterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var model = await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);
                if (model is null)
                {
                    throw new UsernotFoundException();
                }
                _context.Registers.Remove(model);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }

        public async Task<IEnumerable<Register>> GetAll()
        {
            try
            {
                return await _context.Registers.ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<Register>();
            }
        }

        public async Task<Register> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> InsertAsync(Register reg)
        {
            try
            {
                await _context.Registers.AddAsync(reg);
                await _context.SaveChangesAsync();
                return "Added";
            }
            catch
            {
                return "Exception with connecting database";
            }
        }

        public async Task<string> UpdateAsync(int id, Register reg)
        {
            try
            {
                var model = await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);
                if (model is null)
                {
                    throw new UsernotFoundException();
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
    }
}
