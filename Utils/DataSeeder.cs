using System.Collections.Generic;
using BibliotecaApp.Models;
using BibliotecaApp.DataStructures;

namespace BibliotecaApp.Utils
{
    public static class DataSeeder
    {
        // 🔹 Carga inicial de libros
        public static DoublyLinkedList<Book> GetLibrosIniciales()
        {
            var libros = new DoublyLinkedList<Book>();

            libros.AddLast(new Book("978-84-376-0494-7", "Cien Años de Soledad", "Gabriel García Márquez", 1967));
            libros.AddLast(new Book("978-0-14-243723-0", "Don Quijote de la Mancha", "Miguel de Cervantes", 1605));
            libros.AddLast(new Book("978-84-670-0564-6", "La Sombra del Viento", "Carlos Ruiz Zafón", 2001));
            libros.AddLast(new Book("978-84-204-8303-8", "El Principito", "Antoine de Saint-Exupéry", 1943));
            libros.AddLast(new Book("978-84-08-18145-9", "Rayuela", "Julio Cortázar", 1963));
            libros.AddLast(new Book("978-607-07-0833-4", "Pedro Páramo", "Juan Rulfo", 1955));
            libros.AddLast(new Book("978-84-339-7412-1", "El Amor en los Tiempos del Cólera", "Gabriel García Márquez", 1985));
            libros.AddLast(new Book("978-987-566-538-4", "Crónica de una Muerte Anunciada", "Gabriel García Márquez", 1981));
            libros.AddLast(new Book("978-84-376-0498-5", "La Ciudad y los Perros", "Mario Vargas Llosa", 1963));

            return libros;
        }

        // 🔹 Carga inicial de usuarios
        public static List<Usuario> GetUsuariosIniciales()
        {
            return new List<Usuario>
            {
                new Usuario("A001", "Julio", "Pérez López"),
                new Usuario("A002", "María", "López Hernández"),
                new Usuario("A003", "Carlos", "Ramírez Ortega"),
                new Usuario("A004", "Laura", "Torres Gómez"),
                new Usuario("A005", "Ana", "Martínez Rivera")
            };
        }
    }
}
