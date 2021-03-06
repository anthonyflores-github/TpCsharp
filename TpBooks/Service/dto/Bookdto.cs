﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TpBooks
{
    public class Bookdto
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public Guid Id { get; set; }

        public string Title { get; set; }

        //public List<string> Authors { get; set; }

        public string Publisher { get; set; }

        public string PublishedDate { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public string PrintType { get; set; }

        public int AverageRating { get; set; }

        public int RatingsCount { get; set; }

        public string Language { get; set; }

        public string PreviewLink { get; set; }

        public string InfoLink { get; set; }

        public Bookdto(Guid id, string title)
        {
            Id = id;
            Title = title;
            ;
        }
    }
}