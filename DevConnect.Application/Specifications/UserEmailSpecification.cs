public class UserEmailSpecification : BaseSpecification<UserCredential>
{
    public UserEmailSpecification(string email) : base(u => u.Email == email)
    {
        AddInclude(p => p.UserProfile);
    }
}