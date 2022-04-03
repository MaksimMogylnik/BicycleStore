using BicycleStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        BicycleContext context;
        IdentityContext identityContext;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(BicycleContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IdentityContext identityContext)
        {
            this.identityContext = identityContext;
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(context.Bicycles.ToList());
        }

        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                return View(context.Bicycles.FirstOrDefault(x => x.BicycleId == id));
            }
        }

        [HttpPost]
        public IActionResult Create(Bicycle bicycle, IFormFile formFile)
        {
            if (bicycle.BicycleId == 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    formFile.OpenReadStream().CopyTo(ms);
                    bicycle.BicycleImage = "data:image/png;base64, " + Convert.ToBase64String(ms.ToArray());
                }
                context.Bicycles.Add(bicycle);
            }
            else
            {
                var bicycleEntity = context.Bicycles.FirstOrDefault(x => x.BicycleId == bicycle.BicycleId);
                bicycleEntity.BicycleTitle = bicycle.BicycleTitle;

                using (MemoryStream ms = new MemoryStream())
                {
                    formFile.OpenReadStream().CopyTo(ms);
                    bicycleEntity.BicycleImage = "data:image/png;base64, " + Convert.ToBase64String(ms.ToArray());
                }

                bicycleEntity.BicycleWeight = bicycle.BicycleWeight;
                bicycleEntity.BicycleColor = bicycle.BicycleColor;
                bicycleEntity.BicycleMaterial = bicycle.BicycleMaterial;
                bicycleEntity.BicyclePrice = bicycle.BicyclePrice;
                bicycleEntity.BicycleWheelDiameter = bicycle.BicycleWheelDiameter;
                bicycleEntity.BicycleAdditionalInfo = bicycle.BicycleAdditionalInfo;
                context.Entry(bicycleEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int bicycleId)
        {
            var bicycleToDelete = context.Bicycles.Find(bicycleId);
            context.Bicycles.Remove(bicycleToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UserRedaction()
        {
            return View(userManager.Users.ToList());
        }

        [HttpPost]
        public IActionResult SetAdmin(string id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            var adminRole = roleManager.Roles.FirstOrDefault(x => x.Name == "admin");

            user.RoleId = adminRole.Id;
            user.Role = adminRole;

            identityContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            identityContext.SaveChanges();

            return RedirectToAction("UserRedaction");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(string id, string newPassword)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            await userManager.ResetPasswordAsync(user, await userManager.GeneratePasswordResetTokenAsync(user), newPassword);

            identityContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            identityContext.SaveChanges();

            return RedirectToAction("UserRedaction");
        }
    }
}
