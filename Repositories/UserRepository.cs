using Classwork_16._02._24_auth_authorization__2.Models;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Classwork_16._02._24_auth_authorization__2.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users;
        private readonly List<Article> _articles;

        public UserRepository()
        {
            _users = new List<User>()
            {
                new User { Password = "Pavel", Email = "pavel@gmail.com" },
                new User { Password = "Josh", Email = "josh@gmail.com"},
                new User { Password = "John", Email = "john@gmail.com"},
            };

            _articles = new List<Article>()
            {
                new Article{Id = 1, Title = "Nature Secrets", Content = "random ...secrets", UserId = _users[0].Id},
                new Article{Id = 1, Title = "News today", Content = "random ... news", UserId = _users[0].Id},
                new Article{Id = 1, Title = "Hello", Content = "random ...hello", UserId = _users[1].Id},
                new Article{Id = 1, Title = "Random text", Content = "random ...random text", UserId = _users[1].Id},
            };
        }

        public List<User> Users
        {
            get
            {
                return _users;
            }
        }

        public List<Article> Articles
        {
            get
            {
                return _articles;
            }
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(e => e.Id == id);
        }
    }
}
