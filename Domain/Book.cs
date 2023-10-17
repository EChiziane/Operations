namespace Domain;

public class Book : BaseEntity
{
    public string Title { get; set; }

    public string Author { get; set; }

    public string Category { get; set; }
    public bool? IsAvailable { get; set; }
    public DateTime ReleaseDate { get; set; }
}