using System;
using System.IO;
using System.Data.SqlClient;

enum LoggerType
{
  Console,
  File,
  Database
}

// Abstract contract - required members for all loggers
public interface ILogger
{
  void Log(string message);
}

public class ConsoleLogger : ILogger
{
  public void Log(string message)
  {
    Console.WriteLine($"[{DateTime.Now}] {message}");
  }
}

// Concrete loggers
public class FileLogger : ILogger
{
  private string filePath;

  public FileLogger(string path)
  {
    filePath = path;
  }

  public void Log(string message)
  {
    using (StreamWriter sw = File.AppendText(filePath))
    {
      sw.WriteLine($"[{DateTime.Now}] {message}");
    }
  }
}

public class DatabaseLogger : ILogger
{
  private string connectionString;

  public DatabaseLogger(string connString)
  {
    connectionString = connString;
  }

  public void Log(string message)
  {
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
      string query = "INSERT INTO Logs (Timestamp, Message) VALUES (@timestamp, @message)";
      
      using (SqlCommand command = new SqlCommand(query, connection))
      {
        command.Parameters.AddWithValue("@timestamp", DateTime.Now);
        command.Parameters.AddWithValue("@message", message);
        
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }
}

// Creator
public static class LoggerFactory
{
  public static ILogger CreateLogger(LoggerType loggerType, string param = null)
  {
    switch (loggerType)
    {
      case LoggerType.Console:
        return new ConsoleLogger();
      case LoggerType.File:
        if (string.IsNullOrEmpty(param))
          throw new ArgumentException("File path is required for FileLogger");
        return new FileLogger(param);
      case LoggerType.Database:
        if (string.IsNullOrEmpty(param))
          throw new ArgumentException("Connection string is required for DatabaseLogger");
        return new DatabaseLogger(param);
      default:
        throw new ArgumentException("Unknown logger type", nameof(loggerType));
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    // These could be read from configuration
    LoggerType loggerType = LoggerType.File;
    string logFilePath = @"C:\logs\app.log";
    
    ILogger logger = LoggerFactory.CreateLogger(loggerType, logFilePath); // This could be injected
    
    try
    {
      logger.Log("Application started");
    }
    catch (Exception ex)
    {
      logger.Log($"An error occurred: {ex.Message}");
    }
    finally
    {
      logger.Log("Application ended");
    }
  }
}