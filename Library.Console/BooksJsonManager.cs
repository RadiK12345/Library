namespace Library.Console;

using System.Text.Json;

public class BooksJsonManager : IBooksManager
{
    public void Save(List<Book> books)
    {
        File.WriteAllText("file.json", JsonSerializer.Serialize(books));
    }

    public List<Book> Load()
    {
        if (File.Exists("file.json"))
        {
            string json = File.ReadAllText("file.json");
            var books = JsonSerializer.Deserialize<List<Book>>(json);
            return books;
        }

        return new List<Book>();

    }
}