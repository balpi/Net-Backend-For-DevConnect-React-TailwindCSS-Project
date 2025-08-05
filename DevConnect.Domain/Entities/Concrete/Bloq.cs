public class Bloq : EntityBase
{

    public string Title { get; set; }
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public UserProfile User { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}