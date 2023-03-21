using Xunit;

namespace SRP.OpenLibrary.Tests
{
    public class BookFactoryTests
    {
        private BookFactory bookFactory;
        private string openLibJson;

        public BookFactoryTests()
        {
            bookFactory = new BookFactory();
            openLibJson = File.ReadAllText("../../../openLibraryExample.json");
        }

        [Fact]
        public void PrasesDocsWithCorrectValues()
        {
            //act
            var result = bookFactory.BooksFromJson(openLibJson, "testurl");
            var enumerated = result.books.ToList();

            //assert
            Assert.True(result.count > 0);
            Assert.Equal("Harry Potter and the Sorcerer's Stone", enumerated[0].BookTitle);
            Assert.Equal("/works/OL28989508W", enumerated[0].WorkRoute);
            Assert.Equal("J. K. Rowling", enumerated[0].AuthorName[0]);
        }
    }
}