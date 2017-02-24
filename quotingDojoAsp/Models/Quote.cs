using System.ComponentModel.DataAnnotations;

namespace quotingDojoAsp.Models
{
    public abstract class BaseEntity {}
    public class Quote : BaseEntity
    {
    [Key]
    public long Id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string quote { get; set; }
    public string created_at { get; set; }
    }
}   