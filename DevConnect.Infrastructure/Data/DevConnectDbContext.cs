

using Microsoft.EntityFrameworkCore;

public class DevConnectDbContext : DbContext
{
    public DevConnectDbContext(DbContextOptions<DevConnectDbContext> options) : base(options) { }

    public DbSet<UserCredential> UserCredentials => Set<UserCredential>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Bloq> Bloqs => Set<Bloq>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // UserCredential – UserProfile (One-to-One)
        modelBuilder.Entity<UserCredential>()
            .HasOne(u => u.UserProfile)
            .WithOne(p => p.UserCredential)
            .HasForeignKey<UserProfile>(p => p.UserCredentialId);

        modelBuilder.Entity<UserProfile>()
        .HasOne(u => u.UserCredential)
        .WithOne(uc => uc.UserProfile)
        .HasForeignKey<UserCredential>(p => p.UserProfileId);

        // UserCredential – UserRole – Role (Many-to-Many)
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserCredentialId, ur.RoleId });

        modelBuilder.Entity<RolePermission>()
     .HasKey(rp => new { rp.RoleId, rp.PermissionId });



        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);


        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // UserProfile – Bloq (One-to-Many)
        modelBuilder.Entity<Bloq>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bloqs)
            .HasForeignKey(b => b.UserId);

        // UserProfile – Comment (One-to-Many)
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        // Bloq – Comment (One-to-Many)
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Bloq)
            .WithMany(b => b.Comments)
            .HasForeignKey(c => c.BloqId);
    }

}