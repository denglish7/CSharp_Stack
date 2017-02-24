using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace dapperRelations.Models {
    public class User : BaseEntity {
        public User() {
            messages = new List<Message>();
            comments = new List<Comment>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string first_name { get; set; }
        [Required]
        [MinLength(2)]
        public string last_name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [Compare("Confirm_Password")]
        public string Password { get; set; }
        [Required]
        public string Confirm_Password { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public ICollection<Message> messages { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}