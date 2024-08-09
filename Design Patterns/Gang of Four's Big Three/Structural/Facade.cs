using System;

// Subsystem classes
public class Light
{
  public void TurnOn() => Console.WriteLine("Light is on");
  public void TurnOff() => Console.WriteLine("Light is off");
}

public class Thermostat
{
  public void SetTemperature(int temperature) => Console.WriteLine($"Temperature set to {temperature}°C");
}

public class SecuritySystem
{
  public void Arm() => Console.WriteLine("Security system armed");
  public void Disarm() => Console.WriteLine("Security system disarmed");
}

public class SmartHomeFacade
{
  private Light _light;
  private Thermostat _thermostat;
  private SecuritySystem _securitySystem;

  public SmartHomeFacade()
  {
    _light = new Light();
    _thermostat = new Thermostat();
    _securitySystem = new SecuritySystem();
  }

  public void LeaveHome()
  {
    Console.WriteLine("Leaving home...");
    _light.TurnOff();
    _thermostat.SetTemperature(18);
    _securitySystem.Arm();
  }

  public void ReturnHome()
  {
    Console.WriteLine("Returning home...");
    _light.TurnOn();
    _thermostat.SetTemperature(22);
    _securitySystem.Disarm();
  }

  public void NightMode()
  {
    Console.WriteLine("Activating night mode...");
    _light.TurnOff();
    _thermostat.SetTemperature(20);
    _securitySystem.Arm();
  }
}

class Program
{
  static void Main(string[] args)
  {
    SmartHomeFacade smartHome = new SmartHomeFacade();

    smartHome.LeaveHome();
    smartHome.ReturnHome();
    smartHome.NightMode();
  }
}