using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_10_06_2025.models;

public class BookAuthor
{
    [Required]
    public int IdBook { get; set; }
    [ForeignKey("IdBook")]
    public virtual Book Book { get; set; }
    [Required]
    public int IdAuthor { get; set; }
    [ForeignKey("IdAuthor")]
    public virtual Author Author { get; set; }
}