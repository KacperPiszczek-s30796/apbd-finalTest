using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_10_06_2025.models;

public class BookGenre
{
    [Required]
    public int IdGenre { get; set; }
    [ForeignKey("IdGenre")]
    public virtual Genre Genre { get; set; }
    [Required]
    public int IdBook { get; set; }
    [ForeignKey("IdBook")]
    public virtual Book Book { get; set; }
}