// using System;
// using System.Globalization;
// using System.Data;
// using HelloWorld.Models;
// using HelloWorld.Data;
// using Dapper;
// using Microsoft.Data.SqlClient;
// using Microsoft.Extensions.Configuration;
// using System.Text.Json;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Serialization;
// using AutoMapper;

// namespace HelloWorld
// {
//   internal class Programs
//   {

//     static void Mains(string[] args)
//     {
//       IConfiguration config = new ConfigurationBuilder()
//       .AddJsonFile("appsettings.json")
//       .Build();
//       DapperContext dapper = new DapperContext(config);
//       // DbContextEF entityFramework = new DbContextEF(config);
//       Computer myComputer = new Computer()
//       {
//         Motherboard = "Z690",
//         CPUCores = 8,
//         Price = 129.99m,
//         HasLTE = true,
//         HasWifi = true,
//         VideoCard = "RTX 4080",
//         ReleaseDate = DateTime.Now

//       };

//       // entityFramework.Add(myComputer);
//       // entityFramework.SaveChanges();
//       // int insertedRow = dbconnection.Execute(sqlCommand);
//       // Console.WriteLine(insertedRow);

//       // string sqlCommand = @"SELECT * FROM TutorialAppSchema.Computer;";
//       // File.WriteAllText("logs.txt", sqlCommand);
//       // using StreamWriter openFile = new("logs.txt", append: true);
//       // // Console.WriteLine(sqlCommand);
//       // openFile.WriteLine(sqlCommand);
//       // openFile.Close();
//       // Console.WriteLine(computersJSON);
//       // IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJSON, jsonOptions);
//       string computersJSON = File.ReadAllText("ComputersSnake.json");

//       Mapper autoMapper = new Mapper(new MapperConfiguration(config =>
//       {
//         config.CreateMap<ComputerSnake, Computer>()
//         .ForMember(dest => dest.ComputerId,
//         opt => opt.MapFrom(src => src.computer_id)
//         )
//         .ForMember(dest => dest.CPUCores,
//         opt => opt.MapFrom(src => src.cpu_cores)
//         )
//         .ForMember(dest => dest.HasLTE,
//         opt => opt.MapFrom(src => src.has_lte)
//         )
//         .ForMember(dest => dest.HasWifi,
//         opt => opt.MapFrom(src => src.has_wifi)
//         )
//         .ForMember(dest => dest.VideoCard,
//         opt => opt.MapFrom(src => src.video_card)
//         )
//         .ForMember(dest => dest.Price,
//         opt => opt.MapFrom(src => src.price)
//         )
//         .ForMember(dest => dest.ReleaseDate,
//         opt => opt.MapFrom(src => src.release_date)
//         );
//       }));

//       IEnumerable<Computer>? computers = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJSON);

//       if (computers != null)
//       {
//         // IEnumerable<Computer> computersMapped = autoMapper.Map<IEnumerable<Computer>>(computers);
//         foreach (Computer singleComputer in computers)
//         {
//           Console.WriteLine(singleComputer.Motherboard);
//         }
//       }

//       // if (computers != null)
//       // {

//       //   foreach (Computer singleComputer in computers)
//       //   {
//       //     string sqlCommand = $@"INSERT INTO TutorialAppSchema.Computer
//       // VALUES (
//       // '{EscapeSingleQuotes(singleComputer.Motherboard)}', 
//       // '{singleComputer.CPUCores}',
//       // '{singleComputer.HasWifi}',
//       // '{singleComputer.HasLTE}',
//       // '{singleComputer.ReleaseDate?.ToString("yyyy-MM-dd")}',
//       // '{singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)}',
//       // '{EscapeSingleQuotes(singleComputer.VideoCard)}'
//       // );";
//       //     dapper.Execute(sqlCommand);

//       //   }
//       //   JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
//       //   {
//       //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//       //   };
//       //   JsonSerializerSettings settings = new JsonSerializerSettings()
//       //   {
//       //     ContractResolver = new CamelCasePropertyNamesContractResolver()
//       //   };

//       //   string computersNewtonSoft = JsonConvert.SerializeObject(computers, settings);
//       //   string computersSystem = System.Text.Json.JsonSerializer.Serialize(computers, jsonOptions);

//       //   File.WriteAllText("JsonNewtonsoft.json", computersNewtonSoft);

//       //   File.WriteAllText("JsonSystem.json", computersSystem);
//       // }

//       // IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlCommand);

//       //   IEnumerable<Computer>? computers = entityFramework.Computer?.ToList<Computer>();

//       // if (computers != null) {

//       //   foreach(Computer singleComputer in computers)
//       //   {
//       //     Console.WriteLine(singleComputer.ComputerId);
//       //     Console.WriteLine(singleComputer.Motherboard);
//       //     Console.WriteLine(singleComputer.CPUCores);
//       //     Console.WriteLine(singleComputer.HasLTE);
//       //     Console.WriteLine(singleComputer.HasWifi);
//       //     Console.WriteLine(singleComputer.ReleaseDate);
//       //     Console.WriteLine(singleComputer.VideoCard);
//       //   }
//       // }

//       static string EscapeSingleQuotes(string input)
//       {

//         return input.Replace("'", "''");
//       }
//     }

//   }
// }