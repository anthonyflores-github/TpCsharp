using System;
using System.Collections.Generic;

namespace TpBooks.Domain
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public double Amount { get; set; }

        public Book(Guid id, string title, double amount)
        {
            Id = id;
            Title = title;
            Amount = amount;
        }
    }
}