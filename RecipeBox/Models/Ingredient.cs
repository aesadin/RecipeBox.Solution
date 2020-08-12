using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Ingredient
  {

    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public string IngredientName { get; set; }
    public Recipe Recipe { get; set; }
  }
}