using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class UserEntity
    {
        public UserEntity(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
