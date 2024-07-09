using P02_FootballBetting.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserUserNameMaxLength)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserPasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public decimal Balance { get; set; }
    }
}
