using System;
using System.Collections.Generic;

// Element Contract
public interface IMusicalElement
{
  void Accept(IMusicalVisitor visitor);
}

// Concrete Elements
public class Note : IMusicalElement
{
  public string Pitch { get; set; }
  public int Duration { get; set; }

  public Note(string pitch, int duration)
  {
    Pitch = pitch;
    Duration = duration;
  }

  public void Accept(IMusicalVisitor visitor)
  {
    visitor.Visit(this);
  }
}

public class Chord : IMusicalElement
{
  public List<string> Notes { get; set; }
  public int Duration { get; set; }

  public Chord(List<string> notes, int duration)
  {
    Notes = notes;
    Duration = duration;
  }

  public void Accept(IMusicalVisitor visitor)
  {
    visitor.Visit(this);
  }
}

// Visitor Contract
public interface IMusicalVisitor
{
  void Visit(Note note);
  void Visit(Chord chord);
}

// Concrete Visitors
public class PlaybackVisitor : IMusicalVisitor
{
  public void Visit(Note note)
  {
    Console.WriteLine($"Playing note: {note.Pitch} for {note.Duration} beats");
  }

  public void Visit(Chord chord)
  {
    Console.WriteLine($"Playing chord: {string.Join(", ", chord.Notes)} for {chord.Duration} beats");
  }
}

public class TransposeVisitor : IMusicalVisitor
{
  private int _semitones;

  public TransposeVisitor(int semitones)
  {
    _semitones = semitones;
  }

  public void Visit(Note note)
  {
    note.Pitch = TransposePitch(note.Pitch, _semitones);
    Console.WriteLine($"Transposed note: {note.Pitch}");
  }

  public void Visit(Chord chord)
  {
    for (int i = 0; i < chord.Notes.Count; i++)
    {
      chord.Notes[i] = TransposePitch(chord.Notes[i], _semitones);
    }
    Console.WriteLine($"Transposed chord: {string.Join(", ", chord.Notes)}");
  }

  private string TransposePitch(string pitch, int semitones)
  {
    string[] notes = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    int index = Array.IndexOf(notes, pitch);
    int newIndex = (index + semitones + 12) % 12;
    return notes[newIndex];
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var musicalPiece = new List<IMusicalElement>
        {
            new Note("C", 4),
            new Chord(new List<string> { "C", "E", "G" }, 4),
            new Note("F", 2),
            new Note("G", 2),
        };

    var playbackVisitor = new PlaybackVisitor();
    var transposeVisitor = new TransposeVisitor(2);

    Console.WriteLine("Original playback:");
    foreach (var element in musicalPiece)
    {
      element.Accept(playbackVisitor);
    }

    Console.WriteLine("\nTransposing...");
    foreach (var element in musicalPiece)
    {
      element.Accept(transposeVisitor);
    }

    Console.WriteLine("\nPlayback after transposition:");
    foreach (var element in musicalPiece)
    {
      element.Accept(playbackVisitor);
    }
  }
}