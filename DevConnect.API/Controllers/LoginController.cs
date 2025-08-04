
using Microsoft.AspNetCore.Mvc;


public class LoginController : ControllerBase
{
    private readonly IAuthService _auth;
    public LoginController(IAuthService auth)
    {
        _auth = auth;
    }
    [HttpPost("login")]
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

}