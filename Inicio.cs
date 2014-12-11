using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using System.Threading;
using System.Drawing.Text;


namespace PuntoDeVenta
{
    public partial class Inicio : Form, IProducto
    {
        //
        //Creamos una lista del tipo Eproducto, que sera la encargada de
        //recibir la informacion del Form2 y almacenarla, posteriormente servira
        //de fuente de datos para el DataGridView
        private static readonly List<EProducto> Products = new List<EProducto>();


        private Session session;

        public Inicio(Session session)
        {
            this.session = session;
            InitializeComponent();

            MenuPrincipal menu = new MenuPrincipal(this.menuStrip1);
            menu.UpdateMenuItems(Session.permisos);

            GetDatosUsuario();
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturacion n = new FrmFacturacion();
            n.ShowDialog(); ;
        }


        private DataTable Datos()
        {
            DataTable dt = new DataTable();
            return dt;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblArticulos' Puede moverla o quitarla según sea necesario.
            //this.tblArticulosTableAdapter.Fill(this.iNF_522_DataSet.tblArticulos);
            // TODO: esta línea de código carga datos en la tabla '_INF_522_Tablas.tblArticulos' Puede moverla o quitarla según sea necesario.
          //  this.tblArticulosTableAdapter.Fill(this._INF_522_Tablas.tblArticulos);
           
           
            WindowState = FormWindowState.Maximized;

            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtHora.Text = DateTime.Now.ToShortTimeString();
           


        }

        private void clienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes c = new FrmClientes();
            c.ShowDialog(); ;

        }

        private void archivoToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void button13_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case  Keys.F2:
                    FrmBuscarArticulo b = new FrmBuscarArticulo();
                    b.ShowDialog();

               



                    break;
            }
        }

        private void lblReferencia_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulo n = new FrmBuscarArticulo();
            n.ShowDialog();
        }

        private void ventaYFacturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministrador b = new frmAdministrador();
            b.ShowDialog();
        }



        public bool LoadDataRow(EProducto product)
        {
            //Busca si el Articulo ya se encuentra en la lista
            bool exists = Products.Any(x => x.PrecioTotal.Equals(product.PrecioTotal));
            //
            //
            //Preguntamos por el resultado de la busqueda del Articulo dentro de la lista
            if (!exists)
            {
                //
                //Si el articulo no existe dentro de la lista Mepeamos el item de la entidad Eproducto 
                //a los TextBox


                //textBox1.Text = Convert.ToString(product.Descripcion);
               // textBox2.Text = Convert.ToString(product.Cantidad);
                
                //
                //Agregamos a la lista de productos el Item enviado por el Form2
                //
                Products.Add(product);
                //
                //
                //
               // dataGridView1.AutoGenerateColumns = false;
                //
                //
               // dataGridView1.DataSource = null;
                //
                //Establecemos el DataSource del DataGridView enlazandolo a la lista
                //generica
               // dataGridView1.DataSource = Products;
                //
                //Mapeamos las propiedades a las columnas
              
               // dataGridView1.Columns["ColumnCodigo"].DataPropertyName = "Codigo";
               // dataGridView1.Columns["ColumnDescripcion"].DataPropertyName = "Descripcion";
               // dataGridView1.Columns["ColumnCantidad"].DataPropertyName = "Cantidad";
               // dataGridView1.Columns["ColumnTotalUnidad"].DataPropertyName = "TotalUnidad";
               // dataGridView1.Columns["ColumnPrecioTotal"].DataPropertyName = "PrecioVenta";

                //
                //Retornamos True
                return true;
            }
            //
            //Si la condicion exists es igual a False, es decir, que el producto SI existe en la lista
            //retornamos FALSE para mostrar un mensajde informacion
            return false;
        }





        private void button13_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulo frm = new FrmBuscarArticulo();
            frm.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)// BOTON DE AYUDA
        {
            FrmAyuda A = new FrmAyuda();
            A.ShowDialog();

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)// BUSCAR ARTICULOS
        {
            FrmBuscarArticulo b = new FrmBuscarArticulo();
            b.ShowDialog(); ;
        }

        private void button13_KeyDown_1(object sender, KeyEventArgs e)// BUSCAR ARTICULOS
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    FrmBuscarArticulo b = new FrmBuscarArticulo();
                    b.ShowDialog();;



                    break;
            }

        }

        private void button12_KeyDown(object sender, KeyEventArgs e) // CAMBIAR CANTIDAD
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmVentas f = new FrmVentas(valor);
            f.ShowDialog(); ;
        }

        private void button9_Click(object sender, EventArgs e)// CANCELAR FACTURA
        {
          
        }

        private void button9_KeyDown(object sender, KeyEventArgs e)// CANCELAR FACTURA
        {
        }

        private void button11_Click(object sender, EventArgs e)// ANULAR ARTICULO O ELIMINARLO
        {
           
           
          
            


        }

        private void button8_Click(object sender, EventArgs e)
        {
            
              
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_KeyDown(object sender, KeyEventArgs e) // acceso rapido pa salir ESc salir
        {
           // switch (e.KeyCode)
            {
                  //  case Keys.Escape:
                   // PanelVenta.Visible = false;
                //    break;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //dataGridView1.SelectedCells[2].Value = textBox4.Text;
           // dataGridView1.SelectedCells[4].Value = int.Parse(dataGridView1.SelectedCells[3].Value.ToString()) * int.Parse(dataGridView1.SelectedCells[2].Value.ToString());
       

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           // textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
          //  textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
         //textBox4.Text = dataGridView1.SelectedCells[2].Value.ToString();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
           // if (MessageBox.Show("¿Está seguro que desea salir del sistema?",
            //  "Advertencia", MessageBoxButtons.OKCancel,
             // MessageBoxIcon.Question) == DialogResult.Cancel)
           // {
              //  Application.OpenForms[0].Dispose();
             //   return;
           // }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {

        }

        private void Cantidad_Leave(object sender, EventArgs e)
        {
            
           
        }








        public string valor { get; set; }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e) // BOTON CAJERO 
        {
            frmCajero c = new frmCajero();
            c.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) // SALIR DEL SISTEMA
        {

            this.Dispose();
        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
              //////////////////////////////////////////////////////////////////////////////
            switch (e.KeyCode)
            {
                //////////////////////////////////////////////////////////////////////////////
                //cajero
                case Keys.F1:
                    if (archivoToolStripMenuItem.Enabled == true)
                    {

                        archivoToolStripMenuItem_Click(null, null);

                    }
                   
                    break;



                //////////////////////////////////////////////////////////////////////////////
                //administrador

                case Keys.F2:
                    if (ventaYFacturacionToolStripMenuItem.Enabled == true)
                    {

                        ventaYFacturacionToolStripMenuItem_Click(null, null);

                    } 
                 break;




                //////////////////////////////////////////////////////////////////////////////
                //digitador 

                case Keys.F3:
                 if (toolStripMenuItem1.Enabled == true)
                 {
                     toolStripMenuItem1_Click(null, null);
                 }
                 break;



                //////////////////////////////////////////////////////////////////////////////
                // cuadre

                case Keys.F4:
                 if (toolStripMenuItem1.Enabled == true)
                 {
                     frmCuadre F = new frmCuadre();
                     F.ShowDialog(); ;
                 }
                 break;



                //////////////////////////////////////////////////////////////////////////////
                // facturacion
                case Keys.F5:
                 if (toolStripMenuItem3.Enabled == true)
                 {
                     toolStripMenuItem3_Click(null, null);
                 }
                 break;



                //////////////////////////////////////////////////////////////////////////////
                // inventario
                case Keys.F6:
                 if (toolStripMenuItem4.Enabled == true)
                 {
                     toolStripMenuItem4_Click(null, null);
                 }
                 break;




                //////////////////////////////////////////////////////////////////////////////
                case Keys.F7:
                 NuevoCotizacion c = new NuevoCotizacion(id);
                 c.ShowDialog();;
                 break;
                //////////////////////////////////////////////////////////////////////////////
                case Keys.F8:
                 FrmBackup b = new FrmBackup();
                 b.ShowDialog();;
                 break;
                //////////////////////////////////////////////////////////////////////////////
                case Keys.F9:
                FrmAyuda A = new FrmAyuda();
                 A.ShowDialog();;
                 break;


                //////////////////////////////////////////////////////////////////////////////
                //ayuda
                case Keys.F10:
                 if (toolStripMenuItem9.Enabled == true)
                 {
                     
                     toolStripMenuItem9_Click(null, null);
                     
                 }
                 
                 break;
                  

                //////////////////////////////////////////////////////////////////////////////
                case Keys.Escape:
                this.Close();
                 break;


            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) // boton del digitador 
        {
            frmDigitador f = new frmDigitador();
            f.ShowDialog(); ;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e) // BOTON DE INfORMACION
        {
            frmInformacion I = new frmInformacion();
            I.ShowDialog(); ;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) // boton del caudre
        {
            frmCuadre c = new frmCuadre();
            c.ShowDialog(); ;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) // botn del inventario
        {
            ConsultaInventario i = new ConsultaInventario();
            i.ShowDialog(); ;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e) // boton del backup
        {
            FrmBackup b = new FrmBackup();
            b.ShowDialog(); ;
        }
        void GetDatosUsuario()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
           // cmd.CommandText = "SELECT Usuario, Descripcion, PrecioVenta , Referencia FROM tblArticulos WHERE Referencia=@Referencia or CodigoDeBarra=@CodigoDeBarra";
            cmd.CommandText = "SELECT Usuario FROM tblControlEntrada WHERE ID = (SELECT MAX(ID) from tblControlEntrada)";


            SqlDataReader r;
            try
            {
                conn.Open();
                r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        this.txtUsuario.Text = r.GetString(0);


                    }
                }
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            NuevoCotizacion c = new NuevoCotizacion(ID);
            c.ShowDialog(); ;
        }



        public string ID { get; set; }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            NuevoCotizacion c = new NuevoCotizacion(id);
            c.ShowDialog(); ;

        }

        public string id { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {

            Dispose();
            Application.OpenForms[0].ShowDialog();
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Dispose();
            Application.OpenForms[0].ShowDialog();
        }
    }
}
