using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {

           
            // TODO: esta línea de código carga datos en la tabla 'INF_522_DataSet.tblArticulos' Puede moverla o quitarla según sea necesario.
            this.tblArticulosTableAdapter.Fill(this.INF_522_DataSet.tblArticulos);

            this.reportViewer1.RefreshReport();
        }
    }
}
