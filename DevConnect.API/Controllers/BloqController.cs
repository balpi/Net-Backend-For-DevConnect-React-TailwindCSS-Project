using System.Security;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

    [HttpGet("/bloq{id}")]
    public async Task<ActionResult<BloqDto>> GetBloq([FromBody] int id)
    {
        try
        {
            var bloqDto = await _bloqService.GetBloq(id);
            return Ok(bloqDto);
        }
        catch (Exception)
        {

            return BadRequest("There is no Bloq which you searching for");
        }
    }

    [PermissionAuthorize(PermissionsEnum.CreateBloq)]
    [HttpPost("/addBloq")]
    public async Task<ActionResult<BloqDto>> AddBloq([FromBody] BloqDto bloqDto)
    {
        return await _bloqService.AddBloqAsync(bloqDto);
    }

    [PermissionAuthorize(PermissionsEnum.DeleteBloq)]
    [HttpPost("/removeBloq")]
    public async Task<ActionResult<BloqDto>> RemoveBloq([FromBody] BloqDto bloqDto)
    {
        return await _bloqService.RemoveBloq(bloqDto);

    }

    [PermissionAuthorize(PermissionsEnum.DeleteBloq)]
    [HttpPost("/hardDeleteBloq")]
    public async Task<ActionResult<BloqDto>> HardDelete([FromBody] BloqDto bloqDto)
    {
        return await _bloqService.HardDelete(bloqDto);
    }


}