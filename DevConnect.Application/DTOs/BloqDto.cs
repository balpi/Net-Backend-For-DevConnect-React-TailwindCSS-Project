
public class BloqDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; }

    public ICollection<Comment> Comments { get; set; }

}