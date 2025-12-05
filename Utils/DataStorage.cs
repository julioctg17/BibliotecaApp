using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace BibliotecaApp.Utils
{
    public static class DataStorage
    {
        private static string librosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libros.json");
        private static string usuariosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.json");
        private static readonly string prestamosPath = "prestamos.json";
        private static readonly string devolucionesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devoluciones.json");

        // ---------------- GUARDAR ----------------
        public static void GuardarLibros(DoublyLinkedList<Book> libros)
        {
            try
            {
                var lista = new List<Book>(libros.TraverseForward());
                var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(librosPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar libros: " + ex.Message);
            }
        }

        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            try
            {
                var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(usuariosPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuarios: " + ex.Message);
            }
        }

        public static void GuardarPrestamos(List<Prestamo> prestamos)
        {
            try
            {
                var json = JsonSerializer.Serialize(prestamos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(prestamosPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar préstamos: " + ex.Message);
            }
        }

        // ---------------- CARGAR ----------------
        public static DoublyLinkedList<Book> CargarLibros()
        {
            var lista = new DoublyLinkedList<Book>();
            if (File.Exists(librosPath))
            {
                try
                {
                    string json = File.ReadAllText(librosPath);
                    var libros = JsonSerializer.Deserialize<List<Book>>(json);
                    if (libros != null)
                    {
                        foreach (var l in libros)
                            lista.AddLast(l);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar libros: " + ex.Message);
                }
            }
            return lista;
        }

        public static List<Usuario> CargarUsuarios()
        {
            if (File.Exists(usuariosPath))
            {
                try
                {
                    string json = File.ReadAllText(usuariosPath);
                    var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
                    if (usuarios != null)
                        return usuarios;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
            }
            return new List<Usuario>();
        }

        public static List<Prestamo> CargarPrestamos()
        {
            if (File.Exists(prestamosPath))
            {
                try
                {
                    string json = File.ReadAllText(prestamosPath);
                    var prestamos = JsonSerializer.Deserialize<List<Prestamo>>(json);
                    if (prestamos != null)
                        return prestamos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar préstamos: " + ex.Message);
                }
            }
            return new List<Prestamo>();
        }

        public static void GuardarDevoluciones(SimpleStack<Book> devoluciones)
        {
            try
            {
                var lista = new List<Book>();
                var aux = new SimpleStack<Book>();

                // Sacamos todos los libros de la pila y los ponemos en lista y aux
                while (!devoluciones.IsEmpty())
                {
                    var libro = devoluciones.Pop();
                    lista.Add(libro);
                    aux.Push(libro);
                }

                // Reconstruimos la pila original
                while (!aux.IsEmpty())
                {
                    devoluciones.Push(aux.Pop());
                }

                var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(devolucionesPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar devoluciones: " + ex.Message);
            }
        }

        public static SimpleStack<Book> CargarDevoluciones()
        {
            var pila = new SimpleStack<Book>();
            if (File.Exists(devolucionesPath))
            {
                try
                {
                    string json = File.ReadAllText(devolucionesPath);
                    var lista = JsonSerializer.Deserialize<List<Book>>(json);
                    if (lista != null)
                    {
                        // Insertamos en la pila en orden
                        foreach (var libro in lista)
                            pila.Push(libro);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar devoluciones: " + ex.Message);
                }
            }
            return pila;
        }
    }
}