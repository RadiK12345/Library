using Library.Console;

bool isContinue = true;


IBooksManager booksManager;


Console.WriteLine("How do you want to save the file?");
Console.WriteLine("1. Json");
Console.WriteLine("2. Xml");

int res = int.Parse(Console.ReadLine());
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

List<Book> books = booksManager.Load();



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

void AddBook()
{
    int id;
    string title;
    int publicationYear;
    int quantity;
    List<Author> Authors;

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
    Authors = new List<Author>();

    Console.WriteLine("Write names of Authors with ;");
    
    var names = Console.ReadLine().Split(';');

    foreach (var name in names)
    {
        Author author = new Author { Name = name };
        Authors.Add(author);
    }

    Book book = new Book
        { Id = id, Title = title, PublicationYear = publicationYear, Quantity = quantity, Authors = Authors };
    books.Add(book);

    Console.WriteLine("Press any key to continue");
    Console.ReadLine();
}

void Show()
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


void Update()
{
    string title;
    int publicationYear;
    int quantity;
    List<Author> Authors;

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
    Authors = new List<Author>();

    Console.WriteLine("Write names of Authors with ;");
    
    var names = Console.ReadLine().Split(";");

    foreach (var name in names)
    {
        Author author = new Author { Name = name };
        Authors.Add(author);
    }

    book.Title = title;
    book.PublicationYear = publicationYear;
    book.Quantity = quantity;
    book.Authors = Authors;

    Console.WriteLine("Press any key to continue");
    Console.ReadLine();
}

void Delete()
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

void Exit()
{
    booksManager.Save(books);
    isContinue = false;
}