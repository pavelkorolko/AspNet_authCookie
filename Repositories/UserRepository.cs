using Classwork_16._02._24_auth_authorization__2.Models;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Classwork_16._02._24_auth_authorization__2.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>()
            {
                new User { Name = "Pavel", Email = "pavel@gmail.com", Password = "pavel" },
                new User { Name = "Josh", Email = "josh@gmail.com", Password = "josh"},
                new User { Name = "John", Email = "john@gmail.com", Password = "john"},
                new User { Name = "Elena", Email = "elena@gmail.com", Password = "elena" },
                new User { Name = "Alex", Email = "alex@gmail.com", Password = "alex" }
            };
        }

        public List<User> Users
        {
            get
            {
                return _users;
            }
        }

        public User GetUserById(int id)
        {
            var user = _users.FirstOrDefault(e => e.Id == id);
            return user;
        }

        public void UpdateUser(User user, int id)
        {
            var currentUser = _users.FirstOrDefault(e => e.Id == id);
            int index = _users.IndexOf(currentUser);

            currentUser!.Email = user.Email;
            currentUser!.Name = user.Name;
            currentUser!.Password = user.Password;

            _users[index] = currentUser;
        }
    }
}
