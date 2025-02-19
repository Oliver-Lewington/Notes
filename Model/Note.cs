using SQLite;

namespace Notes.Model;

public class Note
{
    [PrimaryKey]
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
