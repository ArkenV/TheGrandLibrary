using System;
using System.Text;

// Strategy Contract
public interface ITextFormattingStrategy
{
  string FormatText(string text);
}

// Concrete Strategies
public class UppercaseStrategy : ITextFormattingStrategy
{
  public string FormatText(string text)
  {
    return text.ToUpper();
  }
}

public class LowercaseStrategy : ITextFormattingStrategy
{
  public string FormatText(string text)
  {
    return text.ToLower();
  }
}

public class TitleCaseStrategy : ITextFormattingStrategy
{
  public string FormatText(string text)
  {
    if (string.IsNullOrWhiteSpace(text))
      return string.Empty;

    var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    var lowercaseWords = new HashSet<string> { "a", "an", "the", "and", "but", "or", "for", "nor", "on", "at", "to", "from", "by", "in", "of" };

    var result = new StringBuilder();

    for (int i = 0; i < words.Length; i++)
    {
      string word = words[i];

      if (i == 0 || !lowercaseWords.Contains(word.ToLower()))
      {
        result.Append(char.ToUpper(word[0]));
        if (word.Length > 1)
          result.Append(word.Substring(1).ToLower());
      }
      else
      {
        result.Append(word.ToLower());
      }

      if (i < words.Length - 1)
        result.Append(' ');
    }

    return result.ToString();
  }
}

// Context
public class TextFormatter
{
  private ITextFormattingStrategy _strategy;

  public TextFormatter(ITextFormattingStrategy strategy)
  {
    _strategy = strategy;
  }

  public void SetStrategy(ITextFormattingStrategy strategy)
  {
    _strategy = strategy;
  }

  public string FormatText(string text)
  {
    return _strategy.FormatText(text);
  }
}

class Program
{
  static void Main(string[] args)
  {
    string text = "Format this.";

    TextFormatter formatter = new TextFormatter(new UppercaseStrategy());
    Console.WriteLine("Uppercase: " + formatter.FormatText(text));

    formatter.SetStrategy(new LowercaseStrategy());
    Console.WriteLine("Lowercase: " + formatter.FormatText(text));

    formatter.SetStrategy(new TitleCaseStrategy());
    Console.WriteLine("Title case: " + formatter.FormatText(text));
  }
}