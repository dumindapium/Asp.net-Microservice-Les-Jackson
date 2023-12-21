using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDBContext _dbContext;

    public PlatformRepo(AppDBContext dbContext) => _dbContext = dbContext;

    public void Create(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }
        _dbContext.Add(platform);
    }

    public Platform GetPlatformById(int id) => _dbContext.Platforms.FirstOrDefault(p => p.Id == id);

    public IEnumerable<Platform> GetPlatforms() => _dbContext.Platforms.AsEnumerable();

    public bool SaveChanges() => _dbContext.SaveChanges() > 0;
}