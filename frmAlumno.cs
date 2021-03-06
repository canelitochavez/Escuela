using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Escuela.Interface;
using Escuela.Entities;
using Escuela.Data;

namespace Escuela
{
    public partial class frmAlumno : Form
    {

        ILogic DAC;
        public frmAlumno()
        {
            InitializeComponent();

            DAC = new DAC_Alumno();
            InicializarFormulario();
            CargarAlumnos();
        }

        public void InicializarFormulario()
        {
            List<Ciclo> ciclos = GenericData.ListarCiclos();

            //Load Ciclos
            cboCiclo.DataSource = ciclos;
            cboCiclo.DisplayMember = "Descripcion";
            cboCiclo.ValueMember = "Id";

            List<Curso> cursos = GenericData.ListarCursos();

            //Load Cursos
            cboCurso.DataSource = cursos;
            cboCurso.DisplayMember = "Descripcion";
            cboCurso.ValueMember = "Id";

            lblId.Text = "0";
        }

        public void CargarAlumnos()
        {
            List<Alumno> alumnos = DAC.ListarAlumnos();
            List<Calificacion> calificaciones = DAC.ListarNotas();

            alumnos.ForEach(x => x.Notas = calificaciones.Where(c => c.IdAlumno == x.Id).ToList());
            alumnos.ForEach(x => x.DescripcionCurso = GenericData.ListarCursos().Where(y => y.Id == x.Id).First().Descripcion);
            alumnos.ForEach(x => x.Promedio = GetPromedio(x.Notas));

            dgvAlumnos.AutoGenerateColumns = false;
            GenerateColumns();
            dgvAlumnos.DataSource = alumnos;
        }

        private decimal GetPromedio(List<Calificacion> notas)
        {
            List<Evaluacion> evaluaciones = GenericData.ListarEvaluaciones();
            
            decimal promedio = 0;

            foreach (var nota in notas)
            {
                promedio += (nota.Nota) * (evaluaciones.Where(x => x.Id == nota.IdTipoEvaluacion).SingleOrDefault().Peso);
            }

            return decimal.Round(promedio, 2);
        }

        private void GenerateColumns()
        {
            dgvAlumnos.DataSource = null;
            dgvAlumnos.Columns.Clear();

            DataGridViewTextBoxColumn codigo = new DataGridViewTextBoxColumn();
            codigo.DataPropertyName = "Codigo";
            codigo.HeaderText = "Código";
            codigo.Name = "Codigo";
            dgvAlumnos.Columns.Add(codigo);

            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.DataPropertyName = "Nombre";
            nombre.HeaderText = "Nombre";
            nombre.Name = "Nombre";
            dgvAlumnos.Columns.Add(nombre);

            DataGridViewTextBoxColumn ciclo = new DataGridViewTextBoxColumn();
            ciclo.DataPropertyName = "Ciclo";
            ciclo.HeaderText = "Ciclo";
            ciclo.Name = "Ciclo";
            dgvAlumnos.Columns.Add(ciclo);

            DataGridViewTextBoxColumn descripcionCurso = new DataGridViewTextBoxColumn();
            descripcionCurso.DataPropertyName = "DescripcionCurso";
            descripcionCurso.HeaderText = "Curso";
            descripcionCurso.Name = "DescripcionCurso";
            dgvAlumnos.Columns.Add(descripcionCurso);

            DataGridViewTextBoxColumn promedio = new DataGridViewTextBoxColumn();
            promedio.DataPropertyName = "Promedio";
            promedio.HeaderText = "Promedio";
            promedio.Name = "Promedio";
            dgvAlumnos.Columns.Add(promedio);
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dgvAlumnos.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string codAlumno = dgvAlumnos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
            CargarDatosAlumno(codAlumno);

        }

        private void CargarDatosAlumno(string codAlumno)
        {
            Alumno alumno = DAC.ObtenerAlumno(codAlumno);

            if (alumno.Id > 0)
            {
                lblId.Text = alumno.Id.ToString();
                txtCodigo.Text = alumno.Codigo;
                txtNombre.Text = alumno.Nombre;
                cboCiclo.SelectedValue = alumno.Ciclo;
                cboCurso.SelectedValue = alumno.Curso;
                lblRowVersion.Text = alumno.Version.ToString();
                txtEC1.Text = alumno.Notas.Where(x => x.IdTipoEvaluacion == 1).FirstOrDefault().Nota.ToString();
                txtEC2.Text = alumno.Notas.Where(x => x.IdTipoEvaluacion == 2).FirstOrDefault().Nota.ToString();
                txtEC3.Text = alumno.Notas.Where(x => x.IdTipoEvaluacion == 3).FirstOrDefault().Nota.ToString();
                txtParcial.Text = alumno.Notas.Where(x => x.IdTipoEvaluacion == 4).FirstOrDefault().Nota.ToString();
                txtFinal.Text = alumno.Notas.Where(x => x.IdTipoEvaluacion == 5).FirstOrDefault().Nota.ToString();

                txtPromedio.Text = GetPromedio(alumno.Notas).ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            lblId.Text = "0";

            foreach(Control control in this.Controls)
            {
                if (control.HasChildren)
                {
                    ClearRecursive(control);
                }
                else
                {
                    ClearControl(control);
                }
            }

        }

        private void ClearControl(Control control)
        {
            switch (control.GetType().ToString().Replace("System.Windows.Forms.", ""))
            {
                case "TextBox":
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                    break;
                case "ComboBox":
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                    break;
            }
        }


        private void ClearRecursive(Control control)
        {
            foreach(Control subcontrol in control.Controls)
            {
                if (subcontrol.HasChildren)
                {
                    ClearRecursive(subcontrol);
                }
                else
                {
                    ClearControl(subcontrol);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Alumno alumno = GetDatosAlumno();

            if (alumno.Id > 0)
            {
                alumno.Version = Convert.ToInt32(lblRowVersion.Text);

                bool isSuccess = DAC.ActualizarAlumno(alumno);

                if (isSuccess)
                {
                    MostrarMensaje("Se actualizó correctamente al alumno " + alumno.Nombre + ".");
                    LimpiarFormulario();
                    CargarAlumnos();
                }
                else
                {
                    string mensaje = "No se pudo actualizar los datos del alumno. " +
                                        "¿Desea actualizar la lista de alumnos?";

                    if (MostrarDialogo(mensaje))
                    {
                        LimpiarFormulario();
                        CargarAlumnos();
                    }
                }
            }
            else
            {
                try
                {
                    int New_IdAlumno = DAC.RegistrarAlumno(alumno);

                    if (New_IdAlumno > 0)
                    {
                        MostrarMensaje("Se registró correctamente al alumno " + alumno.Nombre + " con Id " + New_IdAlumno.ToString() + " y sus calificaciones.");
                        LimpiarFormulario();
                        CargarAlumnos();
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Ocurrió un error al realizar la operación : " + ex.ToString());
                }
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Escuela");
        }

        private bool MostrarDialogo(string mensaje)
        {
            DialogResult dialogResult = MessageBox.Show(mensaje, "Escuela", MessageBoxButtons.YesNo);

            if (dialogResult.Equals(DialogResult.Yes))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Alumno GetDatosAlumno()
        {
            Alumno alumno = new Alumno();

            alumno.Id = int.Parse(lblId.Text);
            string codigo = txtCodigo.Text;
            alumno.Codigo = string.IsNullOrEmpty(codigo) ? string.Empty : codigo.Trim();
            string nombre = txtNombre.Text;
            alumno.Nombre = string.IsNullOrEmpty(nombre) ? string.Empty : nombre.Trim();
            alumno.Ciclo = int.Parse(cboCiclo.SelectedValue.ToString());
            alumno.Curso = int.Parse(cboCurso.SelectedValue.ToString());

            decimal ec_1 = 0, ec_2 = 0, ec_3 = 0, parcial = 0, final = 0;

            //Obtener notas y validar que sean correctas
            decimal.TryParse(txtEC1.Text, out ec_1);
            decimal.TryParse(txtEC2.Text, out ec_2);
            decimal.TryParse(txtEC3.Text, out ec_3);
            decimal.TryParse(txtParcial.Text, out parcial);
            decimal.TryParse(txtFinal.Text, out final);

            List<Calificacion> notas = new List<Calificacion>();

            notas.Add(new Calificacion { IdTipoEvaluacion = 1, Nota = ec_1});
            notas.Add(new Calificacion { IdTipoEvaluacion = 2, Nota = ec_2});
            notas.Add(new Calificacion { IdTipoEvaluacion = 3, Nota = ec_3 });
            notas.Add(new Calificacion { IdTipoEvaluacion = 4, Nota = parcial});
            notas.Add(new Calificacion { IdTipoEvaluacion = 5, Nota = final});

            alumno.Notas = notas;

            return alumno;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MostrarDialogo("¿Estas seguró de eliminar al alumno?"))
                {
                    int idAlumno = int.Parse(lblId.Text);

                    if (idAlumno > 0)
                    {
                        int version = Convert.ToInt32(lblRowVersion.Text);
                        bool success = DAC.EliminarAlumno(idAlumno, version);

                        if (success)
                        {
                            MostrarMensaje("Se eliminó correctamente los datos del alumno.");
                            LimpiarFormulario();
                            CargarAlumnos();
                        }
                        else
                        {
                            string mensaje = "No se pudo eliminar los datos del alumno. " +
                                                   "¿Desea actualizar la lista de alumnos?";

                            if (MostrarDialogo(mensaje))
                            {
                                LimpiarFormulario();
                                CargarAlumnos();
                            }
                        }
                    }
                    else
                    {
                        MostrarMensaje("Debe seleccionar un alumno a eliminar.");
                    }
                }
            }
            catch (Exception ex)
            {

                MostrarMensaje("Ocurrió un error : " + ex.Message);
            }
        }
    }
}
