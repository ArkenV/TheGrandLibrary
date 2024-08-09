using System;

// State Contract
public interface IMusicPlayerState
{
  void Play();
  void Pause();
  void Stop();
}

// Concrete States
public class PlayingState : IMusicPlayerState
{
  private MusicPlayer player;

  public PlayingState(MusicPlayer player)
  {
    this.player = player;
  }

  public void Play()
  {
    Console.WriteLine("Already playing.");
  }

  public void Pause()
  {
    Console.WriteLine("Pausing the music.");
    player.SetState(new PausedState(player));
  }

  public void Stop()
  {
    Console.WriteLine("Stopping the music.");
    player.SetState(new StoppedState(player));
  }
}

public class PausedState : IMusicPlayerState
{
  private MusicPlayer player;

  public PausedState(MusicPlayer player)
  {
    this.player = player;
  }

  public void Play()
  {
    Console.WriteLine("Resuming the music.");
    player.SetState(new PlayingState(player));
  }

  public void Pause()
  {
    Console.WriteLine("Already paused.");
  }

  public void Stop()
  {
    Console.WriteLine("Stopping the music.");
    player.SetState(new StoppedState(player));
  }
}

public class StoppedState : IMusicPlayerState
{
  private MusicPlayer player;

  public StoppedState(MusicPlayer player)
  {
    this.player = player;
  }

  public void Play()
  {
    Console.WriteLine("Starting to play music.");
    player.SetState(new PlayingState(player));
  }

  public void Pause()
  {
    Console.WriteLine("Can't pause when stopped.");
  }

  public void Stop()
  {
    Console.WriteLine("Already stopped.");
  }
}

// Context
public class MusicPlayer
{
  private IMusicPlayerState currentState;

  public MusicPlayer()
  {
    currentState = new StoppedState(this);
  }

  public void SetState(IMusicPlayerState state)
  {
    currentState = state;
  }

  public void Play()
  {
    currentState.Play();
  }

  public void Pause()
  {
    currentState.Pause();
  }

  public void Stop()
  {
    currentState.Stop();
  }
}

class Program
{
  static void Main(string[] args)
  {
    MusicPlayer player = new MusicPlayer();

    player.Play();
    player.Play();
    player.Pause();
    player.Stop();
    player.Pause();
    player.Play();
    player.Stop();
  }
}