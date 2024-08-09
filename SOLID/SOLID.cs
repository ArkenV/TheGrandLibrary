using System;
using System.Collections.Generic;

// 1. Single Responsibility Principle (SRP)
public class PianoKey
{
  public string Note { get; }
  public double Frequency { get; }

  public PianoKey(string note, double frequency)
  {
    Note = note;
    Frequency = frequency;
  }
}

public class Piano
{
  private readonly List<PianoKey> keys;

  public Piano()
  {
    keys = new List<PianoKey>
        {
            new PianoKey("C", 261.63),
            new PianoKey("D", 293.66),
            new PianoKey("E", 329.63),
            new PianoKey("F", 349.23),
            new PianoKey("G", 392.00),
            new PianoKey("A", 440.00),
            new PianoKey("B", 493.88)
        };
  }

  public void PlayNote(string note)
  {
    var key = keys.Find(k => k.Note == note);
    if (key != null)
    {
      Console.WriteLine($"Playing note {key.Note} at {key.Frequency} Hz");
    }
    else
    {
      Console.WriteLine($"Note {note} not found");
    }
  }
}

// 2. Open-Closed Principle (OCP)
public abstract class RoboticArm
{
  public abstract void Move();
  public abstract void Grip();
  public abstract void Release();
}

public class PianoPlayingArm : RoboticArm
{
  public override void Move() => Console.WriteLine("Moving arm to piano key");
  public override void Grip() => Console.WriteLine("Gripping piano key");
  public override void Release() => Console.WriteLine("Releasing piano key");
}

// 3. Liskov Substitution Principle (LSP)
public class EnhancedPianoPlayingArm : PianoPlayingArm
{
  public override void Move()
  {
    base.Move();
    Console.WriteLine("Adjusting for optimal key strike");
  }
}

// 4. Interface Segregation Principle (ISP)
public interface IPlayable
{
  void Play(string[] notes);
}

public interface IMaintainable
{
  void AlignmentAdjustment();
  void SensorCalibration();
}

// 5. Dependency Inversion Principle (DIP)
public interface ISoundProducer
{
  void ProduceSound(double frequency);
}

public class PianoSoundProducer : ISoundProducer
{
  public void ProduceSound(double frequency)
  {
    Console.WriteLine($"Producing piano sound at {frequency} Hz");
  }
}

public class RoboticHand : IPlayable, IMaintainable
{
  private readonly RoboticArm arm;
  private readonly Piano piano;
  private readonly ISoundProducer soundProducer;

  public RoboticHand(RoboticArm arm, Piano piano, ISoundProducer soundProducer)
  {
    this.arm = arm;
    this.piano = piano;
    this.soundProducer = soundProducer;
  }

  public void Play(string[] notes)
  {
    foreach (var note in notes)
    {
      arm.Move();
      arm.Grip();
      piano.PlayNote(note);
      soundProducer.ProduceSound(440);
      arm.Release();
    }
  }

  public void AlignmentAdjustment() => Console.WriteLine("Calibrating robotic hand");
  public void SensorCalibration() => Console.WriteLine("Lubricating robotic hand joints");
}

public class PianoPlayingRobot
{
  private readonly RoboticHand leftHand;
  private readonly RoboticHand rightHand;

  public PianoPlayingRobot(RoboticHand leftHand, RoboticHand rightHand)
  {
    this.leftHand = leftHand;
    this.rightHand = rightHand;
  }

  public void PerformSong(string[] leftHandNotes, string[] rightHandNotes)
  {
    Console.WriteLine("Robot performance starting...");
    leftHand.Play(leftHandNotes);
    rightHand.Play(rightHandNotes);
    Console.WriteLine("Robot performance completed.");
  }
}

class Program
{
  static void Main(string[] args)
  {
    // Single Responsibility Principle (SRP):
    // Piano class is responsible only for playing notes
    var piano = new Piano();

    // Dependency Inversion Principle (DIP):
    // We're programming to an interface (ISoundProducer) rather than a concrete class
    ISoundProducer soundProducer = new PianoSoundProducer();

    // Open-Closed Principle (OCP):
    // We can create different types of RoboticArm without modifying existing code
    RoboticArm leftArm = new PianoPlayingArm();

    // Liskov Substitution Principle (LSP):
    // EnhancedPianoPlayingArm can be used wherever PianoPlayingArm is expected
    RoboticArm rightArm = new EnhancedPianoPlayingArm();

    // Interface Segregation Principle (ISP):
    // RoboticHand implements both IPlayable and IMaintainable interfaces
    // We're only using the IPlayable functionality here
    IPlayable leftHand = new RoboticHand(leftArm, piano, soundProducer);
    IPlayable rightHand = new RoboticHand(rightArm, piano, soundProducer);

    // Dependency Inversion Principle (DIP):
    // PianoPlayingRobot depends on abstractions (IPlayable) rather than concrete classes
    var Arken = new PianoPlayingRobot((RoboticHand)leftHand, (RoboticHand)rightHand);

    string[] leftHandNotes = { "C", "E", "G" };
    string[] rightHandNotes = { "C", "D", "E", "F", "G", "A", "B" };

    // Using the robot to perform a song
    Arken.PerformSong(leftHandNotes, rightHandNotes);

    // Interface Segregation Principle (ISP):
    // We can use the IMaintainable interface separately from IPlayable
    ((IMaintainable)leftHand).AlignmentAdjustment();
    ((IMaintainable)rightHand).SensorCalibration();
  }
}