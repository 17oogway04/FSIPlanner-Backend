using Microsoft.AspNetCore.Identity;

public static class IdentitySeeder
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] rolesNames = {"GeneralAdmin", "Admin", "SuperUser", "User"};

        foreach(var role in rolesNames)
        {
            var roleExists = await roleManager.RoleExistsAsync(role);
            if(!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}