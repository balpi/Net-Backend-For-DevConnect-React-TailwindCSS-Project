

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Npgsql.Replication;


public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public string createToken(UserCredential user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var claims = new List<Claim>(){
            new Claim(ClaimTypes.Email,user.Email),

        };


        if (user.UserRole != null)
            claims.Add(new Claim(ClaimTypes.Role, user.UserRole.ToString()));


        var tokenDescriptor = new JwtSecurityToken(
          issuer: _config["JwtSettings:Issuer"],
          audience: _config["JwtSettings:Audience"],
          claims: claims,

          expires: DateTime.UtcNow.AddHours(1),
          signingCredentials: creds
      );


        var tokenHandler = new JwtSecurityTokenHandler();
        System.Console.WriteLine("we came the last: " + tokenDescriptor);
        Console.WriteLine($"Current UTC: {DateTime.UtcNow}");

        try
        {


            return tokenHandler.WriteToken(tokenDescriptor);
        }
        catch (Exception)
        {

            throw new Exception("Invalid Token");
        }

    }
}