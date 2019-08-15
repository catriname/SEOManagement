using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using SEOManagement.Areas.Identity.Data;
using SEOManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEOManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly SEOManagementContext _context;

        public ManageUsersController(UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider, SEOManagementContext context)
        {
            _userManager = userManager;
            _serviceProvider = serviceProvider;

            _context = context;
        }

        public IActionResult Index()
        {

            ViewBag.Users = GetUsers();
            ViewBag.Roles = GetRoles();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string User, string Role)
        {
            var UserManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            ApplicationUser userEmail = await UserManager.FindByEmailAsync(User);
            await UserManager.AddToRoleAsync(userEmail, Role);

            return View();
        }

        public List<SelectListItem> GetUsers()
        {
            List<SelectListItem> dropDownList = new List<SelectListItem>();

            var users = _context.Users;

            foreach (var u in users)
            {
                SelectListItem tempItem = new SelectListItem();

                tempItem.Value = u.NormalizedUserName;
                tempItem.Text = u.NormalizedUserName;

                dropDownList.Add(tempItem);
            }

            return dropDownList;
        }

        public List<SelectListItem> GetRoles()
        {
            List<SelectListItem> dropDownList = new List<SelectListItem>();

            var roles = _context.Roles;


            foreach (var r in roles)
            {
                SelectListItem tempItem = new SelectListItem();

                tempItem.Value = r.NormalizedName;
                tempItem.Text = r.NormalizedName;

                dropDownList.Add(tempItem);
            }

            return dropDownList;
        }
    }
}