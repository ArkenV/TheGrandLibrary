using System;

// Component interface
public interface IBobaTea
{
  string GetDescription();
  double GetCost();
}

// Concrete component
public class BasicBlackTea : IBobaTea
{
  public string GetDescription()
  {
    return "Basic Black Tea";
  }

  public double GetCost()
  {
    return 3.0;
  }
}

// Base decorator
public abstract class BobaTeaDecorator : IBobaTea
{
  protected IBobaTea _bobaTea;

  public BobaTeaDecorator(IBobaTea bobaTea)
  {
    _bobaTea = bobaTea;
  }

  public virtual string GetDescription()
  {
    return _bobaTea.GetDescription();
  }

  public virtual double GetCost()
  {
    return _bobaTea.GetCost();
  }
}

// Concrete decorators
public class TapiocaPearlsDecorator : BobaTeaDecorator
{
  public TapiocaPearlsDecorator(IBobaTea bobaTea) : base(bobaTea) { }

  public override string GetDescription()
  {
    return $"{_bobaTea.GetDescription()}, Tapioca Pearls";
  }

  public override double GetCost()
  {
    return _bobaTea.GetCost() + 0.5;
  }
}

public class FruitJellyDecorator : BobaTeaDecorator
{
  public FruitJellyDecorator(IBobaTea bobaTea) : base(bobaTea) { }

  public override string GetDescription()
  {
    return $"{_bobaTea.GetDescription()}, Fruit Jelly";
  }

  public override double GetCost()
  {
    return _bobaTea.GetCost() + 0.75;
  }
}

public class PuddingDecorator : BobaTeaDecorator
{
  public PuddingDecorator(IBobaTea bobaTea) : base(bobaTea) { }

  public override string GetDescription()
  {
    return $"{_bobaTea.GetDescription()}, Pudding";
  }

  public override double GetCost()
  {
    return _bobaTea.GetCost() + 1.0;
  }
}

class Program
{
  static void Main(string[] args)
  {
    IBobaTea bobaTea = new BasicBlackTea();
    Console.WriteLine($"{bobaTea.GetDescription()} costs: ${bobaTea.GetCost()}");

    bobaTea = new TapiocaPearlsDecorator(bobaTea);
    Console.WriteLine($"{bobaTea.GetDescription()} costs: ${bobaTea.GetCost()}");

    bobaTea = new FruitJellyDecorator(bobaTea);
    Console.WriteLine($"{bobaTea.GetDescription()} costs: ${bobaTea.GetCost()}");

    bobaTea = new PuddingDecorator(bobaTea);
    Console.WriteLine($"{bobaTea.GetDescription()} costs: ${bobaTea.GetCost()}");
  }
}