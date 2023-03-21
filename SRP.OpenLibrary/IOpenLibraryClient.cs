using SRP.OpenLibrary.Models;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SRP.OpenLibrary
{
    public interface IOpenLibraryClient
    {
        Task<(IEnumerable<Book> books, int count)> SearchBooksAsync(string bookName, int page = 1, CancellationToken? token = null);
    }
}