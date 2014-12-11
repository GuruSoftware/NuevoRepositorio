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

namespace PuntoDeVenta
{
    public partial class BuscarClientes : Form
    {

        public string ID { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; } 


        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;


        public BuscarClientes()
        {
            InitializeComponent();
            strConn = @"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True";
        }

        private void BuscarClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblClientes' Puede moverla o quitarla según sea necesario.
           // this.tblClientesTableAdapter.Fill(this.iNF_522_DataSet.tblClientes);
            btnBuscar_Click(null, null);
            AcceptButton = button1; ;
            pimpiarData();
            this.ActiveControl = txtNombre;


        }



        private void ActualizaTotal()
        {
            if (dt != null)

                txtTotalRegistros.Text = dt.DefaultView.Count.ToString("#,###;;0");
        }

        private void pimpiarData()
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 8);
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;//letras de la seleccion
            // this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue; //para la celda seleccionada
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            Cursor.Current = Cursors.WaitCursor;
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM tblClientes WHERE 1=1");
            if (this.txtNombre.Text.Trim().Length > 0)
                sql.Append(" AND CodigoDeBarra like '%" + this.txtNombre.Text.Trim() + "%' ");

            if (this.txtApellido.Text.Trim().Length > 0)
                sql.Append(" AND Descripcion LIKE '%" + this.txtApellido.Text.TrimEnd().TrimStart() + "%' ");

            
            conexion = new SqlConnection(strConn);
            cmd = new SqlCommand(sql.ToString(), conexion);
            adapter = new SqlDataAdapter(cmd);
            try
            {
                conexion.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = dt;

            if (dt != null)
                txtTotalRegistros.Text = dt.Rows.Count.ToString("#,###;;0");

            Cursor.Current = Cursors.Default;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //this.txtCodigo.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.dataGridView1.DataSource = null;
            btnNombre.Text = string.Empty;
            btnApellido.Text = string.Empty;
            btnID.Text = string.Empty;
            this.txtTotalRegistros.Text = "0";

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Nombre LIKE '%" + txtNombre.Text.TrimEnd() + "%'";
   
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Apellido LIKE '%" + txtApellido.Text.TrimEnd() + "%'";
   
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                btnID.Text = row.Cells["ColumnID"].Value.ToString();
                btnNombre.Text = row.Cells["ColumnNombre"].Value.ToString();
                btnApellido.Text = row.Cells["ColumnApellido"].Value.ToString();

            }
        }

        bool ValidarCampos()
        {

            if (this.btnID.Text.Trim().Length <= 0)
            {

                MessageBox.Show("Seleccione un Articulo");
                this.DialogResult = DialogResult.None;
                this.txtNombre.Focus();
                return false;
            }


            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                ID = btnID.Text;
                Nombre = btnNombre.Text; 
                Apellido = btnApellido.Text;
            }
        }


    }
}
