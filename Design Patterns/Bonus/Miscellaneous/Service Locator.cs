using System;
using System.Collections.Generic;

public interface ILogger
{
  void Log(string message);
}

public interface IEmailService
{
  void SendEmail(string to, string subject, string body);
}

public class ConsoleLogger : ILogger
{
  public void Log(string message)
  {
    Console.WriteLine($"Log: {message}");
  }
}

public class SmtpEmailService : IEmailService
{
  public void SendEmail(string to, string subject, string body)
  {
    Console.WriteLine($"Sending email to {to} with subject '{subject}'");
  }
}

public class ServiceLocator
{
  private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

  public static void RegisterService<T>(T service)
  {
    services[typeof(T)] = service;
  }

  public static T GetService<T>()
  {
    if (services.TryGetValue(typeof(T), out object service))
    {
      return (T)service;
    }
    throw new Exception($"Service of type {typeof(T)} not registered.");
  }
}

public class UserManager
{
  private readonly ILogger logger;
  private readonly IEmailService emailService;

  public UserManager()
  {
    logger = ServiceLocator.GetService<ILogger>();
    emailService = ServiceLocator.GetService<IEmailService>();
  }

  public void CreateUser(string username, string email)
  {
    logger.Log($"Creating user: {username}");

    emailService.SendEmail(email, "Welcome!", "Glad to see you joined!");
  }
}

class Program
{
  static void Main(string[] args)
  {
    ServiceLocator.RegisterService<ILogger>(new ConsoleLogger());
    ServiceLocator.RegisterService<IEmailService>(new SmtpEmailService());

    var userManager = new UserManager();
    userManager.CreateUser("Danny", "dannybetancourt@protonmail.com");
  }
}