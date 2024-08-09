using System;
using System.Collections.Generic;

// Receiver
public class TextEditor
{
  private string _text = "";

  public void Insert(string text)
  {
    _text += text;
  }

  public void Delete(int length)
  {
    if (length <= _text.Length)
      _text = _text.Substring(0, _text.Length - length);
  }

  public string GetText()
  {
    return _text;
  }
}

// Command interface
public interface ICommand
{
  void Execute();
  void Undo();
}

// Concrete Command for inserting text
public class InsertTextCommand : ICommand
{
  private TextEditor _editor;
  private string _text;

  public InsertTextCommand(TextEditor editor, string text)
  {
    _editor = editor;
    _text = text;
  }

  public void Execute()
  {
    _editor.Insert(_text);
  }

  public void Undo()
  {
    _editor.Delete(_text.Length);
  }
}

// Concrete Command for deleting text
public class DeleteTextCommand : ICommand
{
  private TextEditor _editor;
  private string _deletedText;
  private int _length;

  public DeleteTextCommand(TextEditor editor, int length)
  {
    _editor = editor;
    _length = length;
  }

  public void Execute()
  {
    _deletedText = _editor.GetText().Substring(_editor.GetText().Length - _length);
    _editor.Delete(_length);
  }

  public void Undo()
  {
    _editor.Insert(_deletedText);
  }
}

// Invoker
public class TextEditorInvoker
{
  private Stack<ICommand> _undoStack = new Stack<ICommand>();

  public void ExecuteCommand(ICommand command)
  {
    command.Execute();
    _undoStack.Push(command);
  }

  public void Undo()
  {
    if (_undoStack.Count > 0)
    {
      ICommand command = _undoStack.Pop();
      command.Undo();
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    TextEditor editor = new TextEditor();
    TextEditorInvoker invoker = new TextEditorInvoker();

    invoker.ExecuteCommand(new InsertTextCommand(editor, "Hello"));
    invoker.ExecuteCommand(new InsertTextCommand(editor, ", world!"));
    Console.WriteLine(editor.GetText());

    invoker.ExecuteCommand(new DeleteTextCommand(editor, 8));
    Console.WriteLine(editor.GetText());

    invoker.Undo();
    Console.WriteLine(editor.GetText());

    invoker.Undo();
    Console.WriteLine(editor.GetText());
  }
}