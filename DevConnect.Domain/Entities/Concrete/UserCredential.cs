
public class UserCredential : EntityBase
{

    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public int RoleId { get; set; }

    public UserRole UserRole { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public int UserProfileId { get; set; }

    public UserProfile UserProfile { get; set; } = null!;




}