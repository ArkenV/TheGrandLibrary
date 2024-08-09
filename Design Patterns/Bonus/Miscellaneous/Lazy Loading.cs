using System;
using System.Threading.Tasks;

public class ExpensiveResource
{
  public ExpensiveResource()
  {
    Console.WriteLine("ExpensiveResource: Initializing (this might take a while)...");
    Task.Delay(3000).Wait();
    Console.WriteLine("ExpensiveResource: Initialization complete.");
  }

  public void UseResource()
  {
    Console.WriteLine("ExpensiveResource: Resource is being used.");
  }
}

public class LazyLoadedService
{
  private Lazy<ExpensiveResource> _expensiveResource;

  public LazyLoadedService()
  {
    _expensiveResource = new Lazy<ExpensiveResource>(() => new ExpensiveResource());
  }

  public void PerformOperation()
  {
    Console.WriteLine("LazyLoadedService: Performing operation...");
    _expensiveResource.Value.UseResource();
  }
}

public class Program
{
  public static void Main()
  {
    Console.WriteLine("Program: Starting...");

    var service = new LazyLoadedService();
    Console.WriteLine("Program: LazyLoadedService created, but ExpensiveResource not yet initialized.");

    Console.WriteLine("Program: Doing some other work...");
    Task.Delay(2000).Wait();

    Console.WriteLine("Program: Now we need to use the expensive resource.");
    service.PerformOperation();

    Console.WriteLine("Program: Using the resource again (it's already initialized).");
    service.PerformOperation();

    Console.WriteLine("Program: Finished.");
  }
}