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
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace HelloWorld
{
  internal class Program
  {

    static async Task Main(string[] args)
    {
      Task firstTask = new Task(() =>
      {
        Thread.Sleep(100);
        Console.WriteLine("First Task");
      });

      firstTask.Start();

      Task secondTask = ConsoleAfterDelayAsync("Second Task", 150);
      ConsoleAfterDelay("Delay", 75);
      Task thirdTask = ConsoleAfterDelayAsync("Third Task", 50);

      Console.WriteLine("After Task");
      await secondTask;
      await firstTask;
      await thirdTask;
    }


    static void ConsoleAfterDelay(string text, int delayTime)
    {
      Thread.Sleep(delayTime);
      Console.WriteLine(text);
    }
    static async Task ConsoleAfterDelayAsync(string text, int delayTime)
    {
      await Task.Delay(delayTime);
      Console.WriteLine(text);
    }
  }
}