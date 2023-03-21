using SRP.OpenLibrary;
using SRPDemo.Models;

namespace SRPDemo.Services.Connectors
{
    //wrapper for external dependency
    public class LibrarySeacher : ILibrarySearcher
    {
        private readonly IOpenLibraryClient client;

        public LibrarySeacher(IOpenLibraryClient client)
        {
            this.client = client;
        }

        public async Task<(IEnumerable<Book> books, int count)> SearchBooks(string title, int page)
        {
            var result = await client.SearchBooksAsync(title, page);
            var books = ConvertToSRPBook(result.books);
            return (books, result.count);
        }

        private IEnumerable<Book> ConvertToSRPBook(IEnumerable<SRP.OpenLibrary.Models.Book> openLibBooks)
        {
            foreach (var openLibBook in openLibBooks)
            {
                yield return new Book()
                {
                    Author = String.Join(", ", openLibBook.AuthorName),
                    Link = openLibBook.BookLink,
                    Title = openLibBook.BookTitle
                };
            }
        }
    }
}
