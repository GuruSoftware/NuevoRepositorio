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
    public partial class FrmFacturacion : Form
    {
        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulo s = new FrmBuscarArticulo();
            s.Show();
        }

        private void FrmFacturacion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                    case Keys.F2:
                    FrmBuscarArticulo b = new FrmBuscarArticulo();
                    b.Show();

                    

                    break;
            }
        }

        private void lblReferencia_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulo n = new FrmBuscarArticulo();
            n.Show();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {

        }

        
    }
}
