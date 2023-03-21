using SRP.OpenLibrary.Models;

namespace SRP.OpenLibrary
{
    public interface IBookFactory
    {
        (IEnumerable<Book> books, int count) BooksFromJson(string json, string rootLibUrl);
    }
}


