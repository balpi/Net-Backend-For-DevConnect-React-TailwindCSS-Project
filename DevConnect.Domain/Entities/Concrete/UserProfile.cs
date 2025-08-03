public class UserProfile : EntityBase
{

    public string FullName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
    public string? Location { get; set; }

    public string? Website { get; set; }
    public string? GithubUrl { get; set; }

    public string? ThemePreference { get; set; }

    public int UserCredentialId { get; set; }
    public UserCredential UserCredential { get; set; } = null!;
    public ICollection<Bloq> Bloqs { get; set; } = new List<Bloq>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}