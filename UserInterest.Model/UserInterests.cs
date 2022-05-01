using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace UserInterest.Model
{
    [Serializable]
    public class UserInterests
    {
        [Key]
        public int UserInterestID { get; set; }

        public int UserID { get; set; }

        public int InterestID { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Interest Interest { get; set; }


    }
}
