using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
  [Authorize]
  public class RecipesController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RecipeBoxContext _db;

    public RecipesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByAsync(userId);
      var userRecipes = _db.Recipes.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userRecipes);
    }

    
    public ActionResult Create()
    {
      Viewbag.TagId = new SelectList(_db.Tags, "TagId", "Name");
      return View(); 
    }

    [HttpPost]
    public async Task<ActionResult> Create(Recipe recipe, int TagId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // if condition to the left of '?' is true, then get the value and save as userId variable
      var currentUser = await _userManager.FindByIdAsync(userId); // use user manager to grab user object by the user id that we created on the liine above.
      recipe.User = currentUser;
      _db.Recipes.Add(recipe);
      if (TagId != 0)
      {
        _db.RecipeTag.Add(new RecipeTag() { TagId = TagId, RecipeId = recipe.RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Recipe thisRecipe = _db.Recipes // defines recipe object including all recipes
          .Include(recipe => recipe.Tag) // only look at the tags part of the recipe object
          .ThenInclude(join => join.Tag) // only look for the tag portion of recipetag table
          .FirstOrDefault(recipe => recipe.RecipeId == id); // grab the first recipe Id that matches the int Id we passed as argument, if there is no Id then return null
      return View(thisRecipe);
    }

    public ActionResult Edit(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Name"); // thing that comes after ViewBag. is the name of your viewbag. Selectlist object takes 3 arguments: all the data that you want included, what value you want this clickable 'Name' to have, what you want displayed to user
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe, int TagId)
    {
      // var existingConnection = _db.RecipeTag.FirstOrDefault(join => join.RecipeId == recipe.RecipeId && join.TagId == TagId);

      // if (existingConnection != null)
      // {
      //   return RedirectToAction("Details", new {id = recipe.RecipeId});
      // }
      if (TagId != 0)
      {
        _db.RecipeTag.Add(new RecipeTag() { TagId = TagId, RecipeId = recipe.RecipeId }); // add to the RecipeTag database a new instance of recipetag with both the tagId and the recipeId from the recipe object passed as argument
      }
      _db.Entry(recipe).State = EntityState.Modified; // if we change an existing object, we will get errors unless we first change its entity state to modified, this is so the computer can keep track of modifications without changing the unique Ids of thes recipes
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteTag(int joinId)
    {
      var joinEntry = _db.RecipeTag.FirstOrDefault(entry => entry.RecipeTagId = joinId);
      _db.RecipeTag.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTag(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Name");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddTag(Recipe recipe, int TagId)
    {
      var existingConnection = _db.RecipeTag.FirstOrDefault(join => join.RecipeId == recipe.RecipeId && join.TagId == TagId);

      if (existingConnection != null)
      {
        return RedirectToAction("Details", new {id = recipe.RecipeId});
      }
      if (TagId != 0)
      {
      _db.RecipeTag.Add(new RecipeTag() { TagId = TagId, RecipeId = recipe.RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}