using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escuela.Entities
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Ciclo { get; set; }
        public int Curso { get; set; }
        public string DescripcionCurso { get; set; }
        public bool Estado { get; set; }
        public int Version { get; set; }
        public List<Calificacion> Notas { get; set; }
        public decimal Promedio { get; set; }

    }
}
