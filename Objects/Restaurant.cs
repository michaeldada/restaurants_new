using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurants
{
  public class Restaurant
  {
    private int _id;
    private string _description;
    private int _cuisineId;
    private string _address;
    private string _phone;

    public Restaurant(string Description, int CuisineId, string Address, string Phone, int Id = 0)
    {
      _id = Id;
      _description = Description;
      _cuisineId = CuisineId;
      _address = Address;
      _phone = Phone;
    }

    public override bool Equals(System.Object otherRestaurant)
     {
       if (!(otherRestaurant is Restaurant))
       {
         return false;
       }
       else
       {
         Restaurant newRestaurant = (Restaurant) otherRestaurant;
         bool idEquality = (this.GetId() == newRestaurant.GetId());
         bool descriptionEquality = (this.GetDescription() == newRestaurant.GetDescription());
         bool cuisineEquality = this.GetCuisineId() == newRestaurant.GetCuisineId();
         bool addressEquality = this.GetAddress() == newRestaurant.GetAddress();
         return (idEquality && descriptionEquality && cuisineEquality && addressEquality);
       }
     }

     public void Delete()
     {
       SqlConnection conn = DB.Connection();
       conn.Open();

       SqlCommand cmd = new SqlCommand("DELETE FROM restaurant WHERE id = @RestaurantId;", conn);

       SqlParameter restaurantIdParameter = new SqlParameter();
       restaurantIdParameter.ParameterName = "@RestaurantId";
       restaurantIdParameter.Value = this.GetId();

       cmd.Parameters.Add(restaurantIdParameter);
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

       SqlCommand cmd = new SqlCommand("UPDATE restaurant SET description = @NewDescription OUTPUT INSERTED.description WHERE id = @RestaurantId;", conn);

       SqlParameter newDescriptionParameter = new SqlParameter();
       newDescriptionParameter.ParameterName = "@NewDescription";
       newDescriptionParameter.Value = newDescription;
       cmd.Parameters.Add(newDescriptionParameter);


       SqlParameter restaurantIdParameter = new SqlParameter();
       restaurantIdParameter.ParameterName = "@RestaurantId";
       restaurantIdParameter.Value = this.GetId();
       cmd.Parameters.Add(restaurantIdParameter);
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

     public int GetCuisineId()
     {
       return _cuisineId;
     }
     public void SetCuisineId(int newCuisineId)
     {
       _cuisineId = newCuisineId;
     }

     public string GetAddress()
     {
       return _address;
     }
     public void SetAddress(string newAddress)
     {
       _address = newAddress;
     }
     public string GetPhone()
     {
       return _phone;
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
    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantDescription = rdr.GetString(1);
        int restaurantCuisineId = rdr.GetInt32(2);
        string restaurantAddress = rdr.GetString(3);
        string restaurantPhone = rdr.GetString(4);
        Restaurant newRestaurant = new Restaurant(restaurantDescription, restaurantCuisineId, restaurantAddress, restaurantPhone, restaurantId);
        allRestaurants.Add(newRestaurant);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allRestaurants;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO restaurant (description, cuisine_id, address, phone) OUTPUT INSERTED.id VALUES (@RestaurantDescription, @RestaurantCuisineId, @RestaurantAddress, @RestaurantPhone);", conn);

      SqlParameter descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@RestaurantDescription";
      descriptionParameter.Value = this.GetDescription();
      cmd.Parameters.Add(descriptionParameter);

      SqlParameter cuisineIdParameter = new SqlParameter();
      cuisineIdParameter.ParameterName = "@RestaurantCuisineId";
      cuisineIdParameter.Value = this.GetCuisineId();
      cmd.Parameters.Add(cuisineIdParameter);

      SqlParameter addressParameter = new SqlParameter();
      addressParameter.ParameterName = "@RestaurantAddress";
      addressParameter.Value = this.GetAddress();
      cmd.Parameters.Add(addressParameter);

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@RestaurantPhone";
      phoneParameter.Value = this.GetPhone();
      cmd.Parameters.Add(phoneParameter);

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
    public static Restaurant Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant WHERE id = @RestaurantId;", conn);
      SqlParameter restaurantIdParameter = new SqlParameter();
      restaurantIdParameter.ParameterName = "@RestaurantId";
      restaurantIdParameter.Value = id.ToString();
      cmd.Parameters.Add(restaurantIdParameter);
      rdr = cmd.ExecuteReader();

      int foundRestaurantId = 0;
      string foundRestaurantDescription = null;
      int foundRestaurantCuisineId = 0;
      string foundRestaurantAddress = null;
      string foundRestaurantPhone = null;
      while(rdr.Read())
      {
        foundRestaurantId = rdr.GetInt32(0);
        foundRestaurantDescription = rdr.GetString(1);
        foundRestaurantCuisineId = rdr.GetInt32(2);
        foundRestaurantAddress = rdr.GetString(3);
        foundRestaurantPhone = rdr.GetString(4);
      }
      Restaurant foundRestaurant = new Restaurant(foundRestaurantDescription, foundRestaurantCuisineId, foundRestaurantAddress, foundRestaurantPhone, foundRestaurantId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundRestaurant;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM restaurant;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
