public class UserCredentialWithUserProfileSpec : BaseSpecification<UserCredential>
{
    public UserCredentialWithUserProfileSpec(UserLoginDto userLoginDto) : base(x =>
        (string.IsNullOrEmpty(userLoginDto.Email)
        || (x.Email == userLoginDto.Email))
        && (!userLoginDto.UserProfileId.HasValue || x.UserProfileId == userLoginDto.UserProfileId)

    )
    {
        AddInclude(p => p.UserProfile);
    }
}