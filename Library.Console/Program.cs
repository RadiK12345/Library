using Library.Console;

public class Program
{
    private static IBooksManager booksManager;
    private static List<Book> books = new List<Book>();

    private static bool isContinue = true;

    public static void Main(string[] args)
    {
        Console.WriteLine("How do you want to save the file?");
        Console.WriteLine("1. Json");
        Console.WriteLine("2. Xml");

        int res = int.Parse(Console.ReadLine() ?? string.Empty);
        switch (res)
        {
            case 1:
                booksManager = new BooksJsonManager();
                break;
            case 2:
                booksManager = new BooksXmlManager();
                break;
            default:
                booksManager = new BooksJsonManager();
                break;
        }

        books = booksManager.Load();

        while (isContinue)
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Show List of Books");
            Console.WriteLine("3. Update List of Books");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Exit");

            Console.WriteLine();

            var info = Console.ReadLine();

            switch (info)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    Show();
                    break;
                case "3":
                    Update();
                    break;
                case "4":
                    Delete();
                    break;
                case "5":
                    Exit();
                    break;
                default: break;
            }
        }
    }

    private static void AddBook()
    {
        int id;
        string? title;
        int publicationYear;
        int quantity;
        List<Author> authors;

        Console.WriteLine("Set Number of the Book: ");
        id = Convert.ToInt32(Console.ReadLine());
        bool isBookExists = books.Any(book => book.Id == id);
        if (isBookExists)
        {
            Console.WriteLine("Book already exists");
            return;
        }

        Console.WriteLine("Set Name of the Book: ");
        title = Console.ReadLine();
        Console.WriteLine("Set Publication Year of the Book: ");
        publicationYear = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Set Quantity of the Book: ");
        quantity = Convert.ToInt32(Console.ReadLine());
        authors = new List<Author>();

        Console.WriteLine("Write names of Authors with ;");

        string? names;
        names = Console.ReadLine() ?? string.Empty;
        var split = names.Split(';');

        foreach (var name in split)
        {
            Author author = new Author { Name = name };
            authors.Add(author);
        }

        Book book = new Book
        {
            Id = id, Title = title ?? string.Empty, PublicationYear = publicationYear, Quantity = quantity,
            Authors = authors,
        };
        books.Add(book);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    private static void Show()
    {
        foreach (var book in books)
        {
            Console.WriteLine("Number of the book: " + book.Id);
            Console.WriteLine("Name of the Book: " + book.Title);
            Console.WriteLine("Publication Year: " + book.PublicationYear);
            foreach (var author in book.Authors)
            {
                Console.WriteLine("Author: " + author.Name);
            }

            Console.WriteLine("Quantity: " + book.Quantity);
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    private static void Update()
    {
        string? title;
        int publicationYear;
        int quantity;
        List<Author> authors;

        Console.WriteLine("Choose number of the Book you want to update:");
        int info = Convert.ToInt32(Console.ReadLine());

        Book? book = books.FirstOrDefault(x => x.Id == info);

        if (book == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        Console.WriteLine("Set Name of the Book: ");
        title = Console.ReadLine();
        Console.WriteLine("Set Publication Year of the Book: ");
        publicationYear = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Set Quantity of the Book: ");
        quantity = Convert.ToInt32(Console.ReadLine());
        authors = new List<Author>();

        Console.WriteLine("Write names of Authors with ;");

        var names = Console.ReadLine();
        var splitNames = names?.Split().ToList() ?? new List<string>();

        foreach (var name in splitNames)
        {
            Author author = new Author { Name = name };
            authors.Add(author);
        }

        book.Title = title ?? string.Empty;
        book.PublicationYear = publicationYear;
        book.Quantity = quantity;
        book.Authors = authors;

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    private static void Delete()
    {
        int index;
        Console.WriteLine("Put number of the Book you want to delete:");
        index = Convert.ToInt32(Console.ReadLine());
        Book? book = books.FirstOrDefault(x => x.Id == index);
        if (book == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        books.Remove(book);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    private static void Exit()
    {
        booksManager.Save(books);
        isContinue = false;
    }
}