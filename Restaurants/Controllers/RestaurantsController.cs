using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly RestaurantContext _db;

    public RestaurantsController(RestaurantContext db)
    {
      _db = db;
    }
     public ActionResult Index()
        {
            List<Restaurants> model = _db.Restaurants.Include(restaurants => restaurants.Cuisines).ToList(); 
            return View(model);
        }


  }
}