using System;

public interface IWarrior
{
  IWarrior Clone();
  void Display();
}

public class Viking : IWarrior
{
  public string Name { get; set; }
  public string Clan { get; set; }
  public string Weapon { get; set; }

  public Viking(string name, string clan, string weapon)
  {
    Name = name;
    Clan = clan;
    Weapon = weapon;
  }

  public IWarrior Clone()
  {
    return new Viking(Name, Clan, Weapon);
  }

  public void Display()
  {
    Console.WriteLine($"Viking: {Name}, Clan: {Clan}, Weapon: {Weapon}");
  }
}

public class Spartan : IWarrior
{
  public string Name { get; set; }
  public string Rank { get; set; }
  public string Shield { get; set; }

  public Spartan(string name, string rank, string shield)
  {
    Name = name;
    Rank = rank;
    Shield = shield;
  }

  public IWarrior Clone()
  {
    return new Spartan(Name, Rank, Shield);
  }

  public void Display()
  {
    Console.WriteLine($"Spartan: {Name}, Rank: {Rank}, Shield: {Shield}");
  }
}

public class WarriorFactory
{
  private IWarrior _viking;
  private IWarrior _spartan;

  public WarriorFactory()
  {
    _viking = new Viking("DefaultViking", "Norwegian", "Axe");
    _spartan = new Spartan("DefaultSpartan", "Hoplite", "Aspis");
  }

  public IWarrior CreateViking()
  {
    return _viking.Clone();
  }

  public IWarrior CreateSpartan()
  {
    return _spartan.Clone();
  }
}

class Program
{
  static void Main(string[] args)
  {
    WarriorFactory factory = new WarriorFactory();

    // Create and customize Vikings
    IWarrior ragnar = factory.CreateViking();
    ((Viking)ragnar).Name = "Ragnar Lothbrok";
    ((Viking)ragnar).Clan = "Lothbrok";
    ((Viking)ragnar).Weapon = "Sword and Axe";

    IWarrior bjorn = factory.CreateViking();
    ((Viking)bjorn).Name = "Bjorn Ironside";
    ((Viking)bjorn).Clan = "Ironside";
    ((Viking)bjorn).Weapon = "Sword";

    // Create and customize Spartans
    IWarrior leonidas = factory.CreateSpartan();
    ((Spartan)leonidas).Name = "Leonidas I";
    ((Spartan)leonidas).Rank = "King";
    ((Spartan)leonidas).Shield = "Lambda Shield";

    IWarrior brasidas = factory.CreateSpartan();
    ((Spartan)brasidas).Name = "Brasidas";
    ((Spartan)brasidas).Rank = "General";
    ((Spartan)brasidas).Shield = "Spartan Shield";

    // Display all warriors
    ragnar.Display();
    bjorn.Display();
    leonidas.Display();
    brasidas.Display();
  }
}