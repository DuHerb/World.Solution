using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
  public class City
  {
    private string _cityName;
    private int _cityId;
    private string _countryCode;
    private int _population;


    public City (string cityName, int cityId, string countryCode, int population)
    {
      _cityName = cityName;
      _cityId = cityId;
      _countryCode = countryCode;
      _population = population;
    }

    public string CityName {get=> _cityName;}
    public int CityId {get=> _cityId;}
    public string CountryId {get=> _countryCode;}
    public int Population {get=> _population;}

    public static List<City> GetCitiesByCountryCode(string countryCode)
    {
      string id = countryCode;
      List<City> selectedCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city WHERE CountryCode = '" + countryCode + "';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string cityName = rdr.GetString(1);
        int population = rdr.GetInt32(4);
        int cityId = rdr.GetInt32(0);

        City newCity = new City(cityName, cityId, countryCode, population);
        selectedCities.Add(newCity);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return selectedCities;
    }

    public static City GetCityById(int input)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city WHERE ID = '" + input + "';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      string cityName = "";
      int population = 0;
      int cityId = input;
      string countryCode = "";

      while (rdr.Read())
      {
        cityName = rdr.GetString(1);
        population = rdr.GetInt32(4);
        countryCode = rdr.GetString(2);
        // cityId = rdr.GetInt32(0);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      City newCity = new City(cityName, cityId,  countryCode, population);
      return newCity;
    }
  }
}
