using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TpBooks.Data;
using TpBooks.Domain;

namespace TpBooks.Service
{
    public class BookService
    {
        private static readonly HttpClient Client = new HttpClient();

        public static string ReadApiGoogle(string title, string author)
        {
            var nexturl = "q=" + title + "+inauthor:" + author;

            string url = String.Concat("https://www.googleapis.com/books/v1/volumes?", nexturl);

            var response = Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync());
            }

            var json = response.Content.ReadAsStringAsync().Result;

            return json;
        }

        public static List<Bookdto> GetBooks()
        {
            return BookRepo.GetBooks()
                .Select(p => new Bookdto(
                    p.Id,
                    p.Title))
                .ToList();
        }

        public static Bookdto GetBooks(Guid id)
        {
            return ConvertDto(
                BookRepo.GetBooks()
                    .Where(p => p.Id == id)
                    .Select(p => p)
                    .FirstOrDefault()
            );
        }

        private static Bookdto ConvertDto(Book book)
        {
            if (book == null) return null;

            return new Bookdto(
                book.Id,
                book.Title);
        }

        public static void LoadJson(string jsonString)
        {
            List<Bookdto> book = new List<Bookdto>();
            List<Book> books = new List<Book>();

            JObject jsonObject = JObject.Parse(jsonString);
            List<JToken> results = jsonObject["items"].Children().ToList();

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    var newBook = results[i]["volumeInfo"].ToObject<Bookdto>();
                    newBook.Id = Guid.NewGuid();
                    book.Add(newBook);

                    using (var db = new DataContext())
                    {
                        // Create
                        Console.WriteLine("Inserting a new book");
                        db.Add(newBook);
                        db.SaveChanges();

                        // Read
                        Console.WriteLine("Querying for a blog");
                        var Book = db.Book
                            .OrderBy(b => b.Id)
                            .First();
                    }

                    //ConvertToDto(BookService.GetBooks()
                    //    .Select(p => p)
                    //    .FirstOrDefault());
                }
            }

            static Bookdto ConvertToDto(Book book)
            {
                if (book == null) return null;

                return new Bookdto(
                    book.Id,
                    book.Title);
            }
        }
    }
}