using GCharge.Domain.Entities.Definitions;
using GCharge.Domain.Entities.Identity;
using GCharge.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OCPP.Core.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCPP.Core.Management.Controllers
{
    public partial class HomeController : BaseController
    {
        [Authorize]
        public IActionResult Users()
        {
            try
            {
                DbContextOptions<GChargeDbContext> options = new DbContextOptions<GChargeDbContext>();
                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                using (GChargeDbContext dbContext = new GChargeDbContext(options, this.Config, httpContextAccessor))
                {
                    List<AppUser> users = dbContext.Users
                                                    .Where(u => !u.IsDeleted)
                                                    .OrderBy(u => u.UserName).ToList();


                    return View(users);
                }
            }
            catch (Exception exp)
            {
                Logger.LogError(exp, "Users: Error loading users from database");
                TempData["ErrorMessage"] = "Error loading users from database";
                return View(new List<AppUser>()); // Hata durumunda boş bir liste döndür
            }
        }

        [Authorize]
        public IActionResult UserDetails(string id)
        {
            DbContextOptions<GChargeDbContext> options = new DbContextOptions<GChargeDbContext>();

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            using (GChargeDbContext dbContext = new GChargeDbContext(options, this.Config, httpContextAccessor))
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                DbContextOptions<GChargeDbContext> options = new DbContextOptions<GChargeDbContext>();
                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                using (GChargeDbContext dbContext = new GChargeDbContext(options, this.Config, httpContextAccessor))
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                        user.IsDeleted = true;
                        dbContext.SaveChanges();
                    }
                }
                TempData["SuccessMessage"] = "User deleted successfully.";
                return RedirectToAction("Users");
            }
            catch (Exception exp)
            {
                Logger.LogError(exp, "Delete: Error deleting user");
                TempData["ErrorMessage"] = "Error deleting user";
                return RedirectToAction("Users");
            }
        }

        public IActionResult AssignRFIDCard(string userId)
        {
            UserChargeTagViewModel viewModel = new UserChargeTagViewModel();

            DbContextOptions<GChargeDbContext> options = new DbContextOptions<GChargeDbContext>();
            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            using (GChargeDbContext dbContext = new GChargeDbContext(options, this.Config, httpContextAccessor))
            {
                var userChargeTags = dbContext.UserChargeTags.Where(uct => uct.UserId == userId).ToList();
                if (userChargeTags == null || userChargeTags.Count == 0)
                {
                    return NotFound();
                }
                var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);

                viewModel.UserId = userId;
                viewModel.Mail = user?.Email;
                viewModel.ParentTagId = userChargeTags.FirstOrDefault().TagId;
                viewModel.UserChargeTags = userChargeTags;
            }

            return View("~/Views/Home/UserChargeTag.cshtml", viewModel);
        }

        [HttpPost]
        public IActionResult AssignRFIDCard(UserChargeTagViewModel model)
        {
            if (ModelState.IsValid)
            {
                DbContextOptions<GChargeDbContext> options = new DbContextOptions<GChargeDbContext>();
                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                using (GChargeDbContext dbContext = new GChargeDbContext(options, this.Config, httpContextAccessor))
                {
                    var chargeTag = new ChargeTag
                    {
                        TagId = model.TagId,
                        TagName = model.Mail,
                        ParentTagId = model.ParentTagId,
                        ExpiryDate = DateTime.UtcNow.AddYears(1),
                        Blocked = false
                    };

                    dbContext.ChargeTags.Add(chargeTag);
                    dbContext.SaveChanges();

                    var userChargeTag = new UserChargeTag
                    {
                        UserId = model.UserId,
                        TagId = chargeTag.TagId,
                        CreatedBy = User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        IsDeleted = false
                    };

                    dbContext.UserChargeTags.Add(userChargeTag);
                    dbContext.SaveChanges();

                }
                return RedirectToAction("AssignRFIDCard", new { userId = model.UserId });
            }
            return RedirectToAction("AssignRFIDCard", new { userId = model.UserId });
        }


    }
}
