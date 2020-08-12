using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeTag> RecipeTag { get; set; }

    public RecipeBoxContext(DbContextOptions options) : base(options) {}

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<Tag>().HasData(
    //     new Tag
    //     {
    //       TagId = 1,
    //       Name = "Mexican"
    //     },

    //     new Tag
    //     {
    //       TagId = 2,
    //       Name = "Chinese"
    //     },

    //     new Tag
    //     {
    //       TagId = 3,
    //       Name = "Favorite"
    //     },

    //     new Tag
    //     {
    //       TagId = 4,
    //       Name = "Baking"
    //     },

    //     new Tag
    //     {
    //       TagId = 5,
    //       Name = "Brunch"
    //     },

    //     new Tag
    //     {
    //       TagId = 6,
    //       Name = "Thai"
    //     }
    //   );
    // }
  }
}