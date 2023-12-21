using PlatformService.Models;

namespace PlatformService.Data;


public interface IPlatformRepo
{

    bool SaveChanges();
    IEnumerable<Platform> GetPlatforms();
    Platform? GetPlatformById(int id);
    void Create(Platform platform);

}