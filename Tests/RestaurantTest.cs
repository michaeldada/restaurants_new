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

      Restaurant firstRestaurant = new Restaurant("Wolf & Bears", 1);
      Restaurant secondRestaurant = new Restaurant("Wolf & Bears", 1);

      Assert.Equal(firstRestaurant, secondRestaurant);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Restaurant testRestaurant = new Restaurant("Wolf & Bears", 1);

      testRestaurant.Save();
      List<Restaurant> result = Restaurant.GetAll();
      List<Restaurant> testList = new List<Restaurant>{testRestaurant};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Restaurant testRestaurant = new Restaurant("Wolf & Bears", 1);

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
      Restaurant testRestaurant = new Restaurant(name, 1);
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
      Restaurant testRestaurant1 = new Restaurant("Taste of India", 1);
      testRestaurant1.Save();
      Restaurant testRestaurant2 = new Restaurant("Olive Garden", 2);
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
      Restaurant testRestaurant = new Restaurant("Wolf & Bears", 1);
      testRestaurant.Save();

      Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());

      Assert.Equal(testRestaurant, foundRestaurant);
    }

  }
}
