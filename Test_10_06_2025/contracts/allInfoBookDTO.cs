namespace Test_10_06_2025.contracts;

public class allInfoBookDTO
{
    public int IdBook { get; set; }
    public string NameBook { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string NamePublishingHouse { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public List<string> Genres { get; set; }
    public List<string> Authors { get; set; }
}