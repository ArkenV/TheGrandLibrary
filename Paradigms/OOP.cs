using System;
using System.Collections.Generic;

// Abstract base class demonstrating abstraction and encapsulation
public abstract class ChemicalElement
{
  public string Symbol { get; private set; }
  public int AtomicNumber { get; private set; }
  protected double _electronegativity;

  public ChemicalElement(string symbol, int atomicNumber, double electronegativity)
  {
    Symbol = symbol;
    AtomicNumber = atomicNumber;
    _electronegativity = electronegativity;
  }

  // Abstract method demonstrating polymorphism
  public abstract void DescribeProperties();

  public virtual double GetElectronegativity()
  {
    return _electronegativity;
  }
}

// Derived class demonstrating inheritance
public class Metal : ChemicalElement
{
  public double Conductivity { get; private set; }

  public Metal(string symbol, int atomicNumber, double electronegativity, double conductivity)
      : base(symbol, atomicNumber, electronegativity)
  {
    Conductivity = conductivity;
  }

  public override void DescribeProperties()
  {
    Console.WriteLine($"{Symbol} is a metal with atomic number {AtomicNumber} and conductivity {Conductivity}.");
  }
}

// Another derived class demonstrating polymorphism
public class NonMetal : ChemicalElement
{
  public bool IsGasAtRoomTemperature { get; private set; }

  public NonMetal(string symbol, int atomicNumber, double electronegativity, bool isGasAtRoomTemperature)
      : base(symbol, atomicNumber, electronegativity)
  {
    IsGasAtRoomTemperature = isGasAtRoomTemperature;
  }

  public override void DescribeProperties()
  {
    Console.WriteLine($"{Symbol} is a non-metal with atomic number {AtomicNumber}. Gas at room temperature: {IsGasAtRoomTemperature}.");
  }

  public override double GetElectronegativity()
  {
    return _electronegativity * 1.5;
  }
}

// Composition
public class ChemicalCompound
{
  private List<ChemicalElement> _elements = new List<ChemicalElement>();
  public string Name { get; private set; }

  public ChemicalCompound(string name)
  {
    Name = name;
  }

  public void AddElement(ChemicalElement element)
  {
    _elements.Add(element);
  }

  public void DescribeCompound()
  {
    Console.WriteLine($"Compound: {Name}");
    foreach (var element in _elements)
    {
      element.DescribeProperties();
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    Metal iron = new Metal("Fe", 26, 1.83, 10.04);
    NonMetal oxygen = new NonMetal("O", 8, 3.44, true);

    iron.DescribeProperties();
    oxygen.DescribeProperties();

    Console.WriteLine($"Iron electronegativity: {iron.GetElectronegativity()}");
    Console.WriteLine($"Oxygen electronegativity: {oxygen.GetElectronegativity()}");

    ChemicalCompound rustCompound = new ChemicalCompound("Iron Oxide (Rust)");
    rustCompound.AddElement(iron);
    rustCompound.AddElement(oxygen);

    rustCompound.DescribeCompound();
  }
}