using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;


public static class PrepareDb
{
    public static void PrepPopulate(IApplicationBuilder app)
    {
        
        // getting service at startup of the application can lead to exception like "Cannot access a disposed object in ASP.NET Core when injecting DbContext"
        //var dbContect = app.ApplicationServices.GetService<AppDBContext>();

        // so create a new scope and call GetService

        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<AppDBContext>();
            SeedDB(dbContext);
        }

    }

    private static void SeedDB(AppDBContext? dbContext)
    {

        if(!dbContext.Platforms.Any()){

        Console.WriteLine("---> Seeding data");

        dbContext?.Platforms.AddRange(
            new Platform(){Name="Dot Net", Publisher="Microsoft", Cost="Free"},
            new Platform(){Name="Netsuite", Publisher="Oracle", Cost="Free"},
            new Platform(){Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free"}
        );

        dbContext?.SaveChanges();
        }
        else{
            Console.WriteLine("---> Data already created");
        }
    }
}