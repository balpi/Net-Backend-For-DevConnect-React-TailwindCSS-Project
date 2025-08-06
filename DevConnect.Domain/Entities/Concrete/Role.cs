public class Role : EntityBase
{
    public RoleEnum Title { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public List<Permission> Permissions { get; set; } = new List<Permission>();


}