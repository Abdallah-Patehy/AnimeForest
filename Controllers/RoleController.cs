using Anime_Forest.Models;
using Anime_Forest.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Anime_Forest.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager; // إضافة الـ UserManager

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        public IActionResult AddRoleToUser()
        {
            ViewBag.Roles = roleManager.Roles.ToList();
            return View("AddRoleToUser"); 
        }
        [HttpPost]
        public async Task<IActionResult> SaveAddRoleToUser(AddRoleToUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var result = await userManager.AddToRoleAsync(user, model.RoleName);
                    if (result.Succeeded)
                    {
                        ViewBag.Roles = roleManager.Roles.ToList();
                        return View("AddRoleToUser");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found.");
                }
            }
            ViewBag.Roles = roleManager.Roles.ToList();
            return View("AddRoleToUser", model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
                IdentityResult result =  await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    ViewBag.sucess = true; 
                    return View("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole");
        }
        public ActionResult EditRole()
        {
            return View("EditRole");
        }


    }
}
