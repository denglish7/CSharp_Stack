using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace dapperRelations.Models {
    public class Comment : BaseEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public string comment { get; set; }
        public int message_id { get; set; }
        public int user_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public User user { get; set; }
        public Message message { get; set; }
    }
}