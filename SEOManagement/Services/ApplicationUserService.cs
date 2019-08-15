using Microsoft.AspNetCore.Mvc.Rendering;
using SEOManagement.Models;
using System.Collections.Generic;

namespace SEOManagement.Services
{
    public class ApplicationUserService
    {
        private readonly SEOManagementContext _context;

        public ApplicationUserService(SEOManagementContext context)
        {
            _context = context;
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
