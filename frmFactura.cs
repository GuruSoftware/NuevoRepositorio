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
using Microsoft.Reporting.WinForms;


namespace PuntoDeVenta
{
    public partial class frmFactura : Form
    {


        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;



        public frmFactura()
        {
            InitializeComponent();
            strConn = @"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True";
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


        private void pimpiarData2()
        {
            this.dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 8);
            this.dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView2.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;//letras de la seleccion
            // this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue; //para la celda seleccionada
            this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            btnDetalle_Click(null, null);
            btnBuscar_Click(null, null);
            pimpiarData();
            pimpiarData2();

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM tblDetalles WHERE 1=1");
            if (this.txtID.Text.Trim().Length > 0)
                sql.Append(" AND ID_Factura like '%" + this.txtID.Text.Trim() + "%' ");
           

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

            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.DataSource = dt;

            if (dt != null)
                txtTotalRegistros.Text = dt.Rows.Count.ToString("#,###;;0");

            Cursor.Current = Cursors.Default;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM tblFactura WHERE 1=1");
            if (this.txtID.Text.Trim().Length > 0)
                sql.Append(" AND ID like '%" + this.txtIDFactura.Text.Trim() + "%' ");
            if (this.txtID.Text.Trim().Length > 0)
                sql.Append(" AND Cliente like '%" + this.txtCliente.Text.Trim() + "%' ");



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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                btnDetalle_Click(null, null);

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                btnDetalle_Click(null, null);
            }
        }

        








        
    }
}
