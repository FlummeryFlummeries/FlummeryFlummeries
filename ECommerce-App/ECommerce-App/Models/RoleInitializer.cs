using ECommerce_App.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class RoleInitializer
    {
        private static readonly IdentityRole Admin = new IdentityRole { Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() };

        public static async Task SeedAdmin(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            using (var context = new UserDbContext(serviceProvider.GetRequiredService<DbContextOptions<UserDbContext>>()))
            {
                context.Database.EnsureCreated();
                if (!context.Roles.Any())
                {
                    context.Roles.Add(Admin);
                    context.SaveChanges();
                    await CreateAdmin(userManager, config);
                }
            }
        }

        public static async Task CreateAdmin(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            if (userManager.FindByNameAsync(config["AdminUserName"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = config["AdminUserName"],
                    FirstName = "Admin",
                    LastName = "Adminton",
                    Email = config["AdminUserName"]
                };

                IdentityResult created = userManager.CreateAsync(user, config["AdminPassword"]).Result;

                if (created.Succeeded)
                {
                    Claim claim = new Claim("FullName", "Administrator");


                    var result = userManager.AddClaimAsync(user, claim).Result;


                    await userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                }
            }
        }
    }
}
