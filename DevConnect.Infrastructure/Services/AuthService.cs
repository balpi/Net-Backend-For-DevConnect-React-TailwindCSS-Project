

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public class AuthService : IAuthService
{
    private readonly DevConnectDbContext _context;
    private readonly ITokenService _tokenService;
    public AuthService(DevConnectDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<UserLoginResponseDto> LoginAsync(UserLoginDto login)
    {

        var user = await _context.Set<UserCredential>().FirstOrDefaultAsync(u => u.Email == login.Email);

        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        if (!PasswordHelper.VerifyPassword(login.Password, user.PasswordHash, user.PasswordSalt))
        {
            throw new UnauthorizedAccessException("Invalid email or password");

        }
        var token = _tokenService.createToken(user);

        var response = new UserLoginResponseDto
        {
            UserId = user.Id.ToString(),
            Token = token,
            UserName = user.Profile.FullName,
        };

        return response;


    }
}
