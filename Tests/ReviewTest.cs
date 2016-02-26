using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BestRestaurants
{
  public class ReviewTest : IDisposable
  {
    public ReviewTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_test;Integrated Security=SSPI;";
    }
    public void Dispose()
   {
     Review.DeleteAll();
   }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Review.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {

      Review firstReview = new Review("Wolf & Bears", "123 example st",1);
      Review secondReview = new Review("Wolf & Bears", "123 example st",1);

      Assert.Equal(firstReview, secondReview);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Review testReview = new Review("Wolf & Bears", "123 example st",1);

      testReview.Save();
      List<Review> result = Review.GetAll();
      List<Review> testList = new List<Review>{testReview};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Review testReview = new Review("Wolf & Bears", "123 example st",1);

      testReview.Save();
      Review savedReview = Review.GetAll()[0];

      int result = savedReview.GetId();
      int testId = testReview.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Update_UpdatesReviewInDatabase()
    {
      //Arrange
      string name = "Fart Berry";
      Review testReview = new Review(name, "123 example st",1);
      testReview.Save();
      string newName = "Tart Berry";

      //Act
      testReview.Update(newName);

      string result = testReview.GetDescription();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_Delete_DeletesReviewFromDatabase()
    {
      //Arrange
      Review testReview1 = new Review("Taste of India", "123 example st",1);
      testReview1.Save();
      Review testReview2 = new Review("Olive Garden", "123 example st",2);
      testReview2.Save();

      //Act
      testReview1.Delete();
      List<Review> resultReviews = Review.GetAll();
      List<Review> testReviewList = new List<Review> {testReview2};

      //Assert
      Assert.Equal(testReviewList, resultReviews);
    }



    [Fact]
    public void Test_Find_FindsReviewInDatabase()
    {
      Review testReview = new Review("Wolf & Bears","123 example st", 1);
      testReview.Save();

      Review foundReview = Review.Find(testReview.GetId());

      Assert.Equal(testReview, foundReview);
    }

  }
}
