using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.UserName;
            Token = token;
            Role = user.Role;
        }
    }
}
