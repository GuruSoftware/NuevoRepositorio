namespace PuntoDeVenta
{
    partial class NuevoArticulos
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
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.rectangleShape5 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtUnidad = new System.Windows.Forms.ComboBox();
            this.txtDepartamento = new System.Windows.Forms.ComboBox();
            this.txtProveedor = new System.Windows.Forms.ComboBox();
            this.iNF_522_DataSet = new PuntoDeVenta.INF_522_DataSet();
            this.tblSuplidorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblSuplidorTableAdapter = new PuntoDeVenta.INF_522_DataSetTableAdapters.tblSuplidorTableAdapter();
            this.Guardar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iNF_522_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuplidorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(145, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 31);
            this.label7.TabIndex = 84;
            this.label7.Text = "Registrar Articulos";
            // 
            // rectangleShape5
            // 
            this.rectangleShape5.BackgroundImage = global::PuntoDeVenta.Properties.Resources.shopping_cart_icon;
            this.rectangleShape5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rectangleShape5.BorderColor = System.Drawing.Color.Transparent;
            this.rectangleShape5.Location = new System.Drawing.Point(37, 13);
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
            this.shapeContainer1.TabIndex = 85;
            this.shapeContainer1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.txtDepartamento);
            this.groupBox1.Controls.Add(this.txtUnidad);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.txtCosto);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtReferencia);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(106, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 328);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(130, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(159, 20);
            this.txtCodigo.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Descripcion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Codigo:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(55, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Referencia:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(130, 59);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(159, 20);
            this.txtReferencia.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Unidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Precio de Venta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Costo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Cantidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Departamento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Proveedor:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(130, 94);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(365, 20);
            this.txtDescripcion.TabIndex = 64;
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(130, 158);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(73, 20);
            this.txtCosto.TabIndex = 65;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(130, 192);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(73, 20);
            this.txtPrecio.TabIndex = 66;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(131, 228);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(73, 20);
            this.txtCantidad.TabIndex = 67;
            // 
            // txtUnidad
            // 
            this.txtUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUnidad.FormattingEnabled = true;
            this.txtUnidad.Items.AddRange(new object[] {
            "UND",
            "PAQUETE"});
            this.txtUnidad.Location = new System.Drawing.Point(132, 130);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(121, 21);
            this.txtUnidad.TabIndex = 68;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDepartamento.FormattingEnabled = true;
            this.txtDepartamento.Items.AddRange(new object[] {
            "ALIMENTOS",
            "ARROZ",
            "ARTICULOS DE BEBES",
            "BEBIDAS",
            "CRISTALERIA",
            "CUIDADO PERSONAL",
            "DETERGENTES",
            "DULCES",
            "ELECTRONICOS",
            "EMBUTIDOS",
            "ENLATADOS",
            "FERRETERIA",
            "FRUTAS",
            "LACTEOS",
            "MEDICAMENTOS",
            "OTROS",
            "PESCADERIA",
            "PLASTICOS",
            "PRODUCTOS DE BELLEZA",
            "PRODUCTOS DE LIMPIEZA",
            "PRODUCTOS PARA ANIMALES"});
            this.txtDepartamento.Location = new System.Drawing.Point(130, 260);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(121, 21);
            this.txtDepartamento.TabIndex = 69;
            // 
            // txtProveedor
            // 
            this.txtProveedor.DataSource = this.tblSuplidorBindingSource;
            this.txtProveedor.DisplayMember = "Nombre";
            this.txtProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProveedor.FormattingEnabled = true;
            this.txtProveedor.Location = new System.Drawing.Point(131, 291);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(121, 21);
            this.txtProveedor.TabIndex = 70;
            this.txtProveedor.ValueMember = "Nombre";
            // 
            // iNF_522_DataSet
            // 
            this.iNF_522_DataSet.DataSetName = "INF_522_DataSet";
            this.iNF_522_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblSuplidorBindingSource
            // 
            this.tblSuplidorBindingSource.DataMember = "tblSuplidor";
            this.tblSuplidorBindingSource.DataSource = this.iNF_522_DataSet;
            // 
            // tblSuplidorTableAdapter
            // 
            this.tblSuplidorTableAdapter.ClearBeforeFill = true;
            // 
            // Guardar
            // 
            this.Guardar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Guardar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Guardar.Location = new System.Drawing.Point(170, 449);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(123, 51);
            this.Guardar.TabIndex = 87;
            this.Guardar.Text = "Guardar ";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.ForeColor = System.Drawing.Color.Red;
            this.Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancelar.Location = new System.Drawing.Point(350, 449);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(135, 51);
            this.Cancelar.TabIndex = 88;
            this.Cancelar.Text = "&Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            // 
            // NuevoArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PuntoDeVenta.Properties.Resources.backgroundd1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 512);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "NuevoArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Articulos";
            this.Load += new System.EventHandler(this.NuevoArticulos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iNF_522_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuplidorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape5;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox txtProveedor;
        private System.Windows.Forms.ComboBox txtDepartamento;
        private System.Windows.Forms.ComboBox txtUnidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private INF_522_DataSet iNF_522_DataSet;
        private System.Windows.Forms.BindingSource tblSuplidorBindingSource;
        private INF_522_DataSetTableAdapters.tblSuplidorTableAdapter tblSuplidorTableAdapter;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button Cancelar;
    }
}