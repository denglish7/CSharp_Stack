using System;
using System.ComponentModel.DataAnnotations;

namespace dapperRelations.Models {
    public class login : BaseEntity {
        [Key]
        [Required]
        public string loginEmail { get; set; }
        [Required]
        public string PasswordToCheck { get; set; }
    }
}