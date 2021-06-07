using IdentityAuthentication.Data;
using IdentityAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SubmitRequest(bool isSuccess = false)
        {
            WorkItemViewModel model = new WorkItemViewModel()
            {
                IsSuccess = isSuccess,
                WorkItems = _dbContext.WorkItem.Select(x => new WorkItem
                {
                    WorkItemId = x.WorkItemId,
                    UserName = x.UserName,
                    Title = x.Title,
                    CreatedOn = x.CreatedOn,
                    StateId = x.StateId
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitRequest(WorkItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.WorkItem.Add(new WorkItem
                {
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    UserPhone = model.UserPhone,
                    Title = model.Title,
                    Description = model.Description,
                    CreatedOn = DateTime.UtcNow
                });
                _dbContext.SaveChanges();

                return RedirectToAction("SubmitRequest", new { isSuccess = true });
            }

            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
