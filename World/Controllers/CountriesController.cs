using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;
using System;

namespace World.Controllers
{
  public class CountriesController : Controller
  {

        [HttpGet("/countries")]
        public ActionResult Index()
        {
          List<Country> allCountries = Country.GetAll();
          return View(allCountries);
        }

        [HttpGet("/countries/{countryCode}")]
        public ActionResult Show(string countryCode)
        {
          Dictionary<string, object> model = new Dictionary<string, object> {};
          Country selectedCountry = Country.GetCountryById(countryCode);
          List<City> selectedCities = City.GetCitiesByCountryCode(countryCode);
          model.Add("country", selectedCountry);
          model.Add("cities", selectedCities);

          return View(model);
        }


    // [HttpGet("/categories/{categoryId}/items/new")]
    // public ActionResult New(int categoryId)
    // {
    //    Category category = Category.Find(categoryId);
    //    return View(category);
    // }
    //
    // [HttpGet("/categories/{categoryId}/items/{itemId}")]
    // public ActionResult Show(int categoryId, int itemId)
    // {
    //   Item item = Item.Find(itemId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   model.Add("item", item);
    //   model.Add("category", category);
    //   return View(model);
    // }
    //
    // [HttpPost("/items/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }

  }
}
