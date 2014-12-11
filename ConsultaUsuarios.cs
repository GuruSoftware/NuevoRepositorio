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
    public partial class ConsultaUsuarios : Form
    {
        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty; 

        public ConsultaUsuarios()
        {
            InitializeComponent();
            strConn = @"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True";
            ActualizaTotal();
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

        private void ActualizaTotal()
        {
            // if (dt != null)

            txtTotalRegistros.Text = dt.DefaultView.Count.ToString("#,###;;0");
        }

        private void ConsultaUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblUsuarios' Puede moverla o quitarla según sea necesario.
            this.tblUsuariosTableAdapter.Fill(this.iNF_522_DataSet.tblUsuarios);
            ActualizaTotal();


            pimpiarData();
            //SetEnter();
            this.AcceptButton = btnBuscar;
            btnBuscar_Click(null, null);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            // SystemSounds.Exclamation.Play();
            Cursor.Current = Cursors.WaitCursor;
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ID, Usuario,Grupo FROM tblUsuarios WHERE 1=1");
            if (this.txtGrupo.Text.Trim().Length > 0)
                sql.Append(" AND Grupo like '%" + this.txtGrupo.Text.Trim() + "%' ");
            if (this.txtUsuario.Text.Trim().Length > 0)
                sql.Append(" AND Usuario LIKE '%" + this.txtUsuario.Text.TrimEnd().TrimStart() + "%' ");
            sql.Append(" ORDER BY ID ,Grupo , Usuario");

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

        private void button3_Click(object sender, EventArgs e) // nuevo
        {
            NuevoUsuario u = new NuevoUsuario(id);
            u.Show();
        }

        public int id { get; set; }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Usuario LIKE '%" + txtUsuario.Text.TrimEnd() + "%'";
     
        }

        private void txtGrupo_TextChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = "Grupo LIKE '%" + txtGrupo.Text.TrimEnd() + "%'";
     

        }

        private void button2_Click(object sender, EventArgs e)
        {
              this.txtGrupo.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.dataGridView1.DataSource = null;
            this.txtTotalRegistros.Text = "0";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor;
            if (dataGridView1.RowCount > 0)
            {
                valor = dataGridView1[0, e.RowIndex].Value.ToString();
                if (valor.Length > 0)
                {
                    ActualizarUsuarios frm = new ActualizarUsuarios(valor);
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
