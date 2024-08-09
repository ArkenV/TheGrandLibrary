// Existing interface that our system uses
public interface IModernAudioPlayer
{
  void PlayAudio(string fileName);
}

// Legacy audio player that we want to adapt
public class LegacyMP3Player
{
  public void LoadMP3(string fileName)
  {
    Console.WriteLine($"Loading MP3 file: {fileName}");
  }

  public void Play()
  {
    Console.WriteLine("Playing MP3 audio");
  }
}

// Adapter class that makes LegacyMP3Player compatible with IModernAudioPlayer
public class MP3PlayerAdapter : IModernAudioPlayer
{
  private readonly LegacyMP3Player _legacyPlayer;

  public MP3PlayerAdapter(LegacyMP3Player legacyPlayer)
  {
    _legacyPlayer = legacyPlayer;
  }

  public void PlayAudio(string fileName)
  {
    _legacyPlayer.LoadMP3(fileName);
    _legacyPlayer.Play();
  }
}

public class MusicPlayer
{
  private readonly IModernAudioPlayer _audioPlayer;

  public MusicPlayer(IModernAudioPlayer audioPlayer)
  {
    _audioPlayer = audioPlayer;
  }

  public void PlaySong(string fileName)
  {
    _audioPlayer.PlayAudio(fileName);
  }
}

class Program
{
  static void Main(string[] args)
  {
    LegacyMP3Player legacyPlayer = new LegacyMP3Player();
    IModernAudioPlayer adapter = new MP3PlayerAdapter(legacyPlayer);
    MusicPlayer player = new MusicPlayer(adapter);

    player.PlaySong("song.mp3");
  }
}