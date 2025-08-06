

public interface IAuthService
{
    Task<UserLoginResponseDto> LoginAsync(UserLoginDto login);
    Task<bool> RegisterAsync(UserRegisterDto userRegisterDto);
}