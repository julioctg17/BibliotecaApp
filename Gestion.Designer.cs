namespace BibliotecaApp
{
    partial class Gestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestion));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstLibros = new System.Windows.Forms.ListBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnOrdenarTitulo = new System.Windows.Forms.Button();
            this.btnOrdenarAnio = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.btnPrestamo = new System.Windows.Forms.Button();
            this.btnPrestamosActuales = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPrestamos = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.lstLibros);
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnMostrar);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.btnOrdenarTitulo);
            this.groupBox2.Controls.Add(this.btnOrdenarAnio);
            this.groupBox2.Location = new System.Drawing.Point(29, 87);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(737, 396);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestionar Libros";
            // 
            // lstLibros
            // 
            this.lstLibros.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lstLibros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lstLibros.FormattingEnabled = true;
            this.lstLibros.HorizontalScrollbar = true;
            this.lstLibros.ItemHeight = 20;
            this.lstLibros.Location = new System.Drawing.Point(15, 150);
            this.lstLibros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstLibros.Name = "lstLibros";
            this.lstLibros.Size = new System.Drawing.Size(703, 204);
            this.lstLibros.TabIndex = 13;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.txtBuscar.Location = new System.Drawing.Point(143, 30);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(480, 22);
            this.txtBuscar.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 29);
            this.label5.TabIndex = 18;
            this.label5.Text = "Buscar:";
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(115)))));
            this.btnMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnMostrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMostrar.Location = new System.Drawing.Point(385, 76);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(141, 57);
            this.btnMostrar.TabIndex = 6;
            this.btnMostrar.Text = "Mostrar todos";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(115)))));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscar.Location = new System.Drawing.Point(195, 76);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(148, 57);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar libro";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnOrdenarTitulo
            // 
            this.btnOrdenarTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(115)))));
            this.btnOrdenarTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOrdenarTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrdenarTitulo.Location = new System.Drawing.Point(15, 76);
            this.btnOrdenarTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenarTitulo.Name = "btnOrdenarTitulo";
            this.btnOrdenarTitulo.Size = new System.Drawing.Size(141, 57);
            this.btnOrdenarTitulo.TabIndex = 8;
            this.btnOrdenarTitulo.Text = "Ordenar por título";
            this.btnOrdenarTitulo.UseVisualStyleBackColor = false;
            this.btnOrdenarTitulo.Click += new System.EventHandler(this.btnOrdenarTitulo_Click);
            // 
            // btnOrdenarAnio
            // 
            this.btnOrdenarAnio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(115)))));
            this.btnOrdenarAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOrdenarAnio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrdenarAnio.Location = new System.Drawing.Point(577, 76);
            this.btnOrdenarAnio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenarAnio.Name = "btnOrdenarAnio";
            this.btnOrdenarAnio.Size = new System.Drawing.Size(141, 57);
            this.btnOrdenarAnio.TabIndex = 9;
            this.btnOrdenarAnio.Text = "Ordenar por año";
            this.btnOrdenarAnio.UseVisualStyleBackColor = false;
            this.btnOrdenarAnio.Click += new System.EventHandler(this.btnOrdenarAnio_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRegresar.Font = new System.Drawing.Font("Bauhaus 93", 18F);
            this.btnRegresar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegresar.Location = new System.Drawing.Point(32, 512);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(195, 58);
            this.btnRegresar.TabIndex = 22;
            this.btnRegresar.Text = "< Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Controls.Add(this.comboBoxUsuarios);
            this.groupBox3.Controls.Add(this.btnPrestamo);
            this.groupBox3.Controls.Add(this.btnPrestamosActuales);
            this.groupBox3.Location = new System.Drawing.Point(794, 91);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(240, 396);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Préstamos y devoluciones";
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarios.FormattingEnabled = true;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(23, 72);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(193, 24);
            this.comboBoxUsuarios.TabIndex = 14;
            this.comboBoxUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuarios_SelectedIndexChanged);
            // 
            // btnPrestamo
            // 
            this.btnPrestamo.BackColor = System.Drawing.Color.Tomato;
            this.btnPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrestamo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPrestamo.Location = new System.Drawing.Point(23, 164);
            this.btnPrestamo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrestamo.Name = "btnPrestamo";
            this.btnPrestamo.Size = new System.Drawing.Size(193, 57);
            this.btnPrestamo.TabIndex = 10;
            this.btnPrestamo.Text = "Solicitar préstamo";
            this.btnPrestamo.UseVisualStyleBackColor = false;
            this.btnPrestamo.Click += new System.EventHandler(this.btnPrestamo_Click);
            // 
            // btnPrestamosActuales
            // 
            this.btnPrestamosActuales.BackColor = System.Drawing.Color.SandyBrown;
            this.btnPrestamosActuales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrestamosActuales.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPrestamosActuales.Location = new System.Drawing.Point(23, 269);
            this.btnPrestamosActuales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrestamosActuales.Name = "btnPrestamosActuales";
            this.btnPrestamosActuales.Size = new System.Drawing.Size(193, 57);
            this.btnPrestamosActuales.TabIndex = 13;
            this.btnPrestamosActuales.Text = "Mostrar Prestamos actuales";
            this.btnPrestamosActuales.UseVisualStyleBackColor = false;
            this.btnPrestamosActuales.Click += new System.EventHandler(this.btnPrestamosActuales_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.SandyBrown;
            this.btnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnHistorial.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHistorial.Location = new System.Drawing.Point(32, 293);
            this.btnHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(193, 57);
            this.btnHistorial.TabIndex = 12;
            this.btnHistorial.Text = "Mostrar historial de devoluciones";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.BackColor = System.Drawing.Color.Salmon;
            this.btnDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDevolucion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDevolucion.Location = new System.Drawing.Point(32, 186);
            this.btnDevolucion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(193, 57);
            this.btnDevolucion.TabIndex = 11;
            this.btnDevolucion.Text = "Registrar devolución";
            this.btnDevolucion.UseVisualStyleBackColor = false;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(771, 491);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(473, 108);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(297, 491);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(473, 108);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-176, 491);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(473, 108);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 50);
            this.label1.TabIndex = 31;
            this.label1.Text = "Administración de Libros";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.btnHistorial);
            this.groupBox1.Controls.Add(this.cmbPrestamos);
            this.groupBox1.Controls.Add(this.btnDevolucion);
            this.groupBox1.Location = new System.Drawing.Point(1040, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(250, 396);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Préstamos y devoluciones";
            // 
            // cmbPrestamos
            // 
            this.cmbPrestamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrestamos.FormattingEnabled = true;
            this.cmbPrestamos.Location = new System.Drawing.Point(45, 91);
            this.cmbPrestamos.Name = "cmbPrestamos";
            this.cmbPrestamos.Size = new System.Drawing.Size(159, 24);
            this.cmbPrestamos.TabIndex = 14;
            // 
            // Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(238)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(1297, 598);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Gestion";
            this.Text = "Gestion";
            this.Load += new System.EventHandler(this.Gestion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstLibros;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnOrdenarTitulo;
        private System.Windows.Forms.Button btnOrdenarAnio;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnPrestamo;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrestamosActuales;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPrestamos;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
    }
}