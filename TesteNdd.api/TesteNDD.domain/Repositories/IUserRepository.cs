using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNDD.domain.Entities;

namespace TesteNDD.domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task SaveChangesAsync();
        Task DeleteAsync(Guid id);

    }
}
