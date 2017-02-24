using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace quoteReredux.Models {
    public class User : BaseEntity {
        public User() {
            quotes = new List<Quote>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("Confirm_Password")]
        public string Password { get; set; }
        [Required]
        public string Confirm_Password { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public ICollection<Quote> quotes { get; set; }
    }
}