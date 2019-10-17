namespace Restaurant.Models
{
  public class Restaurants
  {
    public int RestaurantsId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    public int CuisinesId { get; set; }

    public virtual Cuisines Cuisines { get; set; }
  }

  // public static Restaurants Show(int cuisineId)
  //   {
  //     CuisinesId = cuisineId;
  //     return _db.Restaurants [cuisineId-1];
  //   }
}