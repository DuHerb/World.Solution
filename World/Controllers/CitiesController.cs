using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;
using System;

namespace World.Controllers
{
  public class CitiesController : Controller
  {
    [HttpGet("/countries/{countryCode}/cities/{cityId}")]
    public ActionResult Show(int cityId)
    {
      City selectedCity = City.GetCityById(cityId);

      return View(selectedCity);
    }
  }
}
