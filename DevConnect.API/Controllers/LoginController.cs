
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]

public class LoginController : ControllerBase
{
    private readonly IAuthService _auth;
    public LoginController(IAuthService auth)
    {
        _auth = auth;
    }

    [EnableCors("AllowFrontend")]
    [HttpPost("/login")]
    public async Task<ActionResult<UserLoginResponseDto>> Login([FromBody] UserLoginDto loginUser)
    {
        try
        {

            var user = await _auth.LoginAsync(loginUser);
            return Ok(user);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Invalid Email or Password");
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }


    }
    [EnableCors("AllowFrontend")]
    [HttpPost("/register")]
    public async Task<ActionResult<bool>> Register(UserRegisterDto registerDto)
    {

        if (string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
        {
            return Ok(false);
        }
        System.Console.WriteLine("we are at contorller REGİSTER");
        return await _auth.RegisterAsync(registerDto);
    }

}