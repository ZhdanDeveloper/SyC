using SyC.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyC.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task Delete(int userId);
        IEnumerable<User> GetAll();
        Task UpdateAsync(User user);
        Task UpdateAsync(int id);
        public User GetById(int UserId);
    }
}
