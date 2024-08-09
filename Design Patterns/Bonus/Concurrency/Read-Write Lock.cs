using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ThreadSafeRoboticsInventory
{
  private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
  private Dictionary<string, int> _inventory = new Dictionary<string, int>();

  public void AddComponent(string component, int quantity)
  {
    _lock.EnterWriteLock();
    try
    {
      if (_inventory.ContainsKey(component))
      {
        _inventory[component] += quantity;
      }
      else
      {
        _inventory[component] = quantity;
      }
      Console.WriteLine($"Added {quantity} {component}(s). New quantity: {_inventory[component]}");
    }
    finally
    {
      _lock.ExitWriteLock();
    }
  }

  public int GetComponentQuantity(string component)
  {
    _lock.EnterReadLock();
    try
    {
      return _inventory.TryGetValue(component, out int quantity) ? quantity : 0;
    }
    finally
    {
      _lock.ExitReadLock();
    }
  }

  public void DisplayInventory()
  {
    _lock.EnterReadLock();
    try
    {
      Console.WriteLine("Current Robotics Inventory:");
      foreach (var item in _inventory)
      {
        Console.WriteLine($"{item.Key}: {item.Value}");
      }
    }
    finally
    {
      _lock.ExitReadLock();
    }
  }
}

public class Program
{
  public static async Task Main()
  {
    var roboticsInventory = new ThreadSafeRoboticsInventory();

    var tasks = new List<Task>
        {
            Task.Run(() => roboticsInventory.AddComponent("IMU Sensor", 5)),
            Task.Run(() => roboticsInventory.AddComponent("Servo Motor", 10)),
            Task.Run(() => roboticsInventory.AddComponent("Distance Sensor", 8)),
            Task.Run(() => roboticsInventory.AddComponent("IMU Sensor", 3)),
            Task.Run(() => Console.WriteLine($"IMU Sensor quantity: {roboticsInventory.GetComponentQuantity("IMU Sensor")}")),
            Task.Run(() => Console.WriteLine($"Servo Motor quantity: {roboticsInventory.GetComponentQuantity("Servo Motor")}")),
            Task.Run(() => roboticsInventory.DisplayInventory())
        };

    await Task.WhenAll(tasks);

    roboticsInventory.DisplayInventory();
  }
}