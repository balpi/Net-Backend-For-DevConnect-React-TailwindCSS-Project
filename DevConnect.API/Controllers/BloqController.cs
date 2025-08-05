using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    private readonly IBloqService<Bloq> _bloqService;

    public MyController(IBloqService<Bloq> bloqService)
    {
        _bloqService = bloqService;
    }

    [HttpGet("/bloqs")]
    public async Task<IActionResult> GetBloqs([FromBody] FilterDto filter)
    {
        try
        {
            var response = await _bloqService.GetBloqsAsync(filter);
            if (response == null)
            {
                return Ok("There is no bloq");

            }
            else
            {
                return Ok(response == null);
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "Server Error");
        }

    }
}