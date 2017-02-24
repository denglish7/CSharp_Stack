using System;
using System.ComponentModel.DataAnnotations;

namespace dapperRelations.Models
{
    public class Quote : BaseEntity
    {
    public string Id { get; set; }
    public long user_id { get; set; }
    [Required]
    public string quote { get; set; }
    public string created_at { get; set; }
    public string updated_at { get; set; }
    public User user { get; set; }
    }
}   