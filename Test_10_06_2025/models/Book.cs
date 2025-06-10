using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_10_06_2025.models;

public class Book
{
    [Key]
    public int IdBook { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    [Required]
    public int IdPublishingHouse { get; set; }
    [ForeignKey("IdPublishingHouse")]
    public virtual PublishingHouse PublishingHouse { get; set; }
}