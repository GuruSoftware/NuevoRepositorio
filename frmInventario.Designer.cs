namespace PuntoDeVenta
{
    partial class frmInventario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.INF_522_DataSet = new PuntoDeVenta.INF_522_DataSet();
            this.tblArticulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblArticulosTableAdapter = new PuntoDeVenta.INF_522_DataSetTableAdapters.tblArticulosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.INF_522_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblArticulosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataInventario";
            reportDataSource2.Value = this.tblArticulosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PuntoDeVenta.ReporteInventario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(739, 323);
            this.reportViewer1.TabIndex = 0;
            // 
            // INF_522_DataSet
            // 
            this.INF_522_DataSet.DataSetName = "INF_522_DataSet";
            this.INF_522_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblArticulosBindingSource
            // 
            this.tblArticulosBindingSource.DataMember = "tblArticulos";
            this.tblArticulosBindingSource.DataSource = this.INF_522_DataSet;
            // 
            // tblArticulosTableAdapter
            // 
            this.tblArticulosTableAdapter.ClearBeforeFill = true;
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 323);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.INF_522_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblArticulosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblArticulosBindingSource;
        private INF_522_DataSet INF_522_DataSet;
        private INF_522_DataSetTableAdapters.tblArticulosTableAdapter tblArticulosTableAdapter;
    }
}