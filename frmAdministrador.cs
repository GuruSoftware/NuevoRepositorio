using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms; 


namespace PuntoDeVenta
{
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmConfiguracion c = new FrmConfiguracion();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)// CLIENTES
        {
            ConsultaCliente c = new ConsultaCliente();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)// BACKUP
        {
            FrmBackup b = new FrmBackup();
            b.Show();
        }

        private void button13_Click(object sender, EventArgs e)// consulta de usuarios
        {
            ConsultaUsuarios u = new ConsultaUsuarios();
            u.Show();


        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            ConsultaInventario i = new ConsultaInventario();
            i.Show();
        }

        public int ID { get; set; }

        private void button5_Click(object sender, EventArgs e) // consultar articulo
        {
            ConsultaArticulo c = new ConsultaArticulo();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e) // historial de usuario
        {
            ConsultaEntradaUsuarios es = new ConsultaEntradaUsuarios();
            es.Show(); 
        }

        private void button6_Click(object sender, EventArgs e) // boton de las cotizaciones
        {
            NuevoCotizacion c = new NuevoCotizacion(id);
            c.Show();

        }

        public string id { get; set; }
    }
}
