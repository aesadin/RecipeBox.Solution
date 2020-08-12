using Microsoft.AspNetCore.Mvc;

namespace RecipeBox.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(string searchOption, string searchString)
    {
      if (searchOption == "ingredients")
      {
        return RedirectToAction("Index", "Ingredients", new {name = searchString});
      }
      else if (searchOption == "tags")
      {
        return RedirectToAction("Index", "Tags", new {name = searchString});
      }
      else
      {
        return RedirectToAction("Index", "Recipes", new {name = searchString});
      }
    }
  }
}