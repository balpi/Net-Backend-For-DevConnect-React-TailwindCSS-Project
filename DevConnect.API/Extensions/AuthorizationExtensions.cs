public static class AuthorizationExtensions
{
    public static IServiceCollection AddPermissionPolicies(this IServiceCollection services)
    {
        var permissions = Enum.GetValues(typeof(PermissionsEnum)).Cast<PermissionsEnum>();
        services.AddAuthorization(opt =>
        {
            foreach (var per in permissions)
            {
                opt.AddPolicy(per.ToString(), policy =>
                {
                    policy.RequireClaim("Permission", per.ToString());
                });
            }
        }

        );
        return services;
    }
}