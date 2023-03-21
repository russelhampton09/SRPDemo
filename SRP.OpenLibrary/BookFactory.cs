using Newtonsoft.Json.Linq;
using SRP.OpenLibrary.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SRP.OpenLibrary.Tests")]
namespace SRP.OpenLibrary
{
    internal class BookFactory : IBookFactory
    {
        public (IEnumerable<Book> books, int count) BooksFromJson(string payload, string rootLibUrl)
        {
            var jsonRoot = JObject.Parse(payload);
            var docArray = JArray.Parse(jsonRoot.SelectToken("docs").ToString());
            var count = jsonRoot.Value<int>("numFound");
            return (BookFromDoc(docArray, rootLibUrl), count);
        }

        //genreator
        private IEnumerable<Book> BookFromDoc(JArray docArray, string rootLibUrl)
        {
            foreach (var doc in docArray)
            {
                var book = new Book();
                var authorArray = doc.SelectToken("author_name");

                if (authorArray != null)
                {
                    var authors = JArray.Parse(authorArray.ToString());
                    foreach (var authToken in authors)
                    {
                        book.AuthorName.Add(authToken.Value<string>());
                    }
                }

                book.BookTitle = doc.Value<string>("title") ?? "Unknown title";
                book.WorkRoute = doc.Value<string>("key") ?? "Unknown key";
                book.BookLink = $"{rootLibUrl}{book.WorkRoute}";
                yield return book;
            }
        }
    }


}


