using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public UserProfile Client { get; set; }

        [Required]
        public int AttorneyUserId { get; set; }

        public UserProfile Attorney { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Created")]
        public DateTime? CreateDateTime { get; set; }

        public List<Category> Categories { get; set; }

        public string ClientName { get; set; }
    }
}
