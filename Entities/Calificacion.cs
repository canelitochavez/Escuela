using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escuela.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public int IdTipoEvaluacion { get; set; }
        public decimal Nota { get; set; }

    }
}
