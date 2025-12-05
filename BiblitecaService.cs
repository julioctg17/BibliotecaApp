using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;
using BibliotecaApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliotecaApp
{
    public static class BibliotecaService
    {
        public static void RegistrarDevolucion(
            List<Prestamo> prestamos,
            DoublyLinkedList<Book> libros,
            SimpleStack<Book> devoluciones,
            string titulo
        )
        {
            if (prestamos == null || prestamos.Count == 0)
            {
                MessageBox.Show("No hay préstamos pendientes.");
                return;
            }

            // Buscar préstamo por título (ignora mayúsculas)
            var prestamo = prestamos.FirstOrDefault(
                p => p.Libro.Equals(titulo, StringComparison.OrdinalIgnoreCase)
            );

            if (prestamo == null)
            {
                MessageBox.Show("Ese libro no está prestado.");
                return;
            }

            // Marcar libro como disponible y guardar en pila de devoluciones
            foreach (var libro in libros.TraverseForward())
            {
                if (libro.Title.Equals(prestamo.Libro, StringComparison.OrdinalIgnoreCase))
                {
                    libro.IsAvailable = true;
                    libro.PrestadoA = null;
                    devoluciones.Push(libro);
                    break;
                }
            }

            // Quitar de préstamos y guardar en almacenamiento
            prestamos.Remove(prestamo);
            DataStorage.GuardarPrestamos(prestamos);

            MessageBox.Show($"Devolución de '{titulo}' registrada correctamente.");
        }
    }
}

