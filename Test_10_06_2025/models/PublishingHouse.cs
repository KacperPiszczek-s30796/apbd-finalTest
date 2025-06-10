using System.ComponentModel.DataAnnotations;

namespace Test_10_06_2025.models;

public class PublishingHouse
{
    [Key]
    public int IdPublishingHouse { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Country { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
}