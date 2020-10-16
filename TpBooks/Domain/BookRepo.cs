using System;
using System.Collections.Generic;

namespace TpBooks.Domain
{
    public class BookRepo
    {
        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            books.Add(new Book(
                Guid.Parse("a4df38dd-58aa-4fd4-bff9-afd149905b7a"),
                "a",
                2));

            return books;
        }
    }
}