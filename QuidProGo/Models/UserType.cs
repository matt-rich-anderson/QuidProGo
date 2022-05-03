using System.ComponentModel.DataAnnotations;

namespace QuidProGo.Models
{
    public class UserType
    {
        public int Id { get; set; }

        [Required]
        public string UserTypeName { get; set; }
    }
}
