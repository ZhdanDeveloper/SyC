using SyC.Entity;
using SyC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Syc.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SyC.Services.Implement
{
    public class UserService : IUserService
    {

        public SycContext _context;

       

        public UserService(SycContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }
        public User GetById(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).FirstOrDefault();
        }


        public async Task Delete(int userId)
        {
            var user = GetById(userId);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var user = GetById(id);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
