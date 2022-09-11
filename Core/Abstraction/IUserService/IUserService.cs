using Core.ViewModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstraction.IUserService
{
    public interface IUserService
    {
        Task<User?> GetUser(string UserName);
        Task<User?> CreateUser(UserDto User);
    }
}
