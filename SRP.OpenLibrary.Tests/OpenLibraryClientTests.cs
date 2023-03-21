using Moq;
using Xunit;

namespace SRP.OpenLibrary.Tests
{

    public class OpenLibraryClientTests
    {
        private OpenLibraryClient client;

        public OpenLibraryClientTests()
        {
            client = new OpenLibrary.OpenLibraryClient(new Mock<IBookFactory>().Object, new OpenLibrarySettings(), new HttpClient());
        }

        [Fact]
        public async void SearchForBookReturns200()
        {
            //setup
            //test requires internet connection

            //do
            var result = await client.SearchBooksAsync("the");
            //assert
            //success if error code 200, no exception
        }
    }
}