using System.Diagnostics.CodeAnalysis;

public class UserRegisterDto
{

    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public string? Location { get; set; }

    public string? Website { get; set; }
    public string? GithubUrl { get; set; }

}