namespace ProyectoDiscos
{
    partial class frmAltaDisco
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaLanzamiento = new System.Windows.Forms.Label();
            this.lblCantidadCanciones = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtCantidadCanciones = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(96, 80);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(36, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblFechaLanzamiento
            // 
            this.lblFechaLanzamiento.AutoSize = true;
            this.lblFechaLanzamiento.Location = new System.Drawing.Point(12, 137);
            this.lblFechaLanzamiento.Name = "lblFechaLanzamiento";
            this.lblFechaLanzamiento.Size = new System.Drawing.Size(120, 13);
            this.lblFechaLanzamiento.TabIndex = 1;
            this.lblFechaLanzamiento.Text = "Fecha De Lanzamiento:";
            // 
            // lblCantidadCanciones
            // 
            this.lblCantidadCanciones.AutoSize = true;
            this.lblCantidadCanciones.Location = new System.Drawing.Point(12, 193);
            this.lblCantidadCanciones.Name = "lblCantidadCanciones";
            this.lblCantidadCanciones.Size = new System.Drawing.Size(120, 13);
            this.lblCantidadCanciones.TabIndex = 2;
            this.lblCantidadCanciones.Text = "Cantidad de Canciones:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(148, 77);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 20);
            this.txtTitulo.TabIndex = 3;
            // 
            // txtCantidadCanciones
            // 
            this.txtCantidadCanciones.Location = new System.Drawing.Point(148, 190);
            this.txtCantidadCanciones.Name = "txtCantidadCanciones";
            this.txtCantidadCanciones.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadCanciones.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(96, 256);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(209, 256);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(148, 137);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaLanzamiento.TabIndex = 8;
            // 
            // frmAltaDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 339);
            this.Controls.Add(this.dtpFechaLanzamiento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCantidadCanciones);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblCantidadCanciones);
            this.Controls.Add(this.lblFechaLanzamiento);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmAltaDisco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Disco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaLanzamiento;
        private System.Windows.Forms.Label lblCantidadCanciones;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtCantidadCanciones;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dtpFechaLanzamiento;
    }
}