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
    public partial class ConsultaEntradaUsuarios : Form
    {

        public string valor { set; get; }
        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;


        public ConsultaEntradaUsuarios()
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

        private void ConsultaEntradaUsuarios_Load(object sender, EventArgs e)
        {
            btnBuscar_Click(null, null);
            AcceptButton = this.btnBuscar; ;
            pimpiarData();
            this.ActiveControl = txtUsuario;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM tblControlEntrada WHERE 1=1");
            if (this.txtUsuario.Text.Trim().Length > 0)
                sql.Append(" AND Usuario like '%" + this.txtUsuario.Text.Trim() + "%' ");

            if (this.txtFecha.Text.Trim().Length > 0)
                sql.Append(" AND Fecha LIKE '%" + this.txtFecha.Text.TrimEnd().TrimStart() + "%' ");


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
            this.txtUsuario.Text = string.Empty;
            this.txtFecha.Text = string.Empty;
            this.dataGridView1.DataSource = null;

            this.txtTotalRegistros.Text = "0";

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Usuario LIKE '%" + txtUsuario.Text.TrimEnd() + "%'";
   
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Fecha LIKE '%" + txtFecha.Text.TrimEnd() + "%'";
   
        
        }



    }
}
