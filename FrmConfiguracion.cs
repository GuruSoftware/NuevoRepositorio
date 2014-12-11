using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Media;


namespace PuntoDeVenta
{
    public partial class FrmConfiguracion : Form
    {
        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;


        public FrmConfiguracion()
        {
            InitializeComponent();
            strConn = @"Data Source=PC-PC;Initial Catalog=INF-522;Integrated Security=True";

        }

        private void LlenarDataGridVied()
        {
            dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM tblCompañia WHERE 1=1");


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

        }


        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblCompañia' Puede moverla o quitarla según sea necesario.
            this.tblCompañiaTableAdapter.Fill(this.iNF_522_DataSet.tblCompañia);
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblCompañia' Puede moverla o quitarla según sea necesario.
          //  this.tblCompañiaTableAdapter1.Fill(this.iNF_522_DataSet.tblCompañia);
            // TODO: esta línea de código carga datos en la tabla 'dataSetCompania.tblCompañia' Puede moverla o quitarla según sea necesario.
          //  this.tblCompañiaTableAdapter1.Fill(this.dataSetCompania.tblCompañia);

            txtCodigo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ColunmCodigo"].Value.ToString();
            txtNombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ColunmNombre"].Value.ToString();
            txtDireccion.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ColunmDireccion"].Value.ToString();
            txtTelefono.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ColunmTelefono"].Value.ToString();

           // LlenarDataGridVied();
          

        }

        private bool ValidarCampos()
        {
            if (this.txtNombre.Text.Trim().Length <= 0)
            {
                MessageBox.Show("El Nombre no Puede estar en Blanco");
                this.txtNombre.Focus();
                return false;
            }


            if (this.txtDireccion.Text.Trim().Length <= 0)
            {
                MessageBox.Show("La Direccion no Puede estar en Blanco");
                this.txtDireccion.Focus();
                return false;
            }

            if (this.txtTelefono.Text.Trim().Length <= 0)
            {
                MessageBox.Show("El Telefono no Puede estar en Blanco");
                this.txtTelefono.Focus();
                return false;
            }



            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            // this.AcceptButton = Guardar;
            // SystemSounds.Exclamation.Play();
            DataTable dt = new DataTable();
            // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            if (this.txtNombre.Text.Contains("NUEVO"))
            {

                if (ValidarCampos() == true)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblUsuarios (Usuario, Contrasena, Grupo, Permisos)" +
                                                        " VALUES (@Usuario, @Contrasena, @Grupo , @Permisos);", conn);



                        SqlDataAdapter a = new SqlDataAdapter(cmd);

                        conn.Open();
                        a.Fill(dt);
                    }

                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {

                        conn.Close();
                    }

                    if (ValidarCampos() == true)
                    {
                        SystemSounds.Exclamation.Play();

                        MessageBox.Show("Informacion Guardada Satisfactoriamente.");
                        this.DialogResult = DialogResult.OK;
                      //  this.Close();
                    }

                }
            }

            else
            {


                try
                {

                    SqlCommand cmd = new SqlCommand("UPDATE tblCompañia SET  Nombre=@Nombre, Direccion=@Direccion , Telefono=@Telefono  WHERE Codigo = @Codigo", conn);



                    cmd.Parameters.AddWithValue("@Codigo", this.txtCodigo.Text);
                    cmd.Parameters.AddWithValue("@Nombre", this.txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Direccion", this.txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@Telefono", this.txtTelefono.Text); 




                    SqlDataAdapter a = new SqlDataAdapter(cmd);

                    conn.Open();
                    a.Fill(dt);
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {

                    conn.Close();

                }
                if (ValidarCampos() == true)
                {

                    MessageBox.Show("Informacion Guardada Satisfactoriamente.");
                    this.DialogResult = DialogResult.OK;
                  //  this.Close();
                }


            }

        }

    }
}
