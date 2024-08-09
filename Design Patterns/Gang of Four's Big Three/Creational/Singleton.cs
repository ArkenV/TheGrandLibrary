using System;

public sealed class DatabaseConnection
{
  private static DatabaseConnection instance = null;
  private static readonly object padlock = new object();

  private string connectionString;

  private DatabaseConnection()
  {
    // Initialize the database details
  }

  public static DatabaseConnection Instance
  {
    get
    {
      if (instance == null)
      {
        lock (padlock)
        {
          if (instance == null)
          {
            instance = new DatabaseConnection();
          }
        }
      }
      return instance;
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    DatabaseConnection db1 = DatabaseConnection.Instance;
    DatabaseConnection db2 = DatabaseConnection.Instance;
    Console.WriteLine($"db1 and db2 are the same instance: {db1 == db2}");
  }
}