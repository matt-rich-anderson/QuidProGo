using System.ComponentModel.DataAnnotations;

namespace QuidProGo.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
