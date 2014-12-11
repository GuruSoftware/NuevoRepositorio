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
    public partial class frmCajero : Form
    {
        public frmCajero()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)// btn del cuadre
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCuadre c = new frmCuadre();
            c.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmFactura f = new frmFactura();
            f.Show();
        }
    }
}
