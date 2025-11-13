using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;
using BibliotecaApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BibliotecaApp
{
    public partial class Form1 : Form
    {
        // Estructuras principales
        private DoublyLinkedList<Book> libros;
        private List<Usuario> usuarios;
        private SimpleQueue<Book> prestamos = new SimpleQueue<Book>();
        private SimpleStack<Book> devoluciones = new SimpleStack<Book>();

        // Constructor principal
        public Form1()
        {
            InitializeComponent();

            // Si existen archivos guardados, se cargan
            libros = DataStorage.CargarLibros();
            usuarios = DataStorage.CargarUsuarios();

            // Si están vacíos (primera ejecución), se llenan con datos iniciales
            if (libros == null || libros.Count == 0)
                libros = DataSeeder.GetLibrosIniciales();

            if (usuarios == null || usuarios.Count == 0)
                usuarios = DataSeeder.GetUsuariosIniciales();
        }

        // ---------------------------------------------------------------------
        // EVENTOS PRINCIPALES DEL FORMULARIO
        // ---------------------------------------------------------------------



        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e) { }

        // ---------------------------------------------------------------------
        // BOTONES PRINCIPALES
        // ---------------------------------------------------------------------

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

            // Validar que el año sea un número válido
            if (!int.TryParse(cmbYear.SelectedItem.ToString(), out int anio))
            {
                MessageBox.Show("Por favor selecciona un año válido.");
                return;
            }

            // Crear y registrar libro
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

            // Limpiar campos
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            cmbYear.SelectedItem = DateTime.Now.Year.ToString();

            RefrescarLista();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Se puede implementar búsqueda por título o autor aquí si se desea
        }

        private void btnOrdenarTitulo_Click(object sender, EventArgs e)
        {
            // Reemplaza BubbleSort por QuickSort
            Algorithms.QuickSort(libros, (a, b) =>
                string.Compare(a.Title, b.Title, StringComparison.CurrentCultureIgnoreCase));
            RefrescarLista();
        }

        private void btnOrdenarAnio_Click(object sender, EventArgs e)
        {
            Algorithms.QuickSort(libros, (a, b) => a.Year.CompareTo(b.Year));
            RefrescarLista();
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            // Pendiente: préstamo directo desde la lista
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
            // Se puede mostrar historial de devoluciones si se desea
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            try
            {
                Gestion gestion = new Gestion(this, libros);
                gestion.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Gestión: " + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // MÉTODOS AUXILIARES
        // ---------------------------------------------------------------------

        private void RefrescarLista()
        {

        }

        public void RegistrarPrestamo(string isbn)
        {
            if (usuarios.Count == 0)
            {
                MessageBox.Show("No hay usuarios registrados para asignar el préstamo.");
                return;
            }

            // Seleccionar usuario
            string nombresUsuarios = string.Join("\n", usuarios.Select(u => $"{u.Matricula} - {u.Nombre} {u.Apellidos}"));
            string matricula = Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese la matrícula del usuario que tomará el libro:\n\n{nombresUsuarios}",
                "Registrar préstamo"
            );

            var usuario = usuarios.Find(u => u.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase));
            if (usuario == null)
            {
                MessageBox.Show("No se encontró ningún usuario con esa matrícula.");
                return;
            }

            foreach (var l in libros.TraverseForward())
            {
                if (l.ISBN == isbn && l.IsAvailable)
                {
                    l.IsAvailable = false;
                    l.PrestadoA = $"{usuario.Nombre} {usuario.Apellidos}";
                    prestamos.Enqueue(l);
                    MessageBox.Show($"Libro '{l.Title}' prestado a {usuario.Nombre} {usuario.Apellidos}.");
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

        private void btnGestion_Click_1(object sender, EventArgs e)
        {
            var gestion = new Gestion(this, libros);
            gestion.RefrescarLista(libros); // opcional, pero recomendable
            gestion.Show();
            this.Hide();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true; // Ignora el carácter si no es válido
            }

            // Evitar que el ISBN empiece con un guion
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Length == 0)
            {
                e.Handled = true;
            }

            // Evitar guiones consecutivos
            if (e.KeyChar == '-' && ((TextBox)sender).Text.EndsWith("-"))
            {
                e.Handled = true;
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();

            // Validación de campos
            if (string.IsNullOrWhiteSpace(matricula) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellidos))
            {
                MessageBox.Show("Por favor completa todos los campos del usuario.");
                return;
            }

            // Verificar que la matrícula no esté duplicada
            if (usuarios.Exists(u => u.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un usuario con esa matrícula.");
                return;
            }

            // Crear nuevo usuario
            Usuario nuevoUsuario = new Usuario(matricula, nombre, apellidos);
            usuarios.Add(nuevoUsuario);

            MessageBox.Show($"Usuario {nombre} {apellidos} agregado correctamente.");

            // Limpiar campos
            txtMatricula.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();

            RefrescarListaUsuarios();
        }

        // Refresca la lista visual de usuarios
        private void RefrescarListaUsuarios()
        {
            lstUsuarios.Items.Clear();
            foreach (var usuario in usuarios)
            {
                lstUsuarios.Items.Add(usuario.ToString());
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataStorage.GuardarLibros(libros);
            DataStorage.GuardarUsuarios(usuarios);

          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Llenar ComboBox con los años válidos (del actual hacia 1900)
            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                cmbYear.Items.Add(i);
            }

            cmbYear.SelectedItem = DateTime.Now.Year;
            RefrescarLista();
            RefrescarListaUsuarios();
        }
    }
}
