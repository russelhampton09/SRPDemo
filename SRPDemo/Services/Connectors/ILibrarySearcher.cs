using SRPDemo.Models;
using System.Runtime.CompilerServices;

namespace SRPDemo.Services.Connectors
{
    //connectors wrap helper libraries such as SRP.OpenLibrary in case our underlying API changes
    //connectors will be the only classes which have knowledge of SRP.OpenLibrary namespace
    public interface ILibrarySearcher
    {
        Task<(IEnumerable<Book> books, int count)> SearchBooks(string title, int page);
    }
}
