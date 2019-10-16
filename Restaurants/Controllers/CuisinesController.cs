using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly RestaurantContext _db;

    public CuisinesController(RestaurantContext db)
    {
      _db = db;
    }

  }
}