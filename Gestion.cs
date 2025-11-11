using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;
using BibliotecaApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliotecaApp
{
    public partial class Gestion : Form
    {
        private DoublyLinkedList<Book> libros;
        private Form1 formPrincipal;

        public Gestion(Form1 form, DoublyLinkedList<Book> libros)
        {
            InitializeComponent();
            this.formPrincipal = form;
            this.libros = libros;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var texto = txtBuscar.Text.Trim();
            if (texto == "")
            {
                MessageBox.Show("Introduce un título o autor para buscar.");
                return;
            }

            // Buscar coincidencias por título o autor (versión compatible)
            var resultado = Algorithms.LinearSearch(libros, l =>
                l.Title.ToLower().Contains(texto.ToLower()) ||
                l.Author.ToLower().Contains(texto.ToLower()));

            lstLibros.Items.Clear();
            foreach (var l in resultado)
                lstLibros.Items.Add(l.ToString());
        }

        private void btnOrdenarTitulo_Click(object sender, EventArgs e)
        {
            Algorithms.BubbleSort(libros, Algorithms.CompareByTitle);
            btnMostrar_Click(sender, e);
        }

        private void btnOrdenarAnio_Click(object sender, EventArgs e)
        {
            Algorithms.BubbleSort(libros, Algorithms.CompareByYear);
            btnMostrar_Click(sender, e);
        }

        private void lstLibros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lstLibros.Items.Clear();
            foreach (var l in libros.TraverseForward())
                lstLibros.Items.Add(l.ToString());
        }

        private void Gestion_Load(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            formPrincipal.Show(); // Vuelve a mostrar el Form1 original
            this.Close();
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            if (lstLibros.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un libro para préstamo.");
                return;
            }

            string seleccionado = lstLibros.SelectedItem.ToString();
            // Aquí puedes extraer el ISBN del string seleccionado
            string isbn = seleccionado.Split(']')[0].TrimStart('[');
            formPrincipal.RegistrarPrestamo(isbn);

        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            formPrincipal.RegistrarDevolucion();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            formPrincipal.MostrarHistorial(lstLibros);

        }
    }
}
