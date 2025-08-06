

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public class AuthService : IAuthService
{
    private readonly IRepository<UserCredential> _repo;

    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public AuthService(IRepository<UserCredential> repo, ITokenService tokenService, IMapper mapper)
    {
        _repo = repo;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<UserLoginResponseDto> LoginAsync(UserLoginDto login)
    {
        var spec = new UserCredentialWithUserProfileSpec(login);
        System.Console.WriteLine("Spec geri GELDİ");
        var user = await _repo.GetByFilter(spec);
        System.Console.WriteLine("new USER-----" + user.Email);

        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        if (!PasswordHelper.VerifyPassword(login.Password, user.PasswordHash, user.PasswordSalt))
        {
            System.Console.WriteLine("ŞİFREMİ TUTUMUYOR");
            throw new UnauthorizedAccessException("Invalid email or password");

        }

        var token = _tokenService.createToken(user);

        var response = _mapper.Map<UserLoginResponseDto>(user);
        response.Token = token;

        return response;


    }

    public async Task<bool> RegisterAsync(UserRegisterDto userRegisterDto)
    {
        byte[] passwordHash;
        byte[] passwordSalt;
        PasswordHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
        var newUserCredential = _mapper.Map<UserCredential>(userRegisterDto);
        newUserCredential.PasswordHash = passwordHash;
        newUserCredential.PasswordSalt = passwordSalt;

        System.Console.WriteLine("NewUserCredentials: ---" + newUserCredential);
        var response = await _repo.AddAsync(newUserCredential);
        System.Console.WriteLine("registered " + response);
        if (response == null)
        {
            return false;
        }
        return true;
    }
}
