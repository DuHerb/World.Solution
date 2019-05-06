using System.Collections.Generic;

namespace World.Models
{
  public class Country
  {
    private string countryName;
    private string countryCode;
    private int population;
    private int capitalId;

    public Country (string countryName, string countryCode, int population, int capitalId)
    {
      _countryName = countryName;
      _countryCode = countryCode;
      _population = population;
      _capital = capitalId;
        // _id = _instances.Count;
    }

    public string CountryName { get => _countryName; }
    public string CountryCode { get => _countryCode; }
    public string Population { get => _population; }
    public string CapitalId { get => _capitalId; }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM countries;";
      MySQlDataReader rdr = cmd.ExecuteReader() as MySQlDataReader;

      while (rdr.Read())
      {
        string countryCode = new string(rdr.GetChar(1));
        string countryName = new string(rdr.GetChar(2));
        int population = rdr.GetInt32(7);
        int capitalId = rdr.GetInt32(14);
        Country newCountry = new Country(countryName, countryCode, population, capitalId);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCountries;
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
