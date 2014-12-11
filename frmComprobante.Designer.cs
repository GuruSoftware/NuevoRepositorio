namespace PuntoDeVenta
{
    partial class frmComprobante
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Serie = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Limite = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.AreaDeImpresion = new System.Windows.Forms.NumericUpDown();
            this.PuntoDeEmicion = new System.Windows.Forms.NumericUpDown();
            this.DivicionDeNegocio = new System.Windows.Forms.NumericUpDown();
            this.Prueba = new System.Windows.Forms.Label();
            this.Probar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Limite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaDeImpresion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PuntoDeEmicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivicionDeNegocio)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serie";
            // 
            // Serie
            // 
            this.Serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Serie.FormattingEnabled = true;
            this.Serie.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.Serie.Location = new System.Drawing.Point(40, 57);
            this.Serie.Name = "Serie";
            this.Serie.Size = new System.Drawing.Size(100, 21);
            this.Serie.TabIndex = 3;
            this.Serie.SelectedIndexChanged += new System.EventHandler(this.Serie_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Punto de emicion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Area de Impresion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cantidad de Comprobante Comprobantes Comprado";
            // 
            // Limite
            // 
            this.Limite.Location = new System.Drawing.Point(40, 266);
            this.Limite.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Limite.Name = "Limite";
            this.Limite.Size = new System.Drawing.Size(249, 20);
            this.Limite.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Divicion de Negocio";
            // 
            // AreaDeImpresion
            // 
            this.AreaDeImpresion.Location = new System.Drawing.Point(40, 175);
            this.AreaDeImpresion.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.AreaDeImpresion.Name = "AreaDeImpresion";
            this.AreaDeImpresion.Size = new System.Drawing.Size(56, 20);
            this.AreaDeImpresion.TabIndex = 14;
            // 
            // PuntoDeEmicion
            // 
            this.PuntoDeEmicion.Location = new System.Drawing.Point(40, 136);
            this.PuntoDeEmicion.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.PuntoDeEmicion.Name = "PuntoDeEmicion";
            this.PuntoDeEmicion.Size = new System.Drawing.Size(56, 20);
            this.PuntoDeEmicion.TabIndex = 15;
            // 
            // DivicionDeNegocio
            // 
            this.DivicionDeNegocio.Location = new System.Drawing.Point(40, 97);
            this.DivicionDeNegocio.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.DivicionDeNegocio.Name = "DivicionDeNegocio";
            this.DivicionDeNegocio.Size = new System.Drawing.Size(56, 20);
            this.DivicionDeNegocio.TabIndex = 16;
            // 
            // Prueba
            // 
            this.Prueba.AutoSize = true;
            this.Prueba.Location = new System.Drawing.Point(331, 65);
            this.Prueba.Name = "Prueba";
            this.Prueba.Size = new System.Drawing.Size(35, 13);
            this.Prueba.TabIndex = 17;
            this.Prueba.Text = "label4";
            // 
            // Probar
            // 
            this.Probar.Location = new System.Drawing.Point(306, 36);
            this.Probar.Name = "Probar";
            this.Probar.Size = new System.Drawing.Size(75, 23);
            this.Probar.TabIndex = 18;
            this.Probar.Text = "Probar";
            this.Probar.UseVisualStyleBackColor = true;
            this.Probar.Click += new System.EventHandler(this.Probar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.comboBox1.Location = new System.Drawing.Point(209, 174);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // frmComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 368);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Probar);
            this.Controls.Add(this.Prueba);
            this.Controls.Add(this.DivicionDeNegocio);
            this.Controls.Add(this.PuntoDeEmicion);
            this.Controls.Add(this.AreaDeImpresion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Limite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Serie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frmComprobante";
            this.Text = "frmComprobante";
            ((System.ComponentModel.ISupportInitialize)(this.Limite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaDeImpresion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PuntoDeEmicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivicionDeNegocio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Serie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Limite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown AreaDeImpresion;
        private System.Windows.Forms.NumericUpDown PuntoDeEmicion;
        private System.Windows.Forms.NumericUpDown DivicionDeNegocio;
        private System.Windows.Forms.Label Prueba;
        private System.Windows.Forms.Button Probar;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}