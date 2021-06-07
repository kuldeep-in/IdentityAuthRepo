using IdentityAuthentication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAuthentication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityAuthUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityAuthUser> userManager, ApplicationDbContext dbContext)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllWorkItem()
        {
            WorkItemViewModel model = new WorkItemViewModel()
            {
                IsSuccess = false,
                WorkItems = _dbContext.WorkItem.Select(x => new WorkItem
                {
                    WorkItemId = x.WorkItemId,
                    UserName = x.UserName,
                    Title = x.Title,
                    CreatedOn = x.CreatedOn,
                    StateId = x.StateId
                }).ToList()
            };

            var workitems = _dbContext.WorkItem.ToList();
            return View(workitems);
        }

        public IActionResult AllUsers()
        {
            var users = _userManager.Users.ToList().OrderBy(x => x.Email);
            return View(users);
        }

        public IActionResult UserRole()
        {
            var roles = _roleManager.Roles.ToList().OrderBy(x => x.Name);
            return View(roles);
        }

        public IActionResult CreateUserRole()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRole(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("UserRole");
        }

        public async Task<ActionResult> DeleteRole(string id)
        {
            if (id != "Admin")
            {
                var role = await _roleManager.FindByNameAsync(id);
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("UserRole");
        }
    }
}
