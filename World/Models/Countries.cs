using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
  public class Country
  {
    private string _countryName;
    private string _countryCode;
    private int _population;
    private int _capitalId;
    private string _headOfState;

    public Country (string countryName, string countryCode, int population, int capitalId, string headOfState)
    {
      _countryName = countryName;
      _countryCode = countryCode;
      _population = population;
      _capitalId = capitalId;
      _headOfState = headOfState;
        // _id = _instances.Count;
    }

    public string CountryName { get => _countryName; }
    public string CountryCode { get => _countryCode; }
    public int Population { get => _population; }
    public int CapitalId { get => _capitalId; }
    public string HeadOfState { get => _headOfState; }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string countryName = rdr.GetString(1);
        string countryCode = rdr.GetString(0);
        int population = rdr.GetInt32(6);
        int capitalId = 0;
        if(!rdr.IsDBNull(13))
        {
          capitalId = rdr.GetInt32(13);
        }

        string headOfState = "The Lordess Almighty Reese Lee and her court jester minion Dustin";


        if(!rdr.IsDBNull(12))
        {
          if(rdr.GetString(12) == "")
          {
            headOfState = "The Lordess Almighty Reese Lee and her court jester minion Dustin";
          }
        else
        {
          headOfState = rdr.GetString(12);
        }
      }

        Country newCountry = new Country(countryName, countryCode, population, capitalId, headOfState);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCountries;
    }

    public static Country GetCountryById(string countryId)
    {
      string id = countryId;
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE Code = '" + countryId + "';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      string countryName = "";
      string countryCode = id;
      int population = 0 ;
      int capitalId = 0;
      string headOfState = "The Lordess Almighty Reese Lee and her court jester minion Dustin";

      while (rdr.Read())
      {
       countryName = rdr.GetString(1);
        // string countryCode = rdr.GetString(0);
        population = rdr.GetInt32(6);
        capitalId = 0;
        if(!rdr.IsDBNull(13))
        {
          capitalId = rdr.GetInt32(13);
        }
        if(!rdr.IsDBNull(12))
        {
          if(rdr.GetString(12) == "")
          {
            headOfState = "The Lordess Almighty Reese Lee and her court jester minion Dustin";
          }
        else
        {
          headOfState = rdr.GetString(12);
        }
      }

        // selectedCountry.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      Country selectedCountry = new Country(countryName, countryCode, population, capitalId, headOfState);
      return selectedCountry;
    }

    // public static void ClearAll()
    // {
    //   _instances.Clear();
    // }
    //
    // public static Item Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }
  }
}
