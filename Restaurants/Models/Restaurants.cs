namespace Restaurant.Models
{
  public class Restaurants
  {
    public int RestaurantsId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Review { get; set; }

    public int CuisinesId { get; set; }

    public virtual Cuisines Cuisines { get; set; }
  }


}