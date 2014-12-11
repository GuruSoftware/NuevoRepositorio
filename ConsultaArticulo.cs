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
    public partial class ConsultaArticulo : Form
    {
        public string valor { set; get; }
        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;




        public ConsultaArticulo()
        {
            InitializeComponent();
            strConn = @"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True";
  
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


        private void FrmBuscarArticulo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblArticulos' Puede moverla o quitarla según sea necesario.
            this.tblArticulosTableAdapter.Fill(this.iNF_522_DataSet.tblArticulos);
            btnBuscar_Click(null, null);
            AcceptButton = this.btnBuscar; ;
            pimpiarData();
            this.ActiveControl = txtCodigo;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM tblArticulos WHERE 1=1");
            if (this.txtCodigo.Text.Trim().Length > 0)
                sql.Append(" AND CodigoDeBarra like '%" + this.txtCodigo.Text.Trim() + "%' ");

            if (this.txtDescripcion.Text.Trim().Length > 0)
                sql.Append(" AND Descripcion LIKE '%" + this.txtDescripcion.Text.TrimEnd().TrimStart() + "%' ");

            if (this.txtReferencia.Text.Trim().Length > 0)
                sql.Append(" AND Referencia LIKE '%" + this.txtReferencia.Text.TrimEnd().TrimStart() + "%' ");
           

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
            this.txtCodigo.Text = string.Empty;
            this.txtReferencia.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.dataGridView1.DataSource = null;
           
            this.txtTotalRegistros.Text = "0";
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "CodigoDeBarra LIKE '%" + txtCodigo.Text.TrimEnd() + "%'";
   
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Descripcion LIKE '%" + txtDescripcion.Text.TrimEnd() + "%'";
   
    
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Referencia LIKE '%" + txtReferencia.Text.TrimEnd() + "%'";
   
    
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (this.dataGridView1.RowCount > 0)
            {
                 valor = dataGridView1[0, e.RowIndex].Value.ToString();
                /*if (valor.Length > 0)
                {
                    frmPrueba frm = new frmPrueba(valor);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.btnBuscar_Click(sender, e);
                    }
                    frm.Dispose();
                }*/
            }
        }

        

        private void button1_Click_1(object sender, EventArgs e) // BOTON DE AGREGAR ARTICULOS A LA FACTURA
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void FrmBuscarArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    button1_Click_1(null, null);
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnBuscar_Click(null, null);
            NuevoArticulos N = new NuevoArticulos();
            N.ShowDialog();
            btnBuscar_Click(null, null);

        }
    }
}
