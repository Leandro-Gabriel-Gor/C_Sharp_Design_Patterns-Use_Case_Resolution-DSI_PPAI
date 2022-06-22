namespace PPAI_DSI
{
    partial class PantallaReservaTurno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaReservaTurno));
            this.cmbTipoRT = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvRT = new System.Windows.Forms.DataGridView();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centroInvestigacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionRecurso = new System.Windows.Forms.Button();
            this.dgvFechas = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelecFecha = new System.Windows.Forms.Button();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.diaSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Turno = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoRT
            // 
            this.cmbTipoRT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRT.FormattingEnabled = true;
            this.cmbTipoRT.Location = new System.Drawing.Point(37, 63);
            this.cmbTipoRT.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoRT.Name = "cmbTipoRT";
            this.cmbTipoRT.Size = new System.Drawing.Size(193, 24);
            this.cmbTipoRT.TabIndex = 0;
            this.cmbTipoRT.SelectedIndexChanged += new System.EventHandler(this.cmbTipoRT_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(239, 63);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 28);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.tomarSeleccionTipoRT);
            // 
            // dgvRT
            // 
            this.dgvRT.AllowUserToAddRows = false;
            this.dgvRT.AllowUserToDeleteRows = false;
            this.dgvRT.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dgvRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estado,
            this.centroInvestigacion,
            this.modelo,
            this.marca});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRT.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRT.Location = new System.Drawing.Point(37, 98);
            this.dgvRT.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRT.Name = "dgvRT";
            this.dgvRT.ReadOnly = true;
            this.dgvRT.RowHeadersWidth = 51;
            this.dgvRT.Size = new System.Drawing.Size(625, 251);
            this.dgvRT.TabIndex = 2;
            this.dgvRT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRT_CellClick);
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 125;
            // 
            // centroInvestigacion
            // 
            this.centroInvestigacion.HeaderText = "Centro de Investigacion";
            this.centroInvestigacion.MinimumWidth = 6;
            this.centroInvestigacion.Name = "centroInvestigacion";
            this.centroInvestigacion.ReadOnly = true;
            this.centroInvestigacion.Width = 125;
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.MinimumWidth = 6;
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            this.modelo.Width = 125;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.MinimumWidth = 6;
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Width = 125;
            // 
            // btnSeleccionRecurso
            // 
            this.btnSeleccionRecurso.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionRecurso.Location = new System.Drawing.Point(372, 358);
            this.btnSeleccionRecurso.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeleccionRecurso.Name = "btnSeleccionRecurso";
            this.btnSeleccionRecurso.Size = new System.Drawing.Size(289, 43);
            this.btnSeleccionRecurso.TabIndex = 3;
            this.btnSeleccionRecurso.Text = "Seleccionar Recurso Tecnologico";
            this.btnSeleccionRecurso.UseVisualStyleBackColor = true;
            this.btnSeleccionRecurso.Click += new System.EventHandler(this.tomarSeleccionRT);
            // 
            // dgvFechas
            // 
            this.dgvFechas.AllowUserToAddRows = false;
            this.dgvFechas.AllowUserToDeleteRows = false;
            this.dgvFechas.AllowUserToResizeColumns = false;
            this.dgvFechas.AllowUserToResizeRows = false;
            this.dgvFechas.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dgvFechas.ColumnHeadersHeight = 30;
            this.dgvFechas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFechas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFechas.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvFechas.Location = new System.Drawing.Point(699, 98);
            this.dgvFechas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFechas.Name = "dgvFechas";
            this.dgvFechas.ReadOnly = true;
            this.dgvFechas.RowHeadersWidth = 51;
            this.dgvFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFechas.Size = new System.Drawing.Size(165, 251);
            this.dgvFechas.TabIndex = 4;
            this.dgvFechas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFechas_CellClick);
            // 
            // fecha
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 110;
            // 
            // btnSelecFecha
            // 
            this.btnSelecFecha.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecFecha.Location = new System.Drawing.Point(699, 359);
            this.btnSelecFecha.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecFecha.Name = "btnSelecFecha";
            this.btnSelecFecha.Size = new System.Drawing.Size(165, 43);
            this.btnSelecFecha.TabIndex = 5;
            this.btnSelecFecha.Text = "Seleccionar Fecha";
            this.btnSelecFecha.UseVisualStyleBackColor = true;
            this.btnSelecFecha.Click += new System.EventHandler(this.tomarSeleccionFecha);
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diaSemana,
            this.fechaHoraInicio,
            this.fechaHoraFin,
            this.estadoTurno});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurnos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTurnos.Location = new System.Drawing.Point(37, 417);
            this.dgvTurnos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.RowHeadersWidth = 51;
            this.dgvTurnos.Size = new System.Drawing.Size(845, 284);
            this.dgvTurnos.TabIndex = 6;
            this.dgvTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnos_CellClick);
            // 
            // diaSemana
            // 
            this.diaSemana.HeaderText = "Dia";
            this.diaSemana.MinimumWidth = 6;
            this.diaSemana.Name = "diaSemana";
            this.diaSemana.ReadOnly = true;
            this.diaSemana.Width = 125;
            // 
            // fechaHoraInicio
            // 
            this.fechaHoraInicio.HeaderText = "Hora Inicio";
            this.fechaHoraInicio.MinimumWidth = 6;
            this.fechaHoraInicio.Name = "fechaHoraInicio";
            this.fechaHoraInicio.ReadOnly = true;
            this.fechaHoraInicio.Width = 125;
            // 
            // fechaHoraFin
            // 
            this.fechaHoraFin.HeaderText = "Hora Fin";
            this.fechaHoraFin.MinimumWidth = 6;
            this.fechaHoraFin.Name = "fechaHoraFin";
            this.fechaHoraFin.ReadOnly = true;
            this.fechaHoraFin.Width = 125;
            // 
            // estadoTurno
            // 
            this.estadoTurno.HeaderText = "Estado";
            this.estadoTurno.MinimumWidth = 6;
            this.estadoTurno.Name = "estadoTurno";
            this.estadoTurno.ReadOnly = true;
            this.estadoTurno.Width = 125;
            // 
            // btn_Turno
            // 
            this.btn_Turno.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Turno.Location = new System.Drawing.Point(627, 710);
            this.btn_Turno.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Turno.Name = "btn_Turno";
            this.btn_Turno.Size = new System.Drawing.Size(254, 45);
            this.btn_Turno.TabIndex = 7;
            this.btn_Turno.Text = "Seleccionar Turno";
            this.btn_Turno.UseVisualStyleBackColor = true;
            this.btn_Turno.Click += new System.EventHandler(this.tomarSeleccionDeTurno);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(37, 707);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 47);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(401, 725);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 20);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Mail";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(454, 725);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(94, 20);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "WhatsApp";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 725);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Opciones de Notificacion: ";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Image = global::PPAI_DSI.Properties.Resources.Diseño_sin_título__1_;
            this.btnCerrar.Location = new System.Drawing.Point(888, 11);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(46, 44);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(37, 359);
            this.btnLimpiarCampos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(134, 47);
            this.btnLimpiarCampos.TabIndex = 13;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Yu Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(32, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(714, 29);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "Registrar reserva de turno para utilización de recurso tecnológico";
            // 
            // PantallaReservaTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::PPAI_DSI.Properties.Resources.pngwing_com__4_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(946, 770);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btn_Turno);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.btnSelecFecha);
            this.Controls.Add(this.dgvFechas);
            this.Controls.Add(this.btnSeleccionRecurso);
            this.Controls.Add(this.dgvRT);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbTipoRT);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PantallaReservaTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaReservaTurno";
            this.Load += new System.EventHandler(this.PantallaReservaTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoRT;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn centroInvestigacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.Button btnSeleccionRecurso;
        private System.Windows.Forms.DataGridView dgvFechas;
        private System.Windows.Forms.Button btnSelecFecha;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoTurno;
        private System.Windows.Forms.Button btn_Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Label lblTitulo;
    }
}