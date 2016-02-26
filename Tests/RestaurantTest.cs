using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BestRestaurants
{
  public class RestaurantTest : IDisposable
  {
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_test;Integrated Security=SSPI;";
    }
    public void Dispose()
   {
     Restaurant.DeleteAll();
   }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Restaurant.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {

      Restaurant firstRestaurant = new Restaurant("Wolf & Bears", 1, "123 example st", "555-555-5555");
      Restaurant secondRestaurant = new Restaurant("Wolf & Bears", 1, "123 example st", "555-555-5555");

      Assert.Equal(firstRestaurant, secondRestaurant);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Restaurant testRestaurant = new Restaurant("Wolf & Bears", 1, "123 example st", "555-555-5555");

      testRestaurant.Save();
      List<Restaurant> result = Restaurant.GetAll();
      List<Restaurant> testList = new List<Restaurant>{testRestaurant};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Restaurant testRestaurant = new Restaurant("Wolf & Bears", 1, "123 example st", "555-555-5555");

      testRestaurant.Save();
      Restaurant savedRestaurant = Restaurant.GetAll()[0];

      int result = savedRestaurant.GetId();
      int testId = testRestaurant.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Update_UpdatesRestaurantInDatabase()
    {
      //Arrange
      string name = "Fart Berry";
      Restaurant testRestaurant = new Restaurant(name, 1, "123 example st", "555-555-5555");
      testRestaurant.Save();
      string newName = "Tart Berry";

      //Act
      testRestaurant.Update(newName);

      string result = testRestaurant.GetDescription();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_Delete_DeletesRestaurantFromDatabase()
    {
      //Arrange
      Restaurant testRestaurant1 = new Restaurant("Taste of India", 1, "123 example st", "555-555-5555");
      testRestaurant1.Save();
      Restaurant testRestaurant2 = new Restaurant("Olive Garden", 2, "123 example st", "555-555-5555");
      testRestaurant2.Save();

      //Act
      testRestaurant1.Delete();
      List<Restaurant> resultRestaurants = Restaurant.GetAll();
      List<Restaurant> testRestaurantList = new List<Restaurant> {testRestaurant2};

      //Assert
      Assert.Equal(testRestaurantList, resultRestaurants);
    }


    [Fact]
    public void Test_Find_FindsRestaurantInDatabase()
    {
      Restaurant testRestaurant = new Restaurant("Wolf & Bears", 1, "123 example st", "555-555-5555");
      testRestaurant.Save();

      Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());

      Assert.Equal(testRestaurant, foundRestaurant);
    }

<<<<<<< HEAD
    [Fact]
    public void Test_GetReviews_RetrievesAllReviewsWithRestaurant()
    {
      Restaurant testRestaurant = new Restaurant("India House", 2, "123 example st", "555-555-5555");
      testRestaurant.Save();

      Review firstReview = new Review("Great Curry.", "Curry Man", testRestaurant.GetId());
      firstReview.Save();
      Review secondReview = new Review("Terrible Curry.", "Negative Man",  testRestaurant.GetId());
      secondReview.Save();

      List<Review> testReviewList = new List<Review> {firstReview, secondReview};
      List<Review> resultReviewList = testRestaurant.GetReviews();

      Assert.Equal(testReviewList, resultReviewList);
    }

=======
>>>>>>> 142e26394e21f1dfbc3d013019672ec7810fe0a0
  }
}
