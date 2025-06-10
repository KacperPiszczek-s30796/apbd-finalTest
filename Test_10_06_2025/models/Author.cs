using System.ComponentModel.DataAnnotations;

namespace Test_10_06_2025.models;

public class Author
{
    [Key]
    public int IdAuthor { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
}