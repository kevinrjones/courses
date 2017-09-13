using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataGridTest.Models;

namespace DataGridTest.Controllers
{
    public class HomeController : Controller
    {
        static readonly List<Book> Books = new List<Book>();
        private const int PageSize = 5;

        static HomeController()
        {
            CreateBooks();
        }

        private static void CreateBooks()
        {
            Book book = new Book { Title = "Catch-22", ISBN = "1111-2222", Authors = new List<Author> { new Author { Id = 1, Name = "Joseph Heller" } }, PublicationDate = new DateTime(1960, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "Catcher in the Rye", ISBN = "1111-3333", Authors = new List<Author> { new Author { Id = 2, Name = "JD Sallinger" } }, PublicationDate = new DateTime(1939, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "1984", ISBN = "1111-4444", Authors = new List<Author> { new Author { Id = 3, Name = "George Orwell" } }, PublicationDate = new DateTime(1948, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "I, Robot", ISBN = "1111-5555", Authors = new List<Author> { new Author { Id = 4, Name = "Isaac Asimov" } }, PublicationDate = new DateTime(1963, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "Brave New World", ISBN = "1111-6666", Authors = new List<Author> { new Author { Id = 5, Name = "Aldous Huxley" } }, PublicationDate = new DateTime(1939, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "To Kill A Mockingbird", ISBN = "1111-7777", Authors = new List<Author> { new Author { Id = 6, Name = "Harper Lee" } }, PublicationDate = new DateTime(1939, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "SlaughterHouse 5", ISBN = "1111-8888", Authors = new List<Author> { new Author { Id = 7, Name = "Kurt Vonegut" } }, PublicationDate = new DateTime(1960, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "Alice in Wonderland", ISBN = "1111-9999", Authors = new List<Author> { new Author { Id = 8, Name = "Lewis Carroll" } }, PublicationDate = new DateTime(1951, 1, 1) };
            Books.Add(book);

            book = new Book { Title = "The Science Of DiscWorld", ISBN = "1111-0000", Authors = new List<Author> { new Author { Id = 9, Name = "Terry Pratchett" }, new Author { Id = 10, Name = "Jack Cohen" }, new Author { Id = 9, Name = "Ian Stewart" }, }, PublicationDate = new DateTime(1951, 1, 1) };
            Books.Add(book);
        }

        public ActionResult Index(int page = 1,
            string sort = "Title",
            string sortDir = "Ascending")
        {
            var model = new PagedBookModel();
            List<Book> sorted;
            if (sort == "Title")
            {
                sorted = sortDir == "Ascending" ? Books.OrderBy(i => i.Title).ToList() : Books.OrderByDescending(i => i.Title).ToList();
            }
            else
            {
                sorted = sortDir == "Ascending" ? Books.OrderBy(i => i.PublicationDate).ToList() : Books.OrderByDescending(i => i.PublicationDate).ToList();
            }

            model.Books = sorted
                .Skip((page - 1) * PageSize)
                .Take(PageSize).ToList();

            model.TotalRows = Books.Count;

            return View(model);
        }
    }

}