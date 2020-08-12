using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;

    public IngredientsController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index(string name)
    {
      IQueryable<Ingredient> ingredientQuery = _db.Ingredients;
      if (!string.IsNullOrEmpty(name))
      {
        Regex search = new Regex(name, RegexOptions.IgnoreCase);
        ingredientQuery = ingredientQuery.Where(ingredients => search.IsMatch(ingredients.IngredientName));
      }
      IEnumerable<Ingredient> ingredientList = ingredientQuery.ToList().OrderBy(ingredients => ingredients.IngredientName);
      return View(ingredientList);
    }
    
    public ActionResult Create()
    {
      return View(); 
    }

    [HttpPost]
    public ActionResult Create(Ingredient ingredient)
    {
      _db.Ingredients.Add(ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Details(int id)
    // {
    //   Ingredient ingredient = _db.Ingredients
    //     .Include(ingredients => ingredients.Recipe)
    //     .ThenInclude(join => join.Tags)
    //     .ThenInclude(recipes => recipes.Recipe)
    //     .First(ingredients => ingredients.IngredientId == id);
    //   return View(ingredient);
    // }

    /* 
    public ActionResult Details(int id)
    {
      Ingredient thisIngredient = _db.Ingredients
      .Include(ingredient => ingredient.Recipes)
      .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisIngredient);
    }
     */
  }
}