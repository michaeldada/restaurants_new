using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurants
{
  public class Review
  {
      private int _id;
      private string _description;
      private string _username;
      private int _restaurantId;

      public Review(string description, string username, int restaurantId, int id = 0)
      {
        _id = id;
        _description = description;
        _username = username;
        _restaurantId = restaurantId;
      }

      public override bool Equals(System.Object otherReview)
      {
        if (!(otherReview is Review))
        {
          return false;
        }
        else
        {
            Review newReview = (Review) otherReview;
            bool idEquality = (this.GetId() == newReview.GetId());
            bool descriptionEquality = (this.GetDescription() == newReview.GetDescription());
            bool usernameEquality = (this.GetUsername() == newReview.GetUsername());
            bool restaurantEquality = (this.GetRestaurantId() == newReview.GetRestaurantId());
            return (idEquality && descriptionEquality && usernameEquality && restaurantEquality);
      }
  }

  public void Delete()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("DELETE FROM review WHERE id = @ReviewId;", conn);
    SqlParameter reviewIdParameter = new SqlParameter();
    reviewIdParameter.ParameterName = "@ReviewId";
    reviewIdParameter.Value = this.GetId();

    cmd.Parameters.Add(reviewIdParameter);
    cmd.ExecuteNonQuery();

    if (conn != null)
    {
      conn.Close();
    }
  }

  public void Update(string newDescription)
  {
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr;
    conn.Open();

    SqlCommand cmd = new SqlCommand("UPDATE review SET description = @NewDescription OUTPUT INSERTED.description WHERE id = @ReviewId;", conn);

    SqlParameter newDescriptionParameter = new SqlParameter();
    newDescriptionParameter.ParameterName = "@NewDescription";
    newDescriptionParameter.Value = newDescription;
    cmd.Parameters.Add(newDescriptionParameter);


    SqlParameter reviewIdParameter = new SqlParameter();
    reviewIdParameter.ParameterName = "@ReviewId";
    reviewIdParameter.Value = this.GetId();
    cmd.Parameters.Add(reviewIdParameter);
    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      this._description = rdr.GetString(0);
    }

    if (rdr != null)
    {
      rdr.Close();
    }

    if (conn != null)
    {
      conn.Close();
    }
  }

  public int GetRestaurantId()
  {
    return _restaurantId;
  }
  public void SetRestaurantId(int newRestaurantId)
  {
    _restaurantId = newRestaurantId;
  }

 public int GetId()
 {
   return _id;
 }
 public string GetDescription()
 {
   return _description;
 }
 public void SetDescription(string newDescription)
 {
   _description = newDescription;
 }
 public string GetUsername()
 {
   return _username;
 }
 public void SetUsername( string newUsername)
 {
   _username = newUsername;
 }

 public static List<Review> GetAll()
 {
   List<Review> allReviews = new List<Review>{};

   SqlConnection conn = DB.Connection();
   SqlDataReader rdr = null;
   conn.Open();

   SqlCommand cmd = new SqlCommand("SELECT * FROM review;", conn);
   rdr = cmd.ExecuteReader();

   while(rdr.Read())
   {

     string reviewDescription = rdr.GetString(0);
     string reviewUsername = rdr.GetString(1);
     int reviewRestaurantId = rdr.GetInt32(2);
     int reviewId = rdr.GetInt32(3);

     Review newReview = new Review(reviewDescription, reviewUsername, reviewRestaurantId, reviewId);
     allReviews.Add(newReview);
   }

   if (rdr != null)
   {
     rdr.Close();
   }
   if (conn != null)
   {
     conn.Close();
   }

   return allReviews;
 }



 public void Save()
 {
   SqlConnection conn = DB.Connection();
   SqlDataReader rdr;
   conn.Open();

   SqlCommand cmd = new SqlCommand("INSERT INTO review (description, username, restaurant_id) OUTPUT INSERTED.id VALUES (@ReviewDescription, @ReviewUsername, @RestaurantId);", conn);

   SqlParameter descriptionParameter = new SqlParameter();
   descriptionParameter.ParameterName = "@ReviewDescription";
   descriptionParameter.Value = this.GetDescription();
   cmd.Parameters.Add(descriptionParameter);

   SqlParameter restaurantIdParameter = new SqlParameter();
   restaurantIdParameter.ParameterName = "@RestaurantId";
   restaurantIdParameter.Value = this.GetRestaurantId();
   cmd.Parameters.Add(restaurantIdParameter);

   SqlParameter usernameParameter = new SqlParameter();
   usernameParameter.ParameterName = "@ReviewUsername";
   usernameParameter.Value = this.GetUsername();
   cmd.Parameters.Add(usernameParameter);

   rdr = cmd.ExecuteReader();

   while(rdr.Read())
   {
     this._id = rdr.GetInt32(0);
   }
   if (rdr != null)
   {
     rdr.Close();
   }
   if (conn != null)
   {
     conn.Close();
   }
 }

 public static Review Find(int id)
 {
   SqlConnection conn = DB.Connection();
   SqlDataReader rdr = null;
   conn.Open();

   SqlCommand cmd = new SqlCommand("SELECT * FROM review WHERE id = @ReviewId;", conn);
   SqlParameter reviewIdParameter = new SqlParameter();
   reviewIdParameter.ParameterName = "@ReviewId";
   reviewIdParameter.Value = id.ToString();
   cmd.Parameters.Add(reviewIdParameter);
   rdr = cmd.ExecuteReader();

   int foundReviewId = 0;
   string foundReviewDescription = null;
   string foundReviewUsername = null;
   int foundRestaurantId = 0;


   while(rdr.Read())
   {
     foundReviewDescription = rdr.GetString(0);
     foundReviewUsername = rdr.GetString(1);
     foundRestaurantId = rdr.GetInt32(2);
     foundReviewId = rdr.GetInt32(3);
   }
   Review foundReview = new Review(foundReviewDescription, foundReviewUsername, foundRestaurantId, foundReviewId);

   if (rdr != null)
   {
     rdr.Close();
   }
   if (conn != null)
   {
     conn.Close();
   }

   return foundReview;
 }

 public static void DeleteAll()
 {
   SqlConnection conn = DB.Connection();
   conn.Open();
   SqlCommand cmd = new SqlCommand("DELETE FROM review;", conn);
   cmd.ExecuteNonQuery();
 }
}
}
