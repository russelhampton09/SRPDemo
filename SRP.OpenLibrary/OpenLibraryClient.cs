using SRP.OpenLibrary.Models;

namespace SRP.OpenLibrary
{
    internal class OpenLibraryClient : IOpenLibraryClient
    {
        private readonly IBookFactory bookFactory;
        private readonly HttpClient httpClient;
        private OpenLibrarySettings settings { get; }
 
        public OpenLibraryClient(IBookFactory bookFactory, OpenLibrarySettings settings, HttpClient httpClient)
        {
            this.bookFactory = bookFactory;
            this.settings = settings;
            this.httpClient = httpClient;
        }

        public async Task<(IEnumerable<Book> books, int count)> SearchBooksAsync(string bookName, int page = 1, CancellationToken? token = null)
        {
            CancellationToken cancel = token == null ? CancellationToken.None : token.Value;

            var uriBuilder = new UriBuilder($"{settings.BaseUrl}{settings.SearchRoute}");
            uriBuilder.Query = $"title={bookName.ToQueryStringSpaces()}&offset={page}";
            var result = await httpClient.GetAsync(uriBuilder.Uri, cancel);
            return bookFactory.BooksFromJson(await result.Content.ReadAsStringAsync(), settings.BaseUrl);
        }
    }
}