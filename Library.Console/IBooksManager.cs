namespace Library.Console;

public interface IBooksManager
{
    void Save(List<Book> books);
    List<Book> Load();
}