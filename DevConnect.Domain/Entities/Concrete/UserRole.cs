public class UserRole
{
    public int Id { get; set; }
    public int UserCredentialId { get; set; }
    public UserCredential UserCredential { get; set; } = null!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
}