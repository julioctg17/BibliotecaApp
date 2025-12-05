using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;
using BibliotecaApp.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace BibliotecaApp
{
    public partial class Gestion : Form
    {
        private readonly DoublyLinkedList<Book> libros;
        private readonly List<Prestamo> prestamos;
        private readonly SimpleStack<Book> devoluciones;
        private readonly Form1 formPrincipal;


        public Gestion(
    Form1 formPrincipal,
    DoublyLinkedList<Book> libros,
    List<Prestamo> prestamos,
    SimpleStack<Book> devoluciones
)
        {
            InitializeComponent();
            this.formPrincipal = formPrincipal;
            this.libros = libros;
            this.prestamos = prestamos;
            this.devoluciones = devoluciones;
           

            RefrescarComboPrestamos();
        }

        private void Gestion_Load(object sender, EventArgs e)
        {
            // Mostrar los libros al abrir la ventana
            RefrescarLista(libros);
            RefrescarComboPrestamos();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            comboBoxUsuarios.DataSource = formPrincipal.Usuarios;
            comboBoxUsuarios.DisplayMember = "NombreCompleto";    // Lo que se ve
            comboBoxUsuarios.ValueMember = "Matricula";   // Lo que se usa internamente
            comboBoxUsuarios.SelectedIndex = -1;          // Para que no seleccione nada por defecto
        }

        // 🔹 Refresca el ListBox con los libros actuales
        public void RefrescarLista(DoublyLinkedList<Book> listaLibros)
        {
            lstLibros.Items.Clear();
            foreach (var libro in listaLibros.TraverseForward())
                lstLibros.Items.Add(libro.ToString());
        }

        // 🔹 Mostrar todos los libros
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            RefrescarLista(libros);
        }

        // 🔹 Buscar por título o autor
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Introduce un título o autor para buscar.");
                return;
            }

            // Usamos IndexOf con StringComparison para soportar .NET Framework
            var resultado = Algorithms.LinearSearch(libros, l =>
                (l.Title != null && l.Title.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (l.Author != null && l.Author.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
            );

            lstLibros.Items.Clear();
            foreach (var libro in resultado)
                lstLibros.Items.Add(libro.ToString());
        }

        // 🔹 Ordenar por título (usa BubbleSort)
        private void btnOrdenarTitulo_Click(object sender, EventArgs e)
        {
            Algorithms.BubbleSort(libros, Algorithms.CompareByTitle);
            RefrescarLista(libros);
        }

        // 🔹 Ordenar por año 
        private void btnOrdenarAnio_Click(object sender, EventArgs e)
        {
            Algorithms.QuickSort(libros, Algorithms.CompareByYear);
            RefrescarLista(libros);
        }

        // 🔹 Registrar préstamo
        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            if (lstLibros.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un libro para préstamo.");
                return;
            }

            // Extrae el ISBN del formato [ISBN] Título - Autor
            string seleccionado = lstLibros.SelectedItem.ToString();
            string isbn = seleccionado.Split(']')[0].TrimStart('[');

            // Obtiene la matrícula del usuario seleccionado
            string matricula = comboBoxUsuarios.SelectedValue.ToString();

            // Llamamos al método de registro de préstamo pasando el ISBN y la matrícula
            formPrincipal.RegistrarPrestamo(isbn, matricula);

            RefrescarLista(libros);
            RefrescarComboPrestamos();
        }

        // 🔹 Registrar devolución
        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            if (cmbPrestamos.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un préstamo para devolver.");
                return;
            }

            string texto = cmbPrestamos.SelectedItem.ToString();
            string titulo = texto.Split('→')[0].Trim();

            BibliotecaService.RegistrarDevolucion(
                prestamos,
                libros,
                devoluciones,
                titulo
            );

            RefrescarLista(libros);
            RefrescarComboPrestamos();
        }

        // 🔹 Mostrar historial
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            formPrincipal.MostrarHistorial(lstLibros);
        }

        // 🔹 Regresar al menú principal
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            formPrincipal.Show();
            this.Close();
        }

        private void btnPrestamosActuales_Click(object sender, EventArgs e)
        {
            lstLibros.Items.Clear();

            foreach (var p in prestamos)
            {
                lstLibros.Items.Add($"Libro: {p.Libro} | Prestado a: {p.Usuario} | Fecha: {p.FechaPrestamo.ToShortDateString()}");
            }

            if (lstLibros.Items.Count == 0)
                lstLibros.Items.Add("No hay préstamos activos.");
        }

        public void RefrescarComboPrestamos()
        {
            cmbPrestamos.Items.Clear();
            cmbPrestamos.Text = "";   // ← LIMPIA EL TEXTO MOSTRADO

            foreach (var p in prestamos)
                cmbPrestamos.Items.Add($"{p.Libro} → {p.Usuario}");

            if (cmbPrestamos.Items.Count > 0)
                cmbPrestamos.SelectedIndex = 0;
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
