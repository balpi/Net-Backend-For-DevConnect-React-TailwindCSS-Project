public class Role : EntityBase
{

    public string Name { get; set; } = null!; // örn: "Admin", "User", "Moderator"

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}