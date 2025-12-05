using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Models
{
    public class Prestamo
    {
        public string Usuario { get; set; }
        public string Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }

        public Prestamo() { }

        public Prestamo(string usuario, string libro)
        {
            Usuario = usuario;
            Libro = libro;
            FechaPrestamo = DateTime.Now;
        }
    }

}
