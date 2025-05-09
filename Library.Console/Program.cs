using Library.Console;


List<Book> books = new List<Book>();

bool isContinue = true;

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
    var tmpId = Console.ReadLine();
    id = Convert.ToInt32(tmpId);
    Console.WriteLine("Set Name of the Book: ");
    title = Console.ReadLine();
    Console.WriteLine("Set Publication Year of the Book: ");
    publicationYear = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Set Quantity of the Book: ");
    quantity = Convert.ToInt32(Console.ReadLine());
    Authors = new List<Author>();

    Console.WriteLine("Write names of Authors with ;");

    string tmpName = Console.ReadLine();
    var names = tmpName.Split(';');

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

    string tmpName = Console.ReadLine();
    var names = tmpName.Split("; ");

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
    books.RemoveAt(index - 1);

    Console.WriteLine("Press any key to continue");
    Console.ReadLine();
}

void Exit()
{
    isContinue = false;
}