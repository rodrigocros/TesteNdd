using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNDD.domain.Entities;
using TesteNDD.domain.Repositories;

namespace TesteNdd.infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly TesteNddContext _context;

        public UserRepository(TesteNddContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public  async Task DeleteAsync(Guid id)
        {
            var user = await  _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var getAll = await _context.User.ToListAsync();
            return getAll;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var getUser = await _context.User.FindAsync(id);
            return getUser;
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
