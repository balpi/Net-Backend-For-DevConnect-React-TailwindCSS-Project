public class Permission : EntityBase
{
    public PermissionsEnum Title { get; set; }
    public string? Description { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

}