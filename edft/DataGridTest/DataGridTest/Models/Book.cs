using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DataGridTest.Models
{
    public class PagedBookModel
    {
        public List<Book> Books { get; set; }
        public int TotalRows { get; set; }
    }

    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
        }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}