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
    public partial class ConsultaCliente : Form
    {

        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;


        public ConsultaCliente()
        {
            InitializeComponent();
            strConn = @"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True";
        }

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblClientes' Puede moverla o quitarla según sea necesario.
            this.tblClientesTableAdapter1.Fill(this.iNF_522_DataSet.tblClientes);
            pimpiarData();
            AcceptButton = btnBuscar;
            btnBuscar_Click(null, null);
            
        }

        private void ActualizaTotal()
        {
            if (dt != null)

                txtTotalRegistros.Text = dt.DefaultView.Count.ToString("#,###;;0");
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM tblClientes WHERE 1=1");
            if (this.txtNombre.Text.Trim().Length > 0)
                sql.Append(" AND Nombre like '%" + this.txtNombre.Text.Trim() + "%' ");
            //if (this.txtCodigo.Text.Trim().Length > 0)
            // sql.Append(" AND Codigo=" + this.txtCodigo.Text);
            if (this.txtApellido.Text.Trim().Length > 0)
                sql.Append(" AND Apellido LIKE '%" + this.txtApellido.Text.TrimEnd().TrimStart() + "%' ");
            //sql.Append(" ORDER BY Codigo desc, Centro");

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

            this.dgvClientes.AutoGenerateColumns = false;
            this.dgvClientes.DataSource = dt;

            if (dt != null)
                txtTotalRegistros.Text = dt.Rows.Count.ToString("#,###;;0");

            Cursor.Current = Cursors.Default;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        { 
            this.txtApellido.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.dgvClientes.DataSource = null;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoCliente c = new NuevoCliente();
            c.Show();

        }

        private void pimpiarData()
        {
            this.dgvClientes.DefaultCellStyle.Font = new Font("Tahoma", 8);
            this.dgvClientes.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvClientes.DefaultCellStyle.BackColor = Color.Beige;
            this.dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;//letras de la seleccion
            // this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue; //para la celda seleccionada
            this.dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor;
            if (dgvClientes.RowCount > 0)
            {
                valor = dgvClientes[0, e.RowIndex].Value.ToString();
                if (valor.Length > 0)
                {
                    ActualizarClientes frm = new ActualizarClientes(valor);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.btnBuscar_Click(sender, e);
                    }
                    frm.Dispose();
                }
            }
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor;
            if (dgvClientes.RowCount > 0)
            {
                valor = dgvClientes[0, e.RowIndex].Value.ToString();
                if (valor.Length > 0)
                {
                    ActualizarClientes frm = new ActualizarClientes(valor);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.btnBuscar_Click(sender, e);
                    }
                    frm.Dispose();
                }
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor;
            if (dgvClientes.RowCount > 0)
            {
                valor = dgvClientes[0, e.RowIndex].Value.ToString();
                if (valor.Length > 0)
                {
                    ActualizarClientes frm = new ActualizarClientes(valor);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.btnBuscar_Click(sender, e);
                    }
                    frm.Dispose();
                }
            }
        }

        
    }
}
