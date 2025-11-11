using System;

namespace BibliotecaApp.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Book() { }

        public Book(string isbn, string title, string author, int year)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Year = year;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"[{ISBN}] {Title} - {Author} ({Year}) - {(IsAvailable ? "Disponible" : "Prestado")}";
        }
    }
}
