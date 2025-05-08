namespace Library.Console;

public class Book
{
    public int Id {get; set;}
    public string Title {get; set;}
    public int PublicationYear {get; set;}
    public int Quantity {get; set;}
    public List <Author> Authors;
    
}