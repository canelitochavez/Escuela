using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Escuela.Entities;

namespace Escuela.Data
{
    public static class GenericData
    {
        public static List<Curso> ListarCursos()
        {
            List<Curso> cursos = new List<Curso>();

            cursos.Add(new Curso()
            {
                Id = 1,
                Descripcion = "Programación Orientada Objetos I"
            }) ;

            
            cursos.Add(new Curso()
            {
                Id = 2,
                Descripcion = "Base de Datos I"
            });

            
            cursos.Add(new Curso()
            {
                Id = 3,
                Descripcion = "Aplicaciones WEB I"
            });

            
            cursos.Add(new Curso()
            {
                Id = 4,
                Descripcion = "Análisis y Diseño de Sistemas I"
            });

            return cursos;
        }

        public static List<Ciclo> ListarCiclos()
        {
            List<Ciclo> ciclos = new List<Ciclo>();

            ciclos.Add(new Ciclo()
            {
                Id= 1,
                Descripcion="Primero"
            });

            ciclos.Add(new Ciclo()
            {
                Id = 2,
                Descripcion = "Segundo"
            });

            ciclos.Add(new Ciclo()
            {
                Id = 3,
                Descripcion = "Tercero"
            });

            ciclos.Add(new Ciclo()
            {
                Id = 4,
                Descripcion = "Cuarto"
            });

            ciclos.Add(new Ciclo()
            {
                Id = 5,
                Descripcion = "Quinto"
            });

            ciclos.Add(new Ciclo()
            {
                Id = 6,
                Descripcion = "Sexto"
            });

            return ciclos;
        }

        public static List<Evaluacion> ListarEvaluaciones()
        {
            List<Evaluacion> evaluaciones = new List<Evaluacion>();

            evaluaciones.Add(new Evaluacion
            {
                Id = 1,
                Tipo = "Evaluación Continua 1",
                Peso = 0.1m
            });

            evaluaciones.Add(new Evaluacion
            {
                Id = 2,
                Tipo = "Evaluación Continua 2",
                Peso = 0.15m
            });

            evaluaciones.Add(new Evaluacion
            {
                Id = 3,
                Tipo = "Evaluación Continua 3",
                Peso = 0.15m
            });

            evaluaciones.Add(new Evaluacion
            {
                Id = 4,
                Tipo = "Parcial",
                Peso = 0.2m
            });

            evaluaciones.Add(new Evaluacion
            {
                Id = 5,
                Tipo = "Final",
                Peso = 0.4m
            });

            return evaluaciones;
        }
    }
}
