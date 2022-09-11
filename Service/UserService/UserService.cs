using Core.Abstraction.IUserService;
using Core.ViewModel;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserService
{
    public class UserService : IUserService
    {
        private readonly EmployeeDbContext _dbContext;

        public UserService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> CreateUser(UserDto User)
        {
            var result = new User();
            if (User != null)
            {
                result.UserName = User.UserName;
                result.Password = User.Password;
                result.Email = User.Email;
                result.Name = User.Name;
                result.Role = User.Role;        
                await _dbContext.User.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<User?> GetUser(string UserName)
        {
            var result = await _dbContext.User.FirstOrDefaultAsync(s => s.UserName == UserName);
            return result ?? null;
        }
    }
}
