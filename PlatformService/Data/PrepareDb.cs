using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;


public static class PrepareDb
{
    public static void PrepPopulate(IApplicationBuilder app)
    {

        
        var dbContect = app.ApplicationServices.GetService<AppDBContext>();


    }
}