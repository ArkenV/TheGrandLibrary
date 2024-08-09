using System;
using System.Collections.Generic;

// Originator
public class TextEditor
{
  private string _content;

  public string Content
  {
    get => _content;
    set
    {
      _content = value;
      Console.WriteLine($"TextEditor: Content set to: {_content}");
    }
  }

  public EditorMemento Save()
  {
    Console.WriteLine($"TextEditor: Saving state: {_content}");
    return new EditorMemento(_content);
  }

  public void Restore(EditorMemento memento)
  {
    if (memento == null) throw new ArgumentNullException(nameof(memento));

    _content = memento.GetSavedContent();
    Console.WriteLine($"TextEditor: State restored to: {_content}");
  }
}

// Memento
public class EditorMemento
{
  private readonly string _content;

  public EditorMemento(string content)
  {
    _content = content;
  }

  public string GetSavedContent()
  {
    return _content;
  }
}

// Caretaker
public class History
{
  private readonly Stack<EditorMemento> _mementos = new Stack<EditorMemento>();

  public void Push(EditorMemento memento)
  {
    _mementos.Push(memento);
  }

  public EditorMemento Pop()
  {
    return _mementos.Count > 0 ? _mementos.Pop() : null;
  }
}

class Program
{
  static void Main(string[] args)
  {
    TextEditor editor = new TextEditor();
    History history = new History();

    editor.Content = "Entry 1";
    history.Push(editor.Save());

    editor.Content = "Entry 2";
    history.Push(editor.Save());

    editor.Content = "Entry 3";

    editor.Restore(history.Pop());

    editor.Restore(history.Pop());

    Console.ReadKey();
  }
}