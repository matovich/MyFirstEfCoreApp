using System;
using Microsoft.EntityFrameworkCore;

namespace MyFirstEfCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");

        }

        public static void ListAll()
        {
            using (var db = new AppDbContext())
            {
                foreach (var book in db.Books.AsNoTracking().Include(a => a.Author))
                {
                    var webUrl = book.Author.WebUrl == null ? "- no web URL biven -" : book.Author.WebUrl;
                    Console.WriteLine($"{book.Title} by {book.Author.Name}");
                    Console.WriteLine($"   Published on {book.PublishedOn:dd-MMM-yyyy}. {webUrl}");
                }
            }
        }
    }
}
