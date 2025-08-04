
public class UserCredential : EntityBase
{

    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public UserProfile Profile { get; set; } = null!;




}