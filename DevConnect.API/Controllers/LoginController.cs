
using Microsoft.AspNetCore.Mvc;

public class LoginController : ControllerBase
{
    private readonly IRepository<UserCredential> _repository;
    public LoginController(IRepository<UserCredential> repository)
    {
        _repository = repository;
    }
    public async Task<ActionResult> Login(UserCredential loginUser)
    {

        return Ok(null);


    }

}