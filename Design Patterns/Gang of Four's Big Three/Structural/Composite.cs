using System;
using System.Collections.Generic;

// Component
public abstract class FileSystemItem
{
  protected string name;

  public FileSystemItem(string name)
  {
    this.name = name;
  }

  public abstract void Display(int depth);
}

// Leaf
public class File : FileSystemItem
{
  public File(string name) : base(name) { }

  public override void Display(int depth)
  {
    Console.WriteLine(new string('-', depth) + name);
  }
}

// Composite
public class Directory : FileSystemItem
{
  private List<FileSystemItem> children = new List<FileSystemItem>();

  public Directory(string name) : base(name) { }

  public void Add(FileSystemItem item)
  {
    children.Add(item);
  }

  public override void Display(int depth)
  {
    Console.WriteLine(new string('-', depth) + name);
    foreach (var item in children)
    {
      item.Display(depth + 2);
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    Directory root = new Directory("Root");
    Directory music = new Directory("Music");
    Directory documents = new Directory("Documents");

    File track1 = new File("Track1.mp3");
    File track2 = new File("Track2.mp3");
    File document1 = new File("Document1.docx");
    File document2 = new File("Document2.pdf");

    music.Add(track1);
    music.Add(track2);
    documents.Add(document1);
    documents.Add(document2);

    root.Add(music);
    root.Add(documents);

    root.Display(0);
  }
}