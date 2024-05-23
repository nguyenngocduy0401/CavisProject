using CavisProject.Application.Commons;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.DataInitializer
{
    public class AccountInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public AccountInitializer(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AccountInitializeAsync()
        {
            string[] roles = { AppRole.Admin, AppRole.Customer, AppRole.Staff, AppRole.Expert };

            foreach (var role in roles)
            {
                var userRole = await _userManager.FindByNameAsync(role);

                if (userRole == null)
                {
                    var newUser = await _userManager.CreateAsync(new User { UserName = role, Wallet = 0 }, role);

                    if (newUser.Succeeded)
                    {
                        var getUser = await _userManager.FindByNameAsync(role);
                        await _userManager.AddToRoleAsync(getUser, role);
                    }
                }
            }
        }
    }
}
