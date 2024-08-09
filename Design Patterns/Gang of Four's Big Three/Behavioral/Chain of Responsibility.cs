using System;
using System.Collections.Generic;

// Abstract handler
abstract class LoginHandler
{
  protected LoginHandler _nextHandler;

  public void SetNextHandler(LoginHandler handler)
  {
    _nextHandler = handler;
  }

  public abstract bool HandleLogin(string username, string password);
}

// Concrete handlers
class CredentialValidator : LoginHandler
{
  private Dictionary<string, string> _userCredentials = new Dictionary<string, string>
    {
        { "user1", "password1" },
        { "admin", "adminpass" }
    };

  public override bool HandleLogin(string username, string password)
  {
    if (_userCredentials.TryGetValue(username, out string storedPassword) && storedPassword == password)
    {
      Console.WriteLine("Credentials validated successfully.");
      return _nextHandler?.HandleLogin(username, password) ?? true;
    }
    else
    {
      Console.WriteLine("Invalid credentials. Login failed.");
      return false;
    }
  }
}

class AdminRightsChecker : LoginHandler
{
  private HashSet<string> _adminUsers = new HashSet<string> { "admin" };

  public override bool HandleLogin(string username, string password)
  {
    if (_adminUsers.Contains(username))
    {
      Console.WriteLine("Admin rights confirmed.");
    }
    else
    {
      Console.WriteLine("Regular user rights applied.");
    }
    return _nextHandler?.HandleLogin(username, password) ?? true;
  }
}

class CacheChecker : LoginHandler
{
  private Dictionary<string, DateTime> _loginCache = new Dictionary<string, DateTime>();

  public override bool HandleLogin(string username, string password)
  {
    if (_loginCache.TryGetValue(username, out DateTime lastLogin) && (DateTime.Now - lastLogin).TotalMinutes < 30)
    {
      Console.WriteLine("Login result fetched from cache.");
      return true;
    }
    else
    {
      _loginCache[username] = DateTime.Now;
      Console.WriteLine("Login result cached.");
      return _nextHandler?.HandleLogin(username, password) ?? true;
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    var credentialValidator = new CredentialValidator();
    var adminRightsChecker = new AdminRightsChecker();
    var cacheChecker = new CacheChecker();

    credentialValidator.SetNextHandler(adminRightsChecker);
    adminRightsChecker.SetNextHandler(cacheChecker);

    Console.WriteLine("Attempt 1: Valid admin login");
    bool result = credentialValidator.HandleLogin("admin", "adminpass");
    Console.WriteLine($"Login successful: {result}\n");

    Console.WriteLine("Attempt 2: Valid user login");
    result = credentialValidator.HandleLogin("user1", "password1");
    Console.WriteLine($"Login successful: {result}\n");

    Console.WriteLine("Attempt 3: Invalid login");
    result = credentialValidator.HandleLogin("user2", "wrongpass");
    Console.WriteLine($"Login successful: {result}\n");

    Console.WriteLine("Attempt 4: Cached admin login");
    result = credentialValidator.HandleLogin("admin", "adminpass");
    Console.WriteLine($"Login successful: {result}");
  }
}