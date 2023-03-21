using Microsoft.AspNetCore.Mvc;
using SRPDemo.Models;
using SRPDemo.Services.Connectors;

namespace SRPDemo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LibrarySearchController : ControllerBase
    {
        /// <summary>
        /// Open library API only returns 100 results but offers offset optional parameter. The front end needs to know how many in total the results are to show correct pagination information.
        /// I'll circle back to this if I have time, for now we will always show only the top 100
        /// </summary>
 
        public class BookResult
        {
            public IEnumerable<Book> Books { get; set; }
            public int Total { get; set; }
        }

        private readonly ILibrarySearcher librarySearcher;

        public LibrarySearchController(ILibrarySearcher librarySearcher)
        {
            this.librarySearcher = librarySearcher;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(int page, string title)
        {
            try
            {
                var result = await librarySearcher.SearchBooks(title, page);
                return Ok(result.books);
            }
            catch (Exception)
            {
                //normally logging here
                return BadRequest("Failed to get books");
            }
        }
    }
}
