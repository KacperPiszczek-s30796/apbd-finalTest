using System.ComponentModel.DataAnnotations;

namespace Test_10_06_2025.models;

public class Genre
{
    [Key]
    public int IdGenre { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
}