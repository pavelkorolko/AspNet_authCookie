using System.ComponentModel.DataAnnotations;

namespace Classwork_16._02._24_auth_authorization__2.Models
{
    public class User
    {
        [Key]
        private static int id;
        public  int Id { get; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Article>? Articles { get; set; }

        public User()
        {
            Interlocked.Increment(ref id);
        }
    }
}
