using System;
using System.ComponentModel.DataAnnotations;

namespace DapperApp.Models {
    public class User : BaseEntity {
        [Key]
        public long Id { get; set; }
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
    }
}