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
    }
}
