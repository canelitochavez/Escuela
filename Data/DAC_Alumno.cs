using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Escuela.Entities;
using Escuela.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;

namespace Escuela.Data
{
    public class DAC_Alumno : ILogic
    {
        string connectString = ConfigurationManager.ConnectionStrings["EscuelaDB"].ToString();
        const string Estado_Activo = "1";
        const string Estado_Inactivo = "0";

        public bool ActualizarAlumno(Alumno alumno)
        {
            // Solo Cabecera

            bool isSuccess = false;

            try
            {
                //Declaramos la transaccion
                using(TransactionScope scope =new TransactionScope())
                {
                    //Establecemos la conexion
                    using(var conn = new SqlConnection(connectString))
                    {
                        conn.Open();

                        string actualizaAlumno = "Update Alumno " +
                            "Set Codigo = @Codigo, " +
                            "Nombre = @Nombre, " +
                            "Ciclo = @Ciclo, " +
                            "Curso = @Curso " +
                            "Where " +
                            "Id = @Id AND " +
                            "CONVERT(INT,Version) = @Version";

                        using (var commandAlumno = new SqlCommand(actualizaAlumno, conn)) 
                        {
                            commandAlumno.Parameters.Add(new SqlParameter("@Codigo", alumno.Codigo));
                            commandAlumno.Parameters.Add(new SqlParameter("@Nombre", alumno.Nombre));
                            commandAlumno.Parameters.Add(new SqlParameter("@Ciclo", alumno.Ciclo));
                            commandAlumno.Parameters.Add(new SqlParameter("@Curso", alumno.Curso));
                            commandAlumno.Parameters.Add(new SqlParameter("@Id", alumno.Id));
                            commandAlumno.Parameters.Add(new SqlParameter("@Version", alumno.Version));

                            var filasActualizadas = commandAlumno.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                isSuccess = true;
                                scope.Complete();
                            }
                            else
                            {
                                scope.Dispose();
                            }
                        }
                    }
                }
                return isSuccess;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public bool EliminarAlumno(int idAlumno, int version)
        {
            bool isSuccess = false;

            try
            {
                //Declaramos la transaccion
                using(TransactionScope scope = new TransactionScope())
                {
                    //Establecemos la conexion
                    using(var conn = new SqlConnection(connectString))
                    {
                        conn.Open();

                        string eliminarCalificaciones = "Delete From Calificacion Where IdAlumno = @IdAlumno";

                        using(var commandCalificaciones = new SqlCommand(eliminarCalificaciones, conn))
                        {
                            commandCalificaciones.Parameters.Add(new SqlParameter("@IdAlumno", idAlumno));

                            var notasEliminadas = commandCalificaciones.ExecuteNonQuery();

                            if (notasEliminadas > 0)
                            {
                                string actualizaAlumno = "Update Alumno " +
                                    "Set Estado = @Estado " +
                                    "Where id = @Id AND CONVERT(INT,Version) = @Version";

                                using(var commadAlumno = new SqlCommand(actualizaAlumno, conn))
                                {
                                    commadAlumno.Parameters.Add(new SqlParameter("@Id", idAlumno));
                                    commadAlumno.Parameters.Add(new SqlParameter("@Estado", Estado_Inactivo));
                                    commadAlumno.Parameters.Add(new SqlParameter("@Version", version));

                                    var alumnoEliminado = commadAlumno.ExecuteNonQuery();

                                    if (alumnoEliminado > 0)
                                    {
                                        isSuccess = true;
                                        scope.Complete();
                                    }
                                    else
                                    {
                                        scope.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                scope.Dispose();
                            }
                        }
                    }
                }

                return isSuccess;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();

            using(var conn = new SqlConnection(connectString))
            {
                conn.Open();

                using(var command = new SqlCommand("Select Id, Codigo, Nombre, Ciclo, Curso From Alumno Where Estado = @activo",conn))
                {
                    command.Parameters.Add(new SqlParameter("@activo", Estado_Activo));

                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Alumno alumno = new Alumno()
                            {
                                Id = (int)reader["Id"],
                                Codigo = (string)reader["Codigo"],
                                Nombre = (string)reader["Nombre"],
                                Ciclo = (int)reader["Ciclo"],
                                Curso = (int)reader["Curso"]
                            };

                            alumnos.Add(alumno);
                        }
                    }
                }
            }
            return alumnos;
        }

        public List<Calificacion> ListarNotas()
        {
            List<Calificacion> calificaciones = new List<Calificacion>();

            using(var conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (var command = new SqlCommand("Select IdAlumno, IdTipoEvaluacion, Nota From Calificacion",conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Calificacion calificacion = new Calificacion()
                            {
                                IdAlumno = (int)reader["IdAlumno"],
                                IdTipoEvaluacion = (int)reader["IdTipoEvaluacion"],
                                Nota = (reader["Nota"] == DBNull.Value) ? 0 : (decimal)reader["Nota"]
                            };

                            calificaciones.Add(calificacion);
                        }
                    }
                }
                
                return calificaciones;
            }
        }

        public Alumno ObtenerAlumno(string codigoAlumno)
        {
            Alumno alumno = new Alumno();

            using(var conn = new SqlConnection(connectString))
            {
                conn.Open();

                using(var command = new SqlCommand("Select Id, Codigo, Nombre, Ciclo, Curso, CONVERT(INT,Version) Version From Alumno Where Estado = @activo and Codigo = @codigoAlumno", conn))
                {
                    command.Parameters.Add(new SqlParameter("@activo", Estado_Activo));
                    command.Parameters.Add(new SqlParameter("@codigoAlumno", codigoAlumno));

                    using(var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            alumno = new Alumno()
                            {
                                Id = (int)reader["Id"],
                                Codigo = (string)reader["Codigo"],
                                Nombre = (string)reader["Nombre"],
                                Ciclo = (int)reader["Ciclo"],
                                Curso = (int)reader["Curso"],
                                Version = (int)reader["Version"]
                            };

                            alumno.Notas = ObtenerNotaPorAlumno(alumno.Id);
                        }
                    }
                }
            }

            return alumno;
        }

        public List<Calificacion> ObtenerNotaPorAlumno(int IdAlumno)
        {
            List<Calificacion> calificaciones = new List<Calificacion>();

            using(var conn = new SqlConnection(connectString))
            {
                conn.Open();

                using(var command = new SqlCommand("Select Id, IdAlumno, IdTipoEvaluacion, Nota From Calificacion Where IdAlumno = @IdAlumno", conn))
                {

                    command.Parameters.Add(new SqlParameter("@IdAlumno",IdAlumno));

                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Calificacion calificacion = new Calificacion()
                            {
                                Id = (int)reader["Id"],
                                IdAlumno = (int)reader["IdAlumno"],
                                IdTipoEvaluacion = (int)reader["IdTipoEvaluacion"],
                                Nota = (reader["Nota"] == DBNull.Value) ? 0 : (decimal)reader["Nota"]
                            };

                            calificaciones.Add(calificacion);
                        }
                    }
                }

                return calificaciones;
            }
        }

        public int RegistrarAlumno(Alumno alumno)
        {
            int idAlumno = 0;

            try
            {
                //Declaramos la transaccion
                using(TransactionScope scope = new TransactionScope())
                {
                    //Establecemos la conexion
                    using(var conn = new SqlConnection(connectString))
                    {
                        conn.Open();

                        string insertAlumno = "Insert Into Alumno (Codigo, Nombre, Ciclo, Curso) " +
                            "output INSERTED.ID " +
                            "Values (@Codigo, @Nombre, @Ciclo, @Curso)";

                        using(var commandAlumno = new SqlCommand(insertAlumno, conn))
                        {
                            commandAlumno.Parameters.Add(new SqlParameter("@Codigo", alumno.Codigo));
                            commandAlumno.Parameters.Add(new SqlParameter("@Nombre", alumno.Nombre));
                            commandAlumno.Parameters.Add(new SqlParameter("Ciclo", alumno.Ciclo));
                            commandAlumno.Parameters.Add(new SqlParameter("@Curso", alumno.Curso));

                            var valorRetornadoAlumno = commandAlumno.ExecuteScalar();

                            if (valorRetornadoAlumno != null)
                            {
                                int.TryParse(valorRetornadoAlumno.ToString(), out idAlumno);
                            }

                            if (idAlumno > 0)
                            {
                                bool isSuccess = true;

                                string insertCalificaciones = "Insert Into Calificacion (IdAlumno, IdTipoEvaluacion, Nota) " +
                                    "output INSERTED.ID " +
                                    "Values (@IdAlumno,@IdTipoEvaluacion, @Nota)";

                                foreach (var nota in alumno.Notas)
                                {
                                    using(var commandCalificaciones = new SqlCommand(insertCalificaciones, conn))
                                    {
                                        commandCalificaciones.Parameters.Add(new SqlParameter("@IdAlumno", idAlumno));
                                        commandCalificaciones.Parameters.Add(new SqlParameter("@IdTipoEvaluacion", nota.IdTipoEvaluacion));
                                        commandCalificaciones.Parameters.Add(new SqlParameter("@Nota", nota.Nota));

                                        int idNota = 0;
                                        var valorRetornadoNota = commandCalificaciones.ExecuteScalar();

                                        if (valorRetornadoNota != null)
                                        {
                                            int.TryParse(valorRetornadoNota.ToString(), out idNota);
                                        }

                                        if (idNota == 0)
                                        {
                                            isSuccess = false;
                                            break;
                                        }
                                    }
                                }

                                if (isSuccess)
                                {
                                    scope.Complete();
                                }
                            }
                            else
                            {
                                scope.Dispose();
                            }
                        }
                    }
                }
                return idAlumno;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
