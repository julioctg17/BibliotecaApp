using System;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.DataStructures;
using BibliotecaApp.Utils;

namespace BibliotecaApp
{
    public partial class Form1 : Form
    {
        DoublyLinkedList<Book> libros = new DoublyLinkedList<Book>();
        SimpleQueue<Book> prestamos = new SimpleQueue<Book>();
        SimpleStack<Book> devoluciones = new SimpleStack<Book>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            if (!int.TryParse(txtYear.Text.Trim(), out int year))
            {
                MessageBox.Show("Año inválido.");
                return;
            }

            var libro = new Book(txtISBN.Text.Trim(), txtTitle.Text.Trim(), txtAuthor.Text.Trim(), year);
            libros.AddLast(libro);
            MessageBox.Show("Libro registrado correctamente.");
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            RefrescarLista();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnOrdenarTitulo_Click(object sender, EventArgs e)
        {
            Algorithms.BubbleSort(libros, (a, b) =>
                string.Compare(a.Title, b.Title, StringComparison.CurrentCultureIgnoreCase));
            RefrescarLista();
        }

        private void btnOrdenarAnio_Click(object sender, EventArgs e)
        {
            Algorithms.BubbleSort(libros, (a, b) => a.Year.CompareTo(b.Year));
            RefrescarLista();
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {

         }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            if (prestamos.IsEmpty())
            {
                MessageBox.Show("No hay préstamos pendientes.");
                return;
            }

            var libro = prestamos.Dequeue();
            libro.IsAvailable = true;
            devoluciones.Push(libro);
            MessageBox.Show($"Libro '{libro.Title}' devuelto correctamente.");
            RefrescarLista();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {

        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            Gestion gestion = new Gestion(this, libros); // ✅ Pasa el Form1 y la lista
            gestion.Show();
            this.Hide();
        }

        // 🔹 Método auxiliar para refrescar el ListBox
        private void RefrescarLista()
        {

        }

        private void btnGestion_Click_1(object sender, EventArgs e)
        {
            Gestion gestion = new Gestion(this, libros);
            gestion.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void RegistrarPrestamo(string isbn)
        {
            foreach (var l in libros.TraverseForward())
            {
                if (l.ISBN == isbn && l.IsAvailable)
                {
                    l.IsAvailable = false;
                    prestamos.Enqueue(l);
                    MessageBox.Show($"Préstamo de '{l.Title}' registrado correctamente.");
                    return;
                }
            }
            MessageBox.Show("El libro no está disponible o ya fue prestado.");
        }

        public void RegistrarDevolucion()
        {
            if (prestamos.IsEmpty())
            {
                MessageBox.Show("No hay préstamos pendientes.");
                return;
            }

            var libro = prestamos.Dequeue();
            libro.IsAvailable = true;
            devoluciones.Push(libro);
            MessageBox.Show($"Libro '{libro.Title}' devuelto correctamente.");
        }

        public void MostrarHistorial(ListBox lst)
        {
            lst.Items.Clear();
            foreach (var libro in devoluciones.Traverse())
            {
                lst.Items.Add(libro.ToString());
            }
        }


    }
}
