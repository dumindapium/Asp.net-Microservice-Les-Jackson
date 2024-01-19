using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo platformRepo;
    private readonly IMapper mapper;

    private readonly ICommandDataClient commandDataClient;

    public PlatformsController(
            IPlatformRepo platformRepo,
            IMapper mapper,
            ICommandDataClient commandDataClient)
    {
        this.platformRepo = platformRepo;
        this.mapper = mapper;
        this.commandDataClient = commandDataClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> Getting platforms");

        var platforms = platformRepo.GetPlatforms();
        var dtos = mapper.Map<IEnumerable<PlatformReadDto>>(platforms);

        return Ok(dtos);
    }

    [HttpGet("{id}",Name ="GetPlatformById")]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatformById(int id)
    {
        Console.WriteLine("--> Getting platforms");

        var platform = platformRepo.GetPlatformById(id);
        var dtos = mapper.Map<PlatformReadDto>(platform);

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto dto)
    {
        Console.WriteLine("--> Creating a platform");

        var platform = mapper.Map<Platform>(dto);
        
        platformRepo.Create(platform);
        var result = platformRepo.SaveChanges();

        var platformDto = mapper.Map<PlatformReadDto>(platform);

        try
        {
            await commandDataClient.SendPlatformToCommand(platformDto);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"--> Could not send Synchronously : {ex.Message}");
        }

        if(result)
            return CreatedAtAction(nameof(GetPlatformById),new {id=platformDto.Id}, platformDto);
        else
            return BadRequest(new {message = "Internal error"});
    }

}