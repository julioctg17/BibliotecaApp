using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Models
{
    public class Usuario
    {
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellidos}";

        public Usuario(string matricula, string nombre, string apellidos)
        {
            Matricula = matricula;
            Nombre = nombre;
            Apellidos = apellidos;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellidos} ({Matricula})";
        }
    }
}
