using System;
using System.Threading;
using System.Collections.Generic;

// Mediator Contract
public interface IRobotMediator
{
  void Notify(object sender, string ev);
  void RegisterComponent(RobotComponent component);
}

// Concrete Mediator
public class RobotMediator : IRobotMediator
{
  private List<RobotComponent> components = new List<RobotComponent>();

  public void RegisterComponent(RobotComponent component)
  {
    components.Add(component);
  }

  public void Notify(object sender, string ev)
  {
    foreach (var component in components)
    {
      if (component != sender)
      {
        component.React(ev);
      }
    }
  }
}

// Base Component
public abstract class RobotComponent
{
  protected IRobotMediator mediator;

  public RobotComponent(IRobotMediator mediator)
  {
    this.mediator = mediator;
  }

  public abstract void React(string ev);
}

// Concrete Components
public class ProximitySensor : RobotComponent
{
  public ProximitySensor(IRobotMediator mediator) : base(mediator) { }

  public void DetectObject()
  {
    Console.WriteLine("Proximity Sensor: Object detected nearby");
    mediator.Notify(this, "ObjectDetected");
  }

  public void ClearObject()
  {
    Console.WriteLine("Proximity Sensor: No objects in proximity");
    mediator.Notify(this, "PathClear");
  }

  public override void React(string ev)
  {
  }
}

public class MotionController : RobotComponent
{
  public MotionController(IRobotMediator mediator) : base(mediator) { }

  public void Move()
  {
    Console.WriteLine("Motion Controller: Moving forward");
    mediator.Notify(this, "Moving");
  }

  public void Stop()
  {
    Console.WriteLine("Motion Controller: Stopping");
    mediator.Notify(this, "Stopped");
  }

  public override void React(string ev)
  {
    if (ev == "ObjectDetected")
    {
      Stop();
    }
    else if (ev == "PathClear")
    {
      Move();
    }
  }
}

public class ArmController : RobotComponent
{
  public ArmController(IRobotMediator mediator) : base(mediator) { }

  public void Extend()
  {
    Console.WriteLine("Arm Controller: Extending arm");
    mediator.Notify(this, "ArmExtended");
  }

  public void Retract()
  {
    Console.WriteLine("Arm Controller: Retracting arm");
    mediator.Notify(this, "ArmRetracted");
  }

  public override void React(string ev)
  {
    if (ev == "ObjectDetected")
    {
      Extend();
    }
    else if (ev == "PathClear")
    {
      Retract();
    }
  }
}

public class BatteryMonitor : RobotComponent
{
  private int batteryLevel = 100;

  public BatteryMonitor(IRobotMediator mediator) : base(mediator) { }

  public void CheckBattery()
  {
    batteryLevel -= 10;
    Console.WriteLine($"Battery Monitor: Current battery level is {batteryLevel}%");
    if (batteryLevel <= 20)
    {
      mediator.Notify(this, "LowBattery");
    }
  }

  public override void React(string ev)
  {
    if (ev == "Moving" || ev == "ArmExtended")
    {
      CheckBattery();
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    var mediator = new RobotMediator();

    var proximitySensor = new ProximitySensor(mediator);
    var motionController = new MotionController(mediator);
    var armController = new ArmController(mediator);
    var batteryMonitor = new BatteryMonitor(mediator);

    mediator.RegisterComponent(proximitySensor);
    mediator.RegisterComponent(motionController);
    mediator.RegisterComponent(armController);
    mediator.RegisterComponent(batteryMonitor);

    Console.WriteLine("Simulating robot operations:");

    proximitySensor.ClearPath();
    Console.WriteLine();

    Thread.Sleep(2000);

    proximitySensor.DetectObject();
    Console.WriteLine();

    Thread.Sleep(2000);

    proximitySensor.ClearPath();
    Console.WriteLine();

    Thread.Sleep(2000);

    proximitySensor.DetectObject();
    Console.WriteLine();
  }
}