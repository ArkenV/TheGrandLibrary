using System;
using System.Collections.Generic;

// Flyweight interface
public interface ICharacter
{
  void Display(int fontSize);
}

// Concrete Flyweight
public class Character : ICharacter
{
  private char symbol;
  private string fontFamily;
  private ConsoleColor color;

  public Character(char symbol, string fontFamily, ConsoleColor color)
  {
    this.symbol = symbol;
    this.fontFamily = fontFamily;
    this.color = color;
  }

  public void Display(int fontSize)
  {
    Console.ForegroundColor = color;
    Console.WriteLine($"Character: {symbol}, Font: {fontFamily}, Size: {fontSize}");
    Console.ResetColor();
  }
}

// Flyweight Factory
public class CharacterFactory
{
  private Dictionary<string, ICharacter> characters = new Dictionary<string, ICharacter>();

  public ICharacter GetCharacter(char symbol, string fontFamily, ConsoleColor color)
  {
    string key = $"{symbol}-{fontFamily}-{color}";

    if (!characters.ContainsKey(key))
    {
      characters[key] = new Character(symbol, fontFamily, color);
    }

    return characters[key];
  }

  public int CharacterCount => characters.Count;
}

class Program
{
  static void Main(string[] args)
  {
    CharacterFactory factory = new CharacterFactory();

    string text = "Hello, Flyweight Pattern!";
    Random random = new Random();

    foreach (char c in text)
    {
      string fontFamily = (random.Next(2) == 0) ? "Arial" : "Times New Roman";
      ConsoleColor color = (ConsoleColor)random.Next(16);
      int fontSize = random.Next(10, 20);

      ICharacter character = factory.GetCharacter(c, fontFamily, color);
      character.Display(fontSize);
    }

    Console.WriteLine($"\nTotal Character objects created: {factory.CharacterCount}");
  }
}