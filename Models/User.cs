using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Classwork_16._02._24_auth_authorization__2.Models
{
    public class User
    {
        private static int id = 1;

        [Key]
        public int Id { get; private set; }

        [ValidateNever]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Article>? Articles { get; set; }

        public User()
        {
            Id = id++;
        }
    }
}
