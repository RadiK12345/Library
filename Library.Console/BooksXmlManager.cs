using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace Library.Console;

class BooksXmlManager : IBooksManager
{
    public void Save(List<Book> books)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));
        using (FileStream fs = new FileStream("file.xml", FileMode.Create))
        {
            xmlSerializer.Serialize(fs, books);
        }
    }

    public List<Book> Load()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));
        
        using (FileStream fs = new FileStream("file.xml", FileMode.Open))
        {
            if (fs.Length == 0)
            {
                return new List<Book>();
            }
            return xmlSerializer.Deserialize(fs) as List<Book>;
        }
    }
}