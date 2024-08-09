using System;
using System.Collections.Generic;

// The product class
public class Computer
{
  public string CPU { get; set; }
  public int RAM { get; set; }
  public int Storage { get; set; }
  public string GraphicsCard { get; set; }
  public List<string> Peripherals { get; set; }

  public void DisplaySpecs()
  {
    Console.WriteLine("Computer Specifications:");
    Console.WriteLine($"CPU: {CPU}");
    Console.WriteLine($"RAM: {RAM}GB");
    Console.WriteLine($"Storage: {Storage}GB");
    Console.WriteLine($"Graphics Card: {GraphicsCard}");
    Console.WriteLine("Peripherals:");
    foreach (var peripheral in Peripherals)
    {
      Console.WriteLine($"- {peripheral}");
    }
  }
}

// The builder interface
public interface IComputerBuilder
{
  IComputerBuilder SetCPU(string cpu);
  IComputerBuilder SetRAM(int ramGB);
  IComputerBuilder SetStorage(int storageGB);
  IComputerBuilder SetGraphicsCard(string graphicsCard);
  IComputerBuilder AddPeripheral(string peripheral);
  Computer Build();
}

// Concrete builder
public class ComputerBuilder : IComputerBuilder
{
  private Computer _computer = new Computer();

  public IComputerBuilder SetCPU(string cpu)
  {
    _computer.CPU = cpu;
    return this;
  }

  public IComputerBuilder SetRAM(int ramGB)
  {
    _computer.RAM = ramGB;
    return this;
  }

  public IComputerBuilder SetStorage(int storageGB)
  {
    _computer.Storage = storageGB;
    return this;
  }

  public IComputerBuilder SetGraphicsCard(string graphicsCard)
  {
    _computer.GraphicsCard = graphicsCard;
    return this;
  }

  public IComputerBuilder AddPeripheral(string peripheral)
  {
    if (_computer.Peripherals == null)
      _computer.Peripherals = new List<string>();

    _computer.Peripherals.Add(peripheral);
    return this;
  }

  public Computer Build()
  {
    return _computer;
  }
}

class Program
{
  static void Main(string[] args)
  {
    var builder = new ComputerBuilder();

    Computer gamingPC = builder
        .SetCPU("Intel i9-11900K")
        .SetRAM(32)
        .SetStorage(1000)
        .SetGraphicsCard("NVIDIA RTX 3080")
        .AddPeripheral("Gaming Mouse")
        .AddPeripheral("Mechanical Keyboard")
        .AddPeripheral("27-inch 4K Monitor")
        .Build();

    gamingPC.DisplaySpecs();

    builder = new ComputerBuilder();

    Computer officePC = builder
        .SetCPU("Intel i5-11400")
        .SetRAM(16)
        .SetStorage(512)
        .SetGraphicsCard("Integrated Intel UHD Graphics")
        .AddPeripheral("Wireless Mouse")
        .AddPeripheral("Ergonomic Keyboard")
        .Build();

    Console.WriteLine("\n");
    officePC.DisplaySpecs();
  }
}