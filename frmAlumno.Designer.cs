
namespace Escuela
{
    partial class frmAlumno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCiclo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cboCiclo = new System.Windows.Forms.ComboBox();
            this.cboCurso = new System.Windows.Forms.ComboBox();
            this.gbEvaluacion = new System.Windows.Forms.GroupBox();
            this.txtEC2 = new System.Windows.Forms.TextBox();
            this.txtEC1 = new System.Windows.Forms.TextBox();
            this.txtEC3 = new System.Windows.Forms.TextBox();
            this.lblEC3 = new System.Windows.Forms.Label();
            this.lblEC2 = new System.Windows.Forms.Label();
            this.lblEC1 = new System.Windows.Forms.Label();
            this.gbExamenes = new System.Windows.Forms.GroupBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.txtParcial = new System.Windows.Forms.TextBox();
            this.lblFinal = new System.Windows.Forms.Label();
            this.lblParcial = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblRowVersion = new System.Windows.Forms.Label();
            this.gbEvaluacion.SuspendLayout();
            this.gbExamenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(49, 29);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // lblCiclo
            // 
            this.lblCiclo.AutoSize = true;
            this.lblCiclo.Location = new System.Drawing.Point(49, 80);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(30, 13);
            this.lblCiclo.TabIndex = 1;
            this.lblCiclo.Text = "Ciclo";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(289, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(289, 80);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(34, 13);
            this.lblCurso.TabIndex = 3;
            this.lblCurso.Text = "Curso";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(95, 21);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(169, 20);
            this.txtCodigo.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(339, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(207, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // cboCiclo
            // 
            this.cboCiclo.FormattingEnabled = true;
            this.cboCiclo.Location = new System.Drawing.Point(95, 72);
            this.cboCiclo.Name = "cboCiclo";
            this.cboCiclo.Size = new System.Drawing.Size(169, 21);
            this.cboCiclo.TabIndex = 6;
            // 
            // cboCurso
            // 
            this.cboCurso.FormattingEnabled = true;
            this.cboCurso.Location = new System.Drawing.Point(339, 72);
            this.cboCurso.Name = "cboCurso";
            this.cboCurso.Size = new System.Drawing.Size(207, 21);
            this.cboCurso.TabIndex = 7;
            // 
            // gbEvaluacion
            // 
            this.gbEvaluacion.Controls.Add(this.txtEC2);
            this.gbEvaluacion.Controls.Add(this.txtEC1);
            this.gbEvaluacion.Controls.Add(this.txtEC3);
            this.gbEvaluacion.Controls.Add(this.lblEC3);
            this.gbEvaluacion.Controls.Add(this.lblEC2);
            this.gbEvaluacion.Controls.Add(this.lblEC1);
            this.gbEvaluacion.Location = new System.Drawing.Point(63, 125);
            this.gbEvaluacion.Name = "gbEvaluacion";
            this.gbEvaluacion.Size = new System.Drawing.Size(212, 154);
            this.gbEvaluacion.TabIndex = 8;
            this.gbEvaluacion.TabStop = false;
            this.gbEvaluacion.Text = "Evaluación Continua";
            // 
            // txtEC2
            // 
            this.txtEC2.Location = new System.Drawing.Point(55, 69);
            this.txtEC2.Name = "txtEC2";
            this.txtEC2.Size = new System.Drawing.Size(133, 20);
            this.txtEC2.TabIndex = 5;
            // 
            // txtEC1
            // 
            this.txtEC1.Location = new System.Drawing.Point(55, 28);
            this.txtEC1.Name = "txtEC1";
            this.txtEC1.Size = new System.Drawing.Size(133, 20);
            this.txtEC1.TabIndex = 4;
            // 
            // txtEC3
            // 
            this.txtEC3.Location = new System.Drawing.Point(55, 112);
            this.txtEC3.Name = "txtEC3";
            this.txtEC3.Size = new System.Drawing.Size(133, 20);
            this.txtEC3.TabIndex = 3;
            // 
            // lblEC3
            // 
            this.lblEC3.AutoSize = true;
            this.lblEC3.Location = new System.Drawing.Point(16, 119);
            this.lblEC3.Name = "lblEC3";
            this.lblEC3.Size = new System.Drawing.Size(33, 13);
            this.lblEC3.TabIndex = 2;
            this.lblEC3.Text = "EC_3";
            // 
            // lblEC2
            // 
            this.lblEC2.AutoSize = true;
            this.lblEC2.Location = new System.Drawing.Point(16, 76);
            this.lblEC2.Name = "lblEC2";
            this.lblEC2.Size = new System.Drawing.Size(33, 13);
            this.lblEC2.TabIndex = 1;
            this.lblEC2.Text = "EC_2";
            // 
            // lblEC1
            // 
            this.lblEC1.AutoSize = true;
            this.lblEC1.Location = new System.Drawing.Point(16, 35);
            this.lblEC1.Name = "lblEC1";
            this.lblEC1.Size = new System.Drawing.Size(33, 13);
            this.lblEC1.TabIndex = 0;
            this.lblEC1.Text = "EC_1";
            // 
            // gbExamenes
            // 
            this.gbExamenes.Controls.Add(this.txtFinal);
            this.gbExamenes.Controls.Add(this.txtParcial);
            this.gbExamenes.Controls.Add(this.lblFinal);
            this.gbExamenes.Controls.Add(this.lblParcial);
            this.gbExamenes.Location = new System.Drawing.Point(339, 125);
            this.gbExamenes.Name = "gbExamenes";
            this.gbExamenes.Size = new System.Drawing.Size(111, 154);
            this.gbExamenes.TabIndex = 6;
            this.gbExamenes.TabStop = false;
            this.gbExamenes.Text = "Examenes";
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(5, 92);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 3;
            // 
            // txtParcial
            // 
            this.txtParcial.Location = new System.Drawing.Point(6, 44);
            this.txtParcial.Name = "txtParcial";
            this.txtParcial.Size = new System.Drawing.Size(100, 20);
            this.txtParcial.TabIndex = 2;
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(6, 76);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(29, 13);
            this.lblFinal.TabIndex = 1;
            this.lblFinal.Text = "Final";
            // 
            // lblParcial
            // 
            this.lblParcial.AutoSize = true;
            this.lblParcial.Location = new System.Drawing.Point(6, 28);
            this.lblParcial.Name = "lblParcial";
            this.lblParcial.Size = new System.Drawing.Size(39, 13);
            this.lblParcial.TabIndex = 0;
            this.lblParcial.Text = "Parcial";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(471, 166);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(471, 201);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(471, 233);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Location = new System.Drawing.Point(52, 315);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.Size = new System.Drawing.Size(494, 123);
            this.dgvAlumnos.TabIndex = 9;
            this.dgvAlumnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnos_CellContentClick);
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Location = new System.Drawing.Point(289, 290);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(51, 13);
            this.lblPromedio.TabIndex = 10;
            this.lblPromedio.Text = "Promedio";
            // 
            // txtPromedio
            // 
            this.txtPromedio.Location = new System.Drawing.Point(345, 285);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.Size = new System.Drawing.Size(52, 20);
            this.txtPromedio.TabIndex = 11;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(415, 290);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(47, 13);
            this.lblMensaje.TabIndex = 12;
            this.lblMensaje.Text = "Mensaje";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(54, 292);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 13);
            this.lblId.TabIndex = 13;
            this.lblId.Text = "label1";
            this.lblId.Visible = false;
            // 
            // lblRowVersion
            // 
            this.lblRowVersion.AutoSize = true;
            this.lblRowVersion.Location = new System.Drawing.Point(158, 292);
            this.lblRowVersion.Name = "lblRowVersion";
            this.lblRowVersion.Size = new System.Drawing.Size(35, 13);
            this.lblRowVersion.TabIndex = 14;
            this.lblRowVersion.Text = "label2";
            this.lblRowVersion.Visible = false;
            // 
            // frmAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 450);
            this.Controls.Add(this.lblRowVersion);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.txtPromedio);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.dgvAlumnos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbExamenes);
            this.Controls.Add(this.gbEvaluacion);
            this.Controls.Add(this.cboCurso);
            this.Controls.Add(this.cboCiclo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCiclo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmAlumno";
            this.Text = "frmAlumno";
            this.gbEvaluacion.ResumeLayout(false);
            this.gbEvaluacion.PerformLayout();
            this.gbExamenes.ResumeLayout(false);
            this.gbExamenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCiclo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cboCiclo;
        private System.Windows.Forms.ComboBox cboCurso;
        private System.Windows.Forms.GroupBox gbEvaluacion;
        private System.Windows.Forms.TextBox txtEC2;
        private System.Windows.Forms.TextBox txtEC1;
        private System.Windows.Forms.TextBox txtEC3;
        private System.Windows.Forms.Label lblEC3;
        private System.Windows.Forms.Label lblEC2;
        private System.Windows.Forms.Label lblEC1;
        private System.Windows.Forms.GroupBox gbExamenes;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.TextBox txtParcial;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Label lblParcial;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.TextBox txtPromedio;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblRowVersion;
    }
}