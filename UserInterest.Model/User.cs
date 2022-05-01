using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserInterest.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }      
        
        public ICollection<UserInterests> UserInterests { get; set; }

    }
}
