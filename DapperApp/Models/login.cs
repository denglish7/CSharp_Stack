using System;
using System.ComponentModel.DataAnnotations;

namespace DapperApp.Models {
    public class login : BaseEntity {
        [Required]
        public string loginEmail { get; set; }
        [Required]
        public string PasswordToCheck { get; set; }
    }
}