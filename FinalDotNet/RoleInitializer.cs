﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalDotNet.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalDotNet
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
