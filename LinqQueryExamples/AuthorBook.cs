using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryExamples
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int YearPublished { get; set; }
    }
    public class AuthorBook
    {

        public static void Main()
        {
            // Sample data for Author
            var authors = new List<Author>
            {
                new Author { AuthorId = 1, Name = "J.K. Rowling" },
                new Author { AuthorId = 2, Name = "George R.R. Martin" },
                new Author { AuthorId = 3, Name = "J.R.R. Tolkien" },
                new Author { AuthorId = 4, Name = "Agatha Christie" },
                new Author { AuthorId = 5, Name = "Stephen King" }
            };

            // Sample data for Book
            var books = new List<Book>
            {
                new Book { BookId = 1, Title = "Harry Potter and the Sorcerer's Stone", AuthorId = 1, YearPublished = 2012 },
                new Book { BookId = 2, Title = "A Game of Thrones", AuthorId = 2, YearPublished = 2012 },
                new Book { BookId = 3, Title = "The Hobbit", AuthorId = 3, YearPublished = 2012 },
                new Book { BookId = 4, Title = "Murder on the Orient Express", AuthorId = 4, YearPublished = 2012 },
                new Book { BookId = 5, Title = "The Shining", AuthorId = 4, YearPublished = 2013 },
                new Book { BookId = 6, Title = "The XYZ", AuthorId = 5, YearPublished = 2009 }
            };

            var res = authors
            .GroupJoin(
                books.Where(b => b.YearPublished > 2010),
                a => a.AuthorId,
                b => b.AuthorId,
                (a, bks) => new
                {
                    Author = a.Name,
                    Titles = bks.Select(b => b.Title).ToList()
                }
            )
            .ToList();

            var res1 = (from a in authors
                       join b in books.Where(b=>b.YearPublished > 2010) on a.AuthorId equals b.AuthorId into bks
                       
                       select new
                       {
                           Author = a.Name,
                           Titles = bks.Select(b => b.Title).ToList()
                       }).ToList();


            foreach (var x in res)                   // You can try either res or res1 here, both will give same output
            {
                Console.WriteLine(x.Author + " :");
                if (x.Titles.Count > 0)
                {
                    foreach (var title in x.Titles)
                    {
                        Console.WriteLine(title + ", ");
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine(" : No books\n");
                }
            }

        }
    }
}
