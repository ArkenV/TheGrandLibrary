// Abstraction
public abstract class RemoteControl
{
  protected IDevice device;

  public RemoteControl(IDevice device)
  {
    this.device = device;
  }

  public abstract void TurnOn();
  public abstract void TurnOff();
  public abstract void SetChannel(int channel);
}

// Refined Abstraction
public class BasicRemoteControl : RemoteControl
{
  public BasicRemoteControl(IDevice device) : base(device) { }

  public override void TurnOn()
  {
    Console.WriteLine("Basic Remote: Turning on");
    device.PowerOn();
  }

  public override void TurnOff()
  {
    Console.WriteLine("Basic Remote: Turning off");
    device.PowerOff();
  }

  public override void SetChannel(int channel)
  {
    Console.WriteLine($"Basic Remote: Setting channel to {channel}");
    device.SetChannel(channel);
  }
}

// Advanced Remote Control with additional functionality
public class AdvancedRemoteControl : RemoteControl
{
  public AdvancedRemoteControl(IDevice device) : base(device) { }

  public override void TurnOn()
  {
    Console.WriteLine("Advanced Remote: Turning on");
    device.PowerOn();
  }

  public override void TurnOff()
  {
    Console.WriteLine("Advanced Remote: Turning off");
    device.PowerOff();
  }

  public override void SetChannel(int channel)
  {
    Console.WriteLine($"Advanced Remote: Setting channel to {channel}");
    device.SetChannel(channel);
  }

  public void Mute()
  {
    Console.WriteLine("Advanced Remote: Muting");
    device.SetVolume(0);
  }
}

// Implementor
public interface IDevice
{
  void PowerOn();
  void PowerOff();
  void SetChannel(int channel);
  void SetVolume(int volume);
}

// Concrete Implementor
public class TV : IDevice
{
  public void PowerOn()
  {
    Console.WriteLine("TV: Powering on");
  }

  public void PowerOff()
  {
    Console.WriteLine("TV: Powering off");
  }

  public void SetChannel(int channel)
  {
    Console.WriteLine($"TV: Setting channel to {channel}");
  }

  public void SetVolume(int volume)
  {
    Console.WriteLine($"TV: Setting volume to {volume}");
  }
}

// Concrete Implementor
public class Radio : IDevice
{
  public void PowerOn()
  {
    Console.WriteLine("Radio: Powering on");
  }

  public void PowerOff()
  {
    Console.WriteLine("Radio: Powering off");
  }

  public void SetChannel(int channel)
  {
    Console.WriteLine($"Radio: Setting frequency to {channel}.0 MHz");
  }

  public void SetVolume(int volume)
  {
    Console.WriteLine($"Radio: Setting volume to {volume}");
  }
}

class Program
{
  static void Main(string[] args)
  {
    IDevice tv = new TV();
    IDevice radio = new Radio();

    RemoteControl basicTvRemote = new BasicRemoteControl(tv);
    RemoteControl advancedTvRemote = new AdvancedRemoteControl(tv);
    RemoteControl basicRadioRemote = new BasicRemoteControl(radio);

    Console.WriteLine("Basic TV Remote:");
    basicTvRemote.TurnOn();
    basicTvRemote.SetChannel(5);
    basicTvRemote.TurnOff();

    Console.WriteLine("\nAdvanced TV Remote:");
    advancedTvRemote.TurnOn();
    advancedTvRemote.SetChannel(10);
    ((AdvancedRemoteControl)advancedTvRemote).Mute();
    advancedTvRemote.TurnOff();

    Console.WriteLine("\nBasic Radio Remote:");
    basicRadioRemote.TurnOn();
    basicRadioRemote.SetChannel(98);
    basicRadioRemote.TurnOff();
  }
}