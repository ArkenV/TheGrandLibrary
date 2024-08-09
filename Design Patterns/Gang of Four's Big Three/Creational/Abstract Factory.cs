// Abstract Products
public interface IButton
{
  void Render();
}

public interface ICheckbox
{
  void Render();
}

// Concrete Products
public class WindowsButton : IButton
{
  public void Render() => Console.WriteLine("Rendering a Windows button");
}

public class MacButton : IButton
{
  public void Render() => Console.WriteLine("Rendering a Mac button");
}

public class WindowsCheckbox : ICheckbox
{
  public void Render() => Console.WriteLine("Rendering a Windows checkbox");
}

public class MacCheckbox : ICheckbox
{
  public void Render() => Console.WriteLine("Rendering a Mac checkbox");
}

// Abstract Factory
public interface IGUIFactory
{
  IButton CreateButton();
  ICheckbox CreateCheckbox();
}

// Concrete Factories
public class WindowsFactory : IGUIFactory
{
  public IButton CreateButton() => new WindowsButton();
  public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

public class MacFactory : IGUIFactory
{
  public IButton CreateButton() => new MacButton();
  public ICheckbox CreateCheckbox() => new MacCheckbox();
}

public class Application
{
  private readonly IGUIFactory _factory;
  private IButton _button;
  private ICheckbox _checkbox;

  public Application(IGUIFactory factory)
  {
    _factory = factory;
  }

  public void CreateUI()
  {
    _button = _factory.CreateButton();
    _checkbox = _factory.CreateCheckbox();
  }

  public void RenderUI()
  {
    _button.Render();
    _checkbox.Render();
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    Application windowsApp = new Application(new WindowsFactory());
    windowsApp.CreateUI();
    windowsApp.RenderUI();

    Application macApp = new Application(new MacFactory());
    macApp.CreateUI();
    macApp.RenderUI();
  }
}