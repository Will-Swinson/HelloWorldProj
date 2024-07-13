using System;
using System.Globalization;
using System.Data;
using HelloWorld.Models;
using HelloWorld.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;

namespace HelloWorld
{
  internal class Program
  {

    static void Main(string[] args)
    {
      IConfiguration config = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json")
      .Build();
      DapperContext dapper = new DapperContext(config);
      // DbContextEF entityFramework = new DbContextEF(config);
      Computer myComputer = new Computer()
      {
        Motherboard = "Z690",
        CPUCores = 8,
        Price = 129.99m,
        HasLTE = true,
        HasWifi = true,
        VideoCard = "RTX 4080",
        ReleaseDate = DateTime.Now

      };
     
      // entityFramework.Add(myComputer);
      // entityFramework.SaveChanges();
      // string sqlCommand = $@"INSERT INTO TutorialAppSchema.Computer
      // VALUES (
      // '{myComputer.Motherboard}', 
      // '{myComputer.CPUCores}',
      // '{myComputer.HasWifi}',
      // '{myComputer.HasLTE}',
      // '{myComputer.ReleaseDate.ToString("yyyy-MM-dd")}',
      // '{myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)}',
      // '{myComputer.VideoCard}'
      // );";
      // int insertedRow = dbconnection.Execute(sqlCommand);
      // Console.WriteLine(insertedRow);

      // string sqlCommand = @"SELECT * FROM TutorialAppSchema.Computer;";
      // File.WriteAllText("logs.txt", sqlCommand);
      // using StreamWriter openFile = new("logs.txt", append: true);
      // // Console.WriteLine(sqlCommand);
      // openFile.WriteLine(sqlCommand);
      // openFile.Close();
      // Console.WriteLine(computersJSON);
      // JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
      // {
      //   PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      // };
      // IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJSON, jsonOptions);
      string computersJSON = File.ReadAllText("Computers.json");
      IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJSON);


      if (computers != null)
      {

      // foreach(Computer singleComputer in computers)
      // {
      //   Console.WriteLine(singleComputer.Motherboard);
      // }
    string computersNewtonSoft = JsonConvert.SerializeObject(computers);
    string computersSystem = System.Text.Json.JsonSerializer.Serialize(computers);

    File.WriteAllText("JsonNewtonsoft.json", computersNewtonSoft);

    File.WriteAllText("JsonSystem.json", computersSystem);
      }

      // IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlCommand);

    //   IEnumerable<Computer>? computers = entityFramework.Computer?.ToList<Computer>();

    // if (computers != null) {

    //   foreach(Computer singleComputer in computers)
    //   {
    //     Console.WriteLine(singleComputer.ComputerId);
    //     Console.WriteLine(singleComputer.Motherboard);
    //     Console.WriteLine(singleComputer.CPUCores);
    //     Console.WriteLine(singleComputer.HasLTE);
    //     Console.WriteLine(singleComputer.HasWifi);
    //     Console.WriteLine(singleComputer.ReleaseDate);
    //     Console.WriteLine(singleComputer.VideoCard);
    //   }
    // }

    }

  }
}