using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BestRestaurants
{
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CuisinesEmptyAtFirst()
    {
      //Arrange, Act
      int result = Cuisine.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      //Arrange, Act
      Cuisine firstCuisine = new Cuisine("Indian");
      Cuisine secondCuisine = new Cuisine("Indian");

      //Assert
      Assert.Equal(firstCuisine, secondCuisine);
    }

    [Fact]
    public void Test_Save_SavesCuisineToDatabase()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Indian");
      testCuisine.Save();

      //Act
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToCuisineObject()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Indian");
      testCuisine.Save();

      //Act
      Cuisine savedCuisine = Cuisine.GetAll()[0];

      int result = savedCuisine.GetId();
      int testId = testCuisine.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsCuisineInDatabase()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Indian");
      testCuisine.Save();

      //Act
      Cuisine foundCuisine = Cuisine.Find(testCuisine.GetId());

      //Assert
      Assert.Equal(testCuisine, foundCuisine);
    }

    [Fact]
    public void Test_GetRestaurants_RetrievesAllRestaurantsWithCuisine()
    {
      Cuisine testCuisine = new Cuisine("Indian");
      testCuisine.Save();

      Restaurant firstRestaurant = new Restaurant("India House", testCuisine.GetId());
      firstRestaurant.Save();
      Restaurant secondRestaurant = new Restaurant("Taste of India", testCuisine.GetId());
      secondRestaurant.Save();

      List<Restaurant> testRestaurantList = new List<Restaurant> {firstRestaurant, secondRestaurant};
      List<Restaurant> resultRestaurantList = testCuisine.GetRestaurants();

      Assert.Equal(testRestaurantList, resultRestaurantList);
    }

    [Fact]
    public void Test_Update_UpdatesCuisineInDatabase()
    {
      //Arrange
      string name = "Indian";
      Cuisine testCuisine = new Cuisine(name);
      testCuisine.Save();
      string newName = "Italian";

      //Act
      testCuisine.Update(newName);

      string result = testCuisine.GetDescription();

      //Assert
      Assert.Equal(newName, result);
    }
    [Fact]
    public void Test_Delete_DeletesCuisineFromDatabase()
    {
      //Arrange
      string name1 = "Indian";
      Cuisine testCuisine1 = new Cuisine(name1);
      testCuisine1.Save();

      string name2 = "Italian";
      Cuisine testCuisine2 = new Cuisine(name2);
      testCuisine2.Save();

      Restaurant testRestaurant1 = new Restaurant("Taste of India", testCuisine1.GetId());
      testRestaurant1.Save();
      Restaurant testRestaurant2 = new Restaurant("Olive Garden", testCuisine2.GetId());
      testRestaurant2.Save();

      //Act
      testCuisine1.Delete();
      List<Cuisine> resultCuisine = Cuisine.GetAll();
      List<Cuisine> testCuisineList = new List<Cuisine> {testCuisine2};

      List<Restaurant> resultRestaurants = Restaurant.GetAll();
      List<Restaurant> testRestaurantList = new List<Restaurant> {testRestaurant2};

      //Assert
      Assert.Equal(testCuisineList, resultCuisine);
      Assert.Equal(testRestaurantList, resultRestaurants);
    }

    public void Dispose()
    {
      Restaurant.DeleteAll();
      Cuisine.DeleteAll();
    }
  }
}
