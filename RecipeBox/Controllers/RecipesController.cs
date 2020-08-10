// using Microsoft.AspNetCore.Mvc;
// using RecipeBox.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using System.Threading.Tasks;
// using System.Security.Claims;

// namespace RecipeBox.Controllers
// {
//   public class RecipesController : Controller
//   {
//     private readonly UserManager<ApplicationUser> _userManager;
//     private readonly RecipeBoxContext _db;

//     public RecipesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
//     {
//       _userManager = userManager;
//       _db = db;
//     }

//     public async Task<ActionResult> Index()
//     {
//       var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//       var currentUser = await _userManager.FindByAsync(userId);
//       var userRecipes = _db.Recipes.Where(entry => entry.User.Id == currentUser.Id).ToList();
//       return View(userRecipes);
//     }

//     public ActionResult Create()
//     {
//       Viewbag.TagId = new SelectList(_db.Tags, "TagId", "Name");
//       return View(); 
//     }
//   }
// }