namespace Library.Console;

using System.Text.Json;

public class BooksJsonManager : IBooksManager
{
    private const string fileName = "file.json";
    public void Save(List<Book> books)
    {
        File.WriteAllText(fileName, JsonSerializer.Serialize(books));
    }

    public List<Book> Load()
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            var books = JsonSerializer.Deserialize<List<Book>>(json);
            return books;
        }

        return new List<Book>();
    }
}