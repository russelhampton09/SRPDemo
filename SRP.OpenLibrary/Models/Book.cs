namespace SRP.OpenLibrary.Models
{
    public class Book
    {
        public List<string> AuthorName { get; set; } = new List<string>();
        public string BookTitle { get; set; }
        public string WorkRoute{ get; set; }
        public string BookLink { get; set; }
    } 
}


