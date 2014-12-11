namespace PuntoDeVenta
{
    partial class NuevoUsuario
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
            this.GboxPermisos = new System.Windows.Forms.GroupBox();
            this.Digitador = new System.Windows.Forms.RadioButton();
            this.cajero = new System.Windows.Forms.RadioButton();
            this.Administrador = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rectangleShape5 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.GboxPermisos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GboxPermisos
            // 
            this.GboxPermisos.BackColor = System.Drawing.Color.Transparent;
            this.GboxPermisos.Controls.Add(this.Digitador);
            this.GboxPermisos.Controls.Add(this.cajero);
            this.GboxPermisos.Controls.Add(this.Administrador);
            this.GboxPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GboxPermisos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.GboxPermisos.Location = new System.Drawing.Point(102, 261);
            this.GboxPermisos.Name = "GboxPermisos";
            this.GboxPermisos.Size = new System.Drawing.Size(501, 143);
            this.GboxPermisos.TabIndex = 69;
            this.GboxPermisos.TabStop = false;
            this.GboxPermisos.Text = "Permisos";
            // 
            // Digitador
            // 
            this.Digitador.AutoSize = true;
            this.Digitador.Location = new System.Drawing.Point(13, 64);
            this.Digitador.Name = "Digitador";
            this.Digitador.Size = new System.Drawing.Size(84, 19);
            this.Digitador.TabIndex = 5;
            this.Digitador.TabStop = true;
            this.Digitador.Text = "Digitador";
            this.Digitador.UseVisualStyleBackColor = true;
            // 
            // cajero
            // 
            this.cajero.AutoSize = true;
            this.cajero.Location = new System.Drawing.Point(13, 87);
            this.cajero.Name = "cajero";
            this.cajero.Size = new System.Drawing.Size(67, 19);
            this.cajero.TabIndex = 4;
            this.cajero.TabStop = true;
            this.cajero.Text = "Cajero";
            this.cajero.UseVisualStyleBackColor = true;
            // 
            // Administrador
            // 
            this.Administrador.AutoSize = true;
            this.Administrador.Checked = true;
            this.Administrador.Location = new System.Drawing.Point(13, 38);
            this.Administrador.Name = "Administrador";
            this.Administrador.Size = new System.Drawing.Size(114, 19);
            this.Administrador.TabIndex = 3;
            this.Administrador.TabStop = true;
            this.Administrador.Text = "Administrador";
            this.Administrador.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(362, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 25);
            this.label10.TabIndex = 55;
            this.label10.Text = "* ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(47, 107);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 68;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(130, 30);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(159, 20);
            this.txtUsuario.TabIndex = 56;
            // 
            // Guardar
            // 
            this.Guardar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Guardar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Guardar.Location = new System.Drawing.Point(175, 440);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(123, 51);
            this.Guardar.TabIndex = 65;
            this.Guardar.Text = "Guardar ";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(130, 88);
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.PasswordChar = '•';
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(226, 20);
            this.txtConfirmarContraseña.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(362, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "* ";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(130, 58);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '•';
            this.txtContraseña.Size = new System.Drawing.Size(226, 20);
            this.txtContraseña.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Contraseña";
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.ForeColor = System.Drawing.Color.Red;
            this.Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancelar.Location = new System.Drawing.Point(355, 440);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(135, 51);
            this.Cancelar.TabIndex = 66;
            this.Cancelar.Text = "&Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtConfirmarContraseña);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(102, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 128);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Confirmar Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(286, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 40;
            this.label1.Text = "* ";
            // 
            // rectangleShape5
            // 
            this.rectangleShape5.BackgroundImage = global::PuntoDeVenta.Properties.Resources.network_add;
            this.rectangleShape5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rectangleShape5.BorderColor = System.Drawing.Color.Transparent;
            this.rectangleShape5.Location = new System.Drawing.Point(27, 23);
            this.rectangleShape5.Name = "rectangleShape5";
            this.rectangleShape5.Size = new System.Drawing.Size(104, 101);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape5});
            this.shapeContainer1.Size = new System.Drawing.Size(684, 512);
            this.shapeContainer1.TabIndex = 70;
            this.shapeContainer1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(146, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 31);
            this.label7.TabIndex = 81;
            this.label7.Text = "Registrar Usuarios";
            // 
            // NuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::PuntoDeVenta.Properties.Resources.backgroundd1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 512);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GboxPermisos);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "NuevoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registar Un Nuevo Usuario";
            this.GboxPermisos.ResumeLayout(false);
            this.GboxPermisos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GboxPermisos;
        private System.Windows.Forms.RadioButton Digitador;
        private System.Windows.Forms.RadioButton cajero;
        private System.Windows.Forms.RadioButton Administrador;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape5;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label7;
    }
}