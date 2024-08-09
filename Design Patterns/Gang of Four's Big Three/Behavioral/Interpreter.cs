using System;
using System.Collections.Generic;

namespace InterpreterPattern
{
  // Expression Contract
  public interface IExpression
  {
    int Interpret(Dictionary<string, int> context);
  }

  // Terminal Expressions
  public class NumberExpression : IExpression
  {
    private int number;

    public NumberExpression(int number)
    {
      this.number = number;
    }

    public int Interpret(Dictionary<string, int> context)
    {
      return number;
    }
  }

  public class VariableExpression : IExpression
  {
    private string name;

    public VariableExpression(string name)
    {
      this.name = name;
    }

    public int Interpret(Dictionary<string, int> context)
    {
      if (!context.ContainsKey(name))
        throw new Exception($"Variable {name} not defined in context");
      return context[name];
    }
  }

  // Non-terminal Expressions
  public class AddExpression : IExpression
  {
    private IExpression left;
    private IExpression right;

    public AddExpression(IExpression left, IExpression right)
    {
      this.left = left;
      this.right = right;
    }

    public int Interpret(Dictionary<string, int> context)
    {
      return left.Interpret(context) + right.Interpret(context);
    }
  }

  public class MultiplyExpression : IExpression
  {
    private IExpression left;
    private IExpression right;

    public MultiplyExpression(IExpression left, IExpression right)
    {
      this.left = left;
      this.right = right;
    }

    public int Interpret(Dictionary<string, int> context)
    {
      return left.Interpret(context) * right.Interpret(context);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      IExpression expression = new MultiplyExpression(
          new AddExpression(new NumberExpression(5), new VariableExpression("x")),
          new AddExpression(new NumberExpression(10), new VariableExpression("y"))
      );

      Dictionary<string, int> context = new Dictionary<string, int>
            {
                { "x", 5 },
                { "y", 6 }
            };

      int result = expression.Interpret(context);
      Console.WriteLine($"Result: {result}");
    }
  }
}