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

      if ((Restaurant.FindName(Request.Form["restaurant-name"])).GetId() == 0)
        {
          newRestaurant.Save();
        }

      List<Cuisine> AllCuisines = Cuisine.GetAll();
      return View["index.cshtml", AllCuisines];
    };

    Get["/restaurant/{id}"] = parameters => {
      Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
      return View["restaurant.cshtml", SelectedRestaurant];
    };

    Get["/cuisine/{id}"] = parameters => {
      Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
      return View["cuisine.cshtml", SelectedCuisine];
    };

    Get["/restaurant/{id}/edit"] = parameters => {
      Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
      return View["restaurant_edit.cshtml", SelectedRestaurant];
    };

    Patch["/restaurant/{id}/edit"] = parameters => {
      Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
      SelectedRestaurant.Update(Request.Form["restaurant-name"]);
      List<Cuisine> AllCuisines = Cuisine.GetAll();
      return View["index.cshtml", AllCuisines ];
    };

    Delete["/restaurant/{id}/delete"] = parameters => {
      Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
      SelectedRestaurant.Delete();
      List<Cuisine> AllCuisines = Cuisine.GetAll();
      return View["index.cshtml", AllCuisines ];
    };

<<<<<<< HEAD
    Get["/restaurant_add"] = _ => {
      List<Cuisine> AllCuisines = Cuisine.GetAll();
      return View["restaurant_add.cshtml", AllCuisines];
    };

    Get["/cuisine_remove/{id}"] = parameters => {
      Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
      return View["cuisine_remove.cshtml", SelectedCuisine];
    };

    Delete["/cuisine_removed/{id}"] = parameters => {
      Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
      SelectedCuisine.Delete();
      List<Cuisine> AllCuisines = Cuisine.GetAll();
      return View["index.cshtml", AllCuisines];
    };

=======
>>>>>>> 142e26394e21f1dfbc3d013019672ec7810fe0a0
    Post["/search_results"] = _ => {
    Restaurant foundRestaurant = Restaurant.FindName(Request.Form["search"]);
    return View["search_results.cshtml", foundRestaurant];
  };

<<<<<<< HEAD
    Get["/restaurant/{id}/add_review"] = parameters => {
    Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
    return View["add_review.cshtml", SelectedRestaurant];
  };

    Post["/restaurant/{id}/add_review"] = parameters => {
    Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
    Review newReview = new Review(Request.Form["review"], Request.Form["username"], SelectedRestaurant.GetId());
    newReview.Save();
    return View["restaurant.cshtml", SelectedRestaurant];
  };

    Get["restaurant/{id}/delete_review"] = parameters => {
    Review SelectedReview = Review.Find(parameters.id);
    return View["delete_review.cshtml", SelectedReview];
  };

    Delete["restaurant/{id}/delete_review"] = parameters => {
    Review SelectedReview = Review.Find(parameters.id);
    Restaurant SelectedRestaurant = Restaurant.Find(SelectedReview.GetRestaurantId());
    SelectedReview.Delete();
    return View["restaurant.cshtml", SelectedRestaurant];
  };



=======
>>>>>>> 142e26394e21f1dfbc3d013019672ec7810fe0a0

    }
  }
}
