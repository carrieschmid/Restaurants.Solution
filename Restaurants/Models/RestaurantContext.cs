using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models
{
  public class RestaurantContext : DbContext
  {
      public virtual DbSet<Cuisines> Cuisines { get; set; }
    public DbSet<Restaurants> Restaurants { get; set; }

    public RestaurantContext(DbContextOptions options) : base(options) { }
  }
}
