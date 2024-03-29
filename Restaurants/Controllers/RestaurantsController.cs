using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Restaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly RestaurantContext _db;

    public RestaurantsController(RestaurantContext db)
    {
      _db = db;
    }

    //   [HttpPost]
    //   public ActionResult Index(string restaurantDescription)
    //     {
    //         List<Restaurants> model = _db.Restaurants.Include(restaurants => restaurants.Cuisines).ToList(); 
    //         if (!String.IsNullOrEmpty(restaurantDescription)) 
    //         { 
    //             model = model.Where(s => s.Description.Contains(restaurantDescription)).Select(s => s).ToList(); 
    //         }
    //          return View(model);
    //     }
        [HttpPost]
      public ActionResult Index(string searchType, string value)
        {
            // Console.WriteLine(cuisines);
            List<Restaurants> model = _db.Restaurants.Include(restaurants => restaurants.Cuisines).ToList();
            if(searchType == "cuisine")
            {
                int cuisines = Int32.Parse(value);
                model  = _db.Restaurants.Where(restaurants => restaurants.CuisinesId == cuisines).Select(cuisine => cuisine).ToList();
            }
            else{
                model = model.Where(s => s.Description.Contains(value)).Select(s => s).ToList();
            }
            return View(model);
            
        } 

        public ActionResult Index()
        {
            List<Restaurants> model = _db.Restaurants.Include(restaurants => restaurants.Cuisines).ToList(); 
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CuisinesId = new SelectList(_db.Cuisines, "CuisinesId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurants restaurants)
        {
            _db.Restaurants.Add(restaurants);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Restaurants thisRestaurants = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantsId == id);
            Console.WriteLine(thisRestaurants);
            return View(thisRestaurants);
        }
         public ActionResult Delete(int id)
        {
            var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantsId == id);
            return View(thisRestaurant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantsId == id);
            _db.Restaurants.Remove(thisRestaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult Edit(int id)
        {
            var thisRestaurant = _db.Restaurants.FirstOrDefault(items => items.RestaurantsId == id);
            ViewBag.CuisinesId = new SelectList(_db.Cuisines, "CuisinesId", "Name");
            return View(thisRestaurant);
        }

        [HttpPost]
        public ActionResult Edit(Restaurants restaurants)
        {
            _db.Entry(restaurants).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Review(string searchType, string value)
        {
            List<Restaurants> model = _db.Restaurants.Include(restaurants => restaurants.Cuisines).ToList();
          
            return View();
        }

        [HttpPost]
        public ActionResult Show(string review)
        {
            List<Restaurants> model = _db.Restaurants.Include(restaurants => restaurants.Cuisines).ToList();
           
            
            model = model.Where(s => s.Description.Contains(review)).Select(s => s).ToList();
    
            return View("Show", model);
        }



  }
}