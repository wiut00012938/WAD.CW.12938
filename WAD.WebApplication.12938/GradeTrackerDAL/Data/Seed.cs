using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GradeTrackerDAL.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Teacher))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Teacher));
                if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
            }
        }
    }
}
