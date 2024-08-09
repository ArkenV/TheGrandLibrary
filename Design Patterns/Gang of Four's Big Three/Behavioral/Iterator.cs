using System;
using System.Collections;
using System.Collections.Generic;

public class Song
{
  public string Title { get; set; }
  public string Artist { get; set; }

  public Song(string title, string artist)
  {
    Title = title;
    Artist = artist;
  }

  public override string ToString()
  {
    return $"{Artist} - {Title}";
  }
}

public class Playlist : IEnumerable<Song>
{
  private List<Song> songs = new List<Song>();

  public void AddSong(Song song)
  {
    songs.Add(song);
  }

  public IEnumerator<Song> GetEnumerator()
  {
    return new PlaylistEnumerator(this);
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }

  private class PlaylistEnumerator : IEnumerator<Song>
  {
    private Playlist playlist;
    private int currentIndex;
    private Song currentSong;

    public PlaylistEnumerator(Playlist playlist)
    {
      this.playlist = playlist;
      currentIndex = -1;
      currentSong = default(Song);
    }

    public Song Current => currentSong;

    object IEnumerator.Current => Current;

    public void Dispose() { }

    public bool MoveNext()
    {
      if (++currentIndex >= playlist.songs.Count)
      {
        return false;
      }
      else
      {
        currentSong = playlist.songs[currentIndex];
      }
      return true;
    }

    public void Reset()
    {
      currentIndex = -1;
      currentSong = default(Song);
    }
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    Playlist myPlaylist = new Playlist();
    myPlaylist.AddSong(new Song("Helvegen", "Wardruna"));
    myPlaylist.AddSong(new Song("Emergency", "Pegboard Nerds"));
    myPlaylist.AddSong(new Song("Free Will Sacrifice", "Amon Amarth"));

    Console.WriteLine("Songs in the playlist:");
    foreach (var song in myPlaylist)
    {
      Console.WriteLine(song);
    }
  }
}