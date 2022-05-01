using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace UserInterest.Model
{
    [Serializable]
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; } 
        
        public ICollection<UserInterests> UserInterests { get; set; }
        
    }
}
