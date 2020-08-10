using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class RecipeBox
  {
    public Recipe()
    {
      this.Tags = new HashSet<RecipeTag>();
    }

    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    public ApplicationUser User { get; set; }
    public ICollection<RecipeTag> Tags { get; set; } 
  }
}