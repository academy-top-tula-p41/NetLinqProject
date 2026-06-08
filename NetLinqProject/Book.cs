using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLinqProject
{
    internal class Book
    {
        public string Title { get; set; } = null!;
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int? PublishYear { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Publisher: {Publisher}, Year: {PublishYear}, Price: {Price}";
        }

        public static List<Book> GetBooks()
        {
            List<Book> books = new()
            {
                new()
                {
                    Title = "Война и мир",
                    Author = "Толстой",
                    Publisher = "Мир книги",
                    PublishYear = 2000,
                    Price = 950
                },
                new()
                {
                    Title = "КЗОТ",
                    Author = "",
                    Publisher = "Наука",
                    PublishYear = 1997,
                    Price = 250
                },
                new()
                {
                    Title = "Дубровский",
                    Author = "Пушкин",
                    Publisher = "Мир книги",
                    PublishYear = 2005,
                    Price = 350
                },
                new()
                {
                    Title = "Севастопольские рассказы",
                    Author = "Толстой",
                    Publisher = "Наука",
                    PublishYear = 1989,
                    Price = 400
                },
                new()
                {
                    Title = "Евгений Онегин",
                    Author = "Пушкин",
                    Publisher = "Знание",
                    PublishYear = 2002,
                    Price = 650
                },
            };
            return books;
        }
    }


}
