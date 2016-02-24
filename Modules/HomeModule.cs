using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BestRestaurants
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Cuisine> AllCuisines = Cuisine.GetAll();
        return View["index.cshtml", AllCuisines];
      };
      Post["/addCuisine"] = _ => {
        Cuisine newCuisine = new Cuisine(Request.Form["cuisine-name"]);
        newCuisine.Save();
        List<Cuisine> AllCuisines = Cuisine.GetAll();
        return View["index.cshtml", AllCuisines];
      };

    Post["/addRestaurant"] = _ => {
      Restaurant newRestaurant = new Restaurant(Request.Form["restaurant-name"], Request.Form["restaurant-cuisine"], Request.Form["restaurant-address"], Request.Form["restaurant-phone"]);
      newRestaurant.Save();
      List<Cuisine> AllCuisines = Cuisine.GetAll();
      return View["index.cshtml", AllCuisines];
    };
    }
  }
}
