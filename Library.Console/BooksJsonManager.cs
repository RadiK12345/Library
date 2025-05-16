namespace Library.Console;

using System.Text.Json;

public class BooksJsonManager : IBooksManager
{
    private const string FileName = "file.json";

    public void Save(List<Book> books)
    {
        File.WriteAllText(FileName, JsonSerializer.Serialize(books));
    }

    public List<Book> Load()
    {
        if (File.Exists(FileName))
        {
            string json = File.ReadAllText(FileName);
            var books = JsonSerializer.Deserialize<List<Book>>(json);
            if (books is null)
            {
                throw new Exception("Can not read books from file");
            }

            return books;
        }

        return new List<Book>();
    }
}