using System;
using Microsoft.Extensions.DependencyInjection;

// Messaging Service Contract
public interface IMessageService
{
  string GetMessage();
}

// Concrete Messaging Services
public class EmailService : IMessageService
{
  public string GetMessage()
  {
    return "This is an email message.";
  }
}

public class SMSService : IMessageService
{
  public string GetMessage()
  {
    return "This is an SMS message.";
  }
}

// A class that depends on an IMessageService implementation
public class NotificationManager
{
  private readonly IMessageService _messageService;

  // Constructor injection
  public NotificationManager(IMessageService messageService)
  {
    _messageService = messageService;
  }

  public void SendNotification()
  {
    string message = _messageService.GetMessage();
    Console.WriteLine($"Sending notification: {message}");
  }
}

class Program
{
  static void Main(string[] args)
  {
    // Setup DI
    var serviceProvider = new ServiceCollection()
        .AddTransient<IMessageService, EmailService>()
        .AddTransient<NotificationManager>()
        .BuildServiceProvider();

    // Use DI
    var notificationManager = serviceProvider.GetService<NotificationManager>();
    notificationManager.SendNotification();

    // Change the implementation
    var serviceProvider2 = new ServiceCollection()
        .AddTransient<IMessageService, SMSService>()
        .AddTransient<NotificationManager>()
        .BuildServiceProvider();

    var notificationManager2 = serviceProvider2.GetService<NotificationManager>();
    notificationManager2.SendNotification();
  }
}