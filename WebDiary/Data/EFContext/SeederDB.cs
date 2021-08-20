using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDiary.Data.Models;

namespace WebDiary.Data.EFContext
{
    public class SeederDB
    {
        public static void SeedUsers(UserManager<DbUser> userManager,
            EFDbContext _context)
        {
            var count = userManager.Users.Count();
            if (count <= 0)
            {
                string email = "telesuk@gmail.com";
                var roleName = "Admin";

                var userprofile = new UserProfile
                {
                    FirstName = "admin",
                    LastName = "admin",
                    MiddleName = "admin",
                    RegistrationDate = DateTime.Now
                };
                var user = new DbUser
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = "+38(095)890-10-45",
                    UserProfile = userprofile
                };

                var result = userManager.CreateAsync(user, "Qwerty1-").Result;
                _context.UserProfiles.Add(userprofile);
                _context.SaveChanges();
                result = userManager.AddToRoleAsync(user, roleName).Result;
            }
        }
        public static void SeedTables(EFDbContext _context)
        {
            
        }
        public static void SeedRoles(RoleManager<DbRole> roleManager)
        {
            var count = roleManager.Roles.Count();
            if (count <= 0)
            {
                var roleName = "User";
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Admin";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Student";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Parent";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Director";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Manager";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Teacher";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "SchoolWorker";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
            }
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                //var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();


                //SeederDB.SeedRegions(context);
                SeederDB.SeedRoles(managerRole);
                SeederDB.SeedTables(context);
            }
        }


    }
}
