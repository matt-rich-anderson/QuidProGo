using QuidProGo.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuidProGo.Auth.Models
{
    public class Registration
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("I will be using this Quid Pro GO as...")]
        public int UserTypeId { get; set; }

        public List<UserType> UserTypeOptions { get; set; }


    }
}