using System;
using System.ComponentModel.DataAnnotations;

namespace QuidProGo.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public int ClientUserId { get; set; }
        
        [Required]
        public int AttorneyUserId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? CreateDateTime { get; set; }
    }
}
