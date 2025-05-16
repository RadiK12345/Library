using System.Xml.Serialization;

namespace Library.Console;

internal class BooksXmlManager : IBooksManager
{
    private const string FileName = "file.json";

    public void Save(List<Book> books)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));
        using (FileStream fs = new FileStream(FileName, FileMode.Create))
        {
            xmlSerializer.Serialize(fs, books);
        }
    }

    public List<Book> Load()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));

        using (FileStream fs = new FileStream(FileName, FileMode.Open))
        {
            if (fs.Length == 0)
            {
                return new List<Book>();
            }

            var bookFile = xmlSerializer.Deserialize(fs);
            if (bookFile is not List<Book> bookList)
            {
                throw new Exception("Book file could not be deserialized");
            }

            return bookList;
        }
    }
}