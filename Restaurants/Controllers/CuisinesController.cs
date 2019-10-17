using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Restaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly RestaurantContext _db;

    public CuisinesController(RestaurantContext db)
    {
      _db = db;
    }
            
    [HttpGet]    
    public ActionResult Index()
    {
      List<Cuisines> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisines cuisines)
    {
      _db.Cuisines.Add(cuisines);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Cuisines thisCuisines = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisinesId == id);
      return View(thisCuisines);
    }
     public ActionResult Delete(int id)
    {
      var thisCuisines = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisinesId == id);
      return View(thisCuisines);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisinesId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisinesId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisines cuisines)
    {
      _db.Entry(cuisines).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}