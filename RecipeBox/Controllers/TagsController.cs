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
  public class TagsController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TagsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTags = _db.Tags.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userTags);
    }

    public ActionResult Create()
    {
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
      return View(); 
    }

    [HttpPost]
    public async Task<ActionResult> Create(Tag tag, int RecipeId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
      var currentUser = await _userManager.FindByIdAsync(userId); 
      tag.User = currentUser;
      _db.Tags.Add(tag);
      if (RecipeId != 0)
      {
        _db.RecipeTag.Add(new RecipeTag() { RecipeId = RecipeId, TagId = tag.TagId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Tag thisTag = _db.Tags 
        .Include(tag => tag.Recipes) 
        .ThenInclude(join => join.Recipe) 
        .FirstOrDefault(tag => tag.TagId == id); 
      return View(thisTag);
    }

    public ActionResult Edit(int id)
    {
      var thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
      return View(thisTag);
    }

    [HttpPost]
    public ActionResult Edit(Tag tag, int RecipeId)
    {
      if (RecipeId != 0)
      {
        _db.RecipeTag.Add(new RecipeTag() { RecipeId = RecipeId, TagId = tag.TagId}); 
      }
      _db.Entry(tag).State = EntityState.Modified; 
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      return View(thisTag);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      _db.Tags.Remove(thisTag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteRecipe(int joinId)
    {
      var joinEntry = _db.RecipeTag.FirstOrDefault(entry => entry.RecipeTagId == joinId);
      _db.RecipeTag.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddRecipe(int id)
    {
      var thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
      return View(thisTag);
    }

    [HttpPost]
    public ActionResult AddRecipe(Tag tag, int RecipeId)
    {
      var existingConnection = _db.RecipeTag.FirstOrDefault(join => join.TagId == tag.TagId && join.RecipeId == RecipeId);

      if (existingConnection != null)
      {
        return RedirectToAction("Details", new {id = tag.TagId});
      }
      if (RecipeId != 0)
      {
      _db.RecipeTag.Add(new RecipeTag() { RecipeId = RecipeId, TagId = tag.TagId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}