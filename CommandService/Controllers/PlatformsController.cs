using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;

[Route("api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{

    [HttpGet]
    public ActionResult Get()
    {
        Console.WriteLine("--> Getting Platforms");

        return Ok("test ok"); 
    }

    [HttpPost]
    public ActionResult Post(){
        Console.WriteLine("--> Posting Platforms");

        return Ok("Posted ok"); 
    }
}