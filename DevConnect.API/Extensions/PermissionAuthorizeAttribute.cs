
using Microsoft.AspNetCore.Authorization;

public class PermissionAuthorizeAttribute : AuthorizeAttribute
{
    public PermissionAuthorizeAttribute()
    {
    }

    public PermissionAuthorizeAttribute(PermissionsEnum permissions)
    {
        Policy = permissions.ToString();
    }
}