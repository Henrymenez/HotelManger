using HotelManger.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManager.DAL.Seed
{
    public class SeedData
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {

            AppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<AppDbContext>();
            UserManager<AppUser> userManager = context.GetService<UserManager<AppUser>>();
            RoleManager<AppRole> roleManager = context.GetService<RoleManager<AppRole>>();

            // await context.Database.EnsureCreatedAsync();
            if (!context.Users.Any())
            {
                List<string> roles = new List<string> { "Admin", "Hotel", "Employee", "Customer" };
                if (!context.Roles.Any())
                {
                    foreach (var role in roles)
                    {
                        // await context.Roles.AddAsync(new AppRole { Id = new Guid().ToString(), Name = role });
                        await roleManager.CreateAsync(new AppRole { Name = role });
                    }
                    //await context.SaveChangesAsync();
                }

                List<AppUser> users = new List<AppUser>
                {
                    new AppUser
                    {

                        FullName = "Test Admin",
                        Email = "test.admin@domain.com",
                        Phone = "09096026989",
                        Password = "Pass12345@"
                    },
                    new AppUser
                    {
                        FullName = "Test Manager",
                        Email = "test.manager@domain.com",
                        Phone = "09096026989",
                        Password = "Pass12345@"
                    }
                };

                foreach (var user in users)
                {
                    /*await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();*/
                var createdUser =   await userManager.CreateAsync(user);

                    //await context.UserRoles.AddAsync(new AppUserRole { User = user, RoleId =  });
                   /* if(createdUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    */

                }

            }
        }



    }
}
