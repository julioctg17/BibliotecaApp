using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;
using BibliotecaApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliotecaApp
{
    public partial class Form1 : Form
    {
        private DoublyLinkedList<Book> libros;
        private List<Usuario> usuarios = new List<Usuario>();

        private SimpleQueue<Book> prestamos = new SimpleQueue<Book>();
        private SimpleStack<Book> devoluciones = new SimpleStack<Book>();

        public static List<Prestamo> PrestamosActuales = new List<Prestamo>();

        public List<Usuario> Usuarios { get { return usuarios; } }

        public Form1()
        {
            InitializeComponent();

            libros = DataStorage.CargarLibros();
            usuarios = DataStorage.CargarUsuarios();
            PrestamosActuales = DataStorage.CargarPrestamos();
            devoluciones = DataStorage.CargarDevoluciones();

            if (libros == null || libros.Count == 0)
                libros = DataSeeder.GetLibrosIniciales();

            if (usuarios == null || usuarios.Count == 0)
                usuarios = DataSeeder.GetUsuariosIniciales();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                cmbYear.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Por favor completa todos los campos.");
                return;
            }

            if (!int.TryParse(cmbYear.SelectedItem.ToString(), out int anio))
            {
                MessageBox.Show("Por favor selecciona un año válido.");
                return;
            }

            Book nuevoLibro = new Book
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Year = anio,
                ISBN = txtISBN.Text.Trim(),
                IsAvailable = true
            };

            libros.AddLast(nuevoLibro);

            MessageBox.Show("📚 Libro registrado correctamente.");

            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            cmbYear.SelectedItem = DateTime.Now.Year.ToString();


        }





        //--------------------------------------------------------------------
        // ✔ PRESTAMO CORREGIDO COMPLETO Y FUNCIONAL
        //--------------------------------------------------------------------
        public void RegistrarPrestamo(string isbn, string matricula)
        {
            var usuario = usuarios.Find(u =>
                u.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                MessageBox.Show("No existe un usuario con esa matrícula.");
                return;
            }

            foreach (var l in libros.TraverseForward())
            {
                if (l.ISBN == isbn && l.IsAvailable)
                {
                    l.IsAvailable = false;
                    l.PrestadoA = usuario.Nombre + " " + usuario.Apellidos;

                    prestamos.Enqueue(l);

                    PrestamosActuales.Add(new Prestamo
                    {
                        Usuario = l.PrestadoA,
                        Libro = l.Title,
                        FechaPrestamo = DateTime.Now
                    });

                    DataStorage.GuardarPrestamos(PrestamosActuales);

                    MessageBox.Show($"Libro '{l.Title}' prestado a {l.PrestadoA}.");
                    return;
                }
            }

            MessageBox.Show("El libro ya está prestado.");
        }



        //--------------------------------------------------------------------

        public void MostrarHistorial(ListBox lst)
        {
            lst.Items.Clear();
            foreach (var libro in devoluciones.Traverse())
                lst.Items.Add(libro.ToString());
        }

        private void btnGestion_Click_1(object sender, EventArgs e)
        {
            Gestion gestion = new Gestion(this, libros, PrestamosActuales, devoluciones);
            gestion.Show();
            this.Hide();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();

            if (string.IsNullOrWhiteSpace(matricula) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellidos))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            if (usuarios.Exists(u => u.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un usuario con esa matrícula.");
                return;
            }

            usuarios.Add(new Usuario(matricula, nombre, apellidos));
            MessageBox.Show("Usuario agregado.");

            txtMatricula.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();

            RefrescarListaUsuarios();
        }

        private void RefrescarListaUsuarios()
        {
            lstUsuarios.Items.Clear();
            foreach (var u in usuarios)
                lstUsuarios.Items.Add(u.ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataStorage.GuardarLibros(libros);
            DataStorage.GuardarUsuarios(usuarios);
            DataStorage.GuardarPrestamos(PrestamosActuales);
            DataStorage.GuardarDevoluciones(devoluciones);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i >= 1900; i--)
                cmbYear.Items.Add(i);

            cmbYear.SelectedItem = DateTime.Now.Year;
            RefrescarListaUsuarios();
        }
    }
}