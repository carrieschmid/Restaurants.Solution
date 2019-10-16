namespace Restaurant.Models
{
  public class Restaurants
  {
    public int RestaurantsId { get; set; }
    public string Description { get; set; }
    public int CuisinesId { get; set; }
    public virtual Cuisines Cuisines { get; set; }
  }
}