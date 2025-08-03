public class Comment : EntityBase
{

    public string Content { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public UserProfile User { get; set; }

    public int BloqId { get; set; }
    public Bloq Bloq { get; set; }
}