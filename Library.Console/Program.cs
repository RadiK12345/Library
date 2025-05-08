using Library.Console;

List<Book> books;
books = new List<Book>();

Console.WriteLine("1. Add Book");
Console.WriteLine("2. Show List of Books");
Console.WriteLine("3. Update List of Books");
Console.WriteLine("4. Delete Book");
Console.WriteLine("5. Exit");

Console.WriteLine();

var info = Console.ReadLine();

switch (info)
{
    case "1": AddBook();
        break;
    case "2": Show();
        break;
    case "3": Update();
        break;
    case "4": Delete();
        break;
    case "5": Exit();
        break;
    default: break;
}

void AddBook()
{
    int id;
    string title;
    int publicationYear;
    int quantity;
    List <Author> Authors;

    var tmpId = Console.ReadLine(); 
    //
    id = Convert.ToInt32(tmpId);
    title = Console.ReadLine();
    publicationYear = Convert.ToInt32(Console.ReadLine());
    quantity = Convert.ToInt32(Console.ReadLine());
    Authors = new List<Author>();
    
    Console.WriteLine("Write names of Authors with ;");
    
    string tmpName = Console.ReadLine();
    var names = tmpName.Split(';');

    foreach (var name in names)
    {
        Author author = new Author{Name = name};
        Authors.Add(author);
    }
    
    Book book = new Book{Id = id, Title = title, PublicationYear = publicationYear, Quantity = quantity, Authors = Authors};
    books.Add(book);
}

void Show()
{
    
}

void Update()
{
    
}

void Delete() {

}

void Exit() {

}

