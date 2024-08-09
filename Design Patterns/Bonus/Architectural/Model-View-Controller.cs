// Model
public class Book
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public int Year { get; set; }
}

// View
public interface IBookView
{
  void DisplayBooks(List<Book> books);
  void DisplayBook(Book book);
  string GetBookInput();
}

public class ConsoleBookView : IBookView
{
  public void DisplayBooks(List<Book> books)
  {
    Console.WriteLine("Book List:");
    foreach (var book in books)
    {
      Console.WriteLine($"{book.Id}: {book.Title} by {book.Author} ({book.Year})");
    }
  }

  public void DisplayBook(Book book)
  {
    Console.WriteLine($"Book Details:");
    Console.WriteLine($"ID: {book.Id}");
    Console.WriteLine($"Title: {book.Title}");
    Console.WriteLine($"Author: {book.Author}");
    Console.WriteLine($"Year: {book.Year}");
  }

  public string GetBookInput()
  {
    Console.Write("Enter book ID: ");
    return Console.ReadLine();
  }
}

// Controller
public class BookController
{
  private List<Book> _books;
  private IBookView _view;

  public BookController(IBookView view)
  {
    _books = new List<Book>
        {
            new Book { Id = 1, Title = "Frankenstein", Author = "Mary Shelley", Year = 1818 },
            new Book { Id = 2, Title = "Darkly Dreaming Dexter", Author = "Jeff Lindsay", Year = 2004 },
            new Book { Id = 3, Title = "Wheelock's Latin", Author = "Frederic M. Wheelock", Year = 1956 },
            new Book { Id = 4, Title = "D&D 5e Dungeon Master's Guide", Author = "Wizards of the Coast", Year = 2014 },
            new Book { Id = 5, Title = "Astrophysics for People in a Hurry", Author = "Neil deGrasse Tyson", Year = 2017 }
        };
    _view = view;
  }

  public void ListBooks()
  {
    _view.DisplayBooks(_books);
  }

  public void ShowBookDetails(int id)
  {
    var book = _books.FirstOrDefault(b => b.Id == id);
    if (book != null)
    {
      _view.DisplayBook(book);
    }
    else
    {
      Console.WriteLine("Book not found.");
    }
  }

  public void Run()
  {
    while (true)
    {
      ListBooks();
      var input = _view.GetBookInput();

      if (int.TryParse(input, out int id))
      {
        ShowBookDetails(id);
      }
      else if (input.ToLower() == "exit")
      {
        break;
      }
      else
      {
        Console.WriteLine("Invalid input. Please enter a valid book ID or 'exit' to quit.");
      }

      Console.WriteLine();
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    IBookView view = new ConsoleBookView();
    BookController controller = new BookController(view);
    controller.Run();
  }
}