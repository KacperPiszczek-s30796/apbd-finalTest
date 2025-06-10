namespace Test_10_06_2025.contracts.requests;

public class BookToAdd
{
    public int IdBook { get; set; }
    public string NameBook { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int IdPublishingHouse { get; set; }
    public string NamePublishingHouse { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public List<int> IdGenres { get; set; }
    public List<int> IdAuthors { get; set; }
}