
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
    public partial class NuevoUsuario : Form
    {
        private int ID = 0;
        //private string valor;

        public NuevoUsuario(int ID)
        {
            InitializeComponent();
            // cmbTipoUsuario.Items.Add("Administrador");
            // cmbTipoUsuario.Items.Add("Cajero");
            // cmbTipoUsuario.Items.Add("Registro");
            this.ID = ID;

            if (ID != 0)
            {
                //this.lblID.Text = "ACTUALIZANDO";
                // this.lblID.TextAlign = ContentAlignment.MiddleRight;
                //Eliminar.Enabled = true;
                GetEstudianteInfo();
            }
        }



         public NuevoUsuario()
        {
            // TODO: Complete member initialization
        }

        public NuevoUsuario(string valor)
        {
            // TODO: Complete member initialization
           // this.valor = valor;

        }

        void GetEstudianteInfo()
        {
            // SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
          //  SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True");
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, Usuario, Contrasena, Grupo FROM tblUsuarios WHERE ID= @ID";
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader r;
            try
            {
                conn.Open();
                r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        string ClaveSinEncriptar = CryptorEngine.Decrypt(r.GetString(2), true);
                        // this.txtID.Text = r.GetInt32(0).ToString();
                        this.txtUsuario.Text = r.GetString(1).TrimEnd();
                        this.txtContraseña.Text = ClaveSinEncriptar;
                        this.txtConfirmarContraseña.Text = ClaveSinEncriptar;
                        // this.cmbTipoUsuario.Text = r.GetString(3);
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


        private String GetPermiso()
        {
            string permiso = String.Empty;

            if (this.Administrador.Checked)
            {
                permiso = permiso + ";1;2;3;4;5;6;7;8;9;10;11;";
            }
            if (this.Digitador.Checked)
            {
                permiso = permiso + ";3;9;10;11;";
            }
            if (this.cajero.Checked)
            {
                permiso = permiso + ";1;4;5;7;9;10;11;";
            }





            return permiso;
        }

        private String GetGrupo()
        {
            string Grupo = String.Empty;

            if (this.Administrador.Checked)
            {
                Grupo = Grupo + "Administrador";
            }
            if (this.Digitador.Checked)
            {
                Grupo = Grupo + "Digitador";
            }
            if (this.cajero.Checked)
            {
                Grupo = Grupo + "Cajero";
            }





            return Grupo;
        }


        bool ValidarUsuarioRepetido() // Este metodo valida si la cedula que se esta ingresando existe en la base de datos
        {
            DataTable dt = new DataTable();
            // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
          // SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True");
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand("select Usuario from tblUsuarios", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {


                    if (this.txtUsuario.Text.Trim() == rdr.GetString(0))
                    {
                        MessageBox.Show("Este Usuario ya existe en el registro ", "Registro Duplicado");
                        this.DialogResult = DialogResult.None;
                        this.txtUsuario.Focus();
                        return false;
                    }



                }
                rdr.Close();
            }
            conn.Close();

            return true;

        }

        bool ValidarCampos()
        {

            if (this.txtUsuario.Text.Trim().Length <= 0)
            {
                MessageBox.Show("El Usuario no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtUsuario.Focus();
                return false;
            }
            if (this.txtContraseña.Text.TrimEnd().Length <= 0)
            {
                MessageBox.Show("La Contraseña no puede estar en blanco.", "Advertencia");
                this.DialogResult = DialogResult.None;
                this.txtContraseña.Focus();

                return false;

            }
            if (this.txtConfirmarContraseña.Text.TrimEnd().Length <= 0)
            {
                MessageBox.Show("Debe Confirmar la Contraseña");
                this.DialogResult = DialogResult.None;
                this.txtConfirmarContraseña.Focus();
                return false;
            }
            if (this.txtContraseña.Text.TrimEnd() != this.txtConfirmarContraseña.Text.TrimEnd())
            {
                MessageBox.Show("La Contraseña no coinciden");
                this.DialogResult = DialogResult.None;
                this.txtContraseña.Focus();
                return false;
            }
            //if (this.cmbTipoUsuario.Text.Trim().Length <= 0)
            {
                // MessageBox.Show("El Tipo de Usuario no puede estar en blanco");
                // this.DialogResult = DialogResult.None;
                //this.txtConfirmarContraseña.Focus();
                // return false;
            }


            return true;
        }

        bool GuardarDatos()
        {
            bool ret = false;
           // SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True");
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.CommandText = "GUARDAR_USUARIO"; //NOMBRE DEL PROCE. ALMACENADO
            string claveencriptada = CryptorEngine.Encrypt(txtContraseña.Text, true);

            cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@Contrasena", claveencriptada);
            cmd.Parameters.AddWithValue("@Permisos", GetPermiso());
            cmd.Parameters.AddWithValue("@Grupo", GetGrupo());



            cmd.Parameters.Add("@Salida", SqlDbType.Int);
            cmd.Parameters["@Salida"].Direction = ParameterDirection.Output; //se debe especificar que es output

            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100);
            cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output; //se debe especificar que es output

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Salida"].Value != null)
                {
                    int v = 0;
                    int.TryParse(cmd.Parameters["@Salida"].Value.ToString(), out v);
                    if (v == 0)
                        ret = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ret = false;
            }
            finally
            {
                conn.Close();
            }
            return ret;
        }


        private void Guardar_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True");

            this.AcceptButton = Guardar;


            // if (ValidarUsuario())
            {

                if (ValidarCampos() == ValidarUsuarioRepetido())
                {

                    if (GuardarDatos())
                    {
                        MessageBox.Show("Informacion Guardada Satisfactoriamente.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        this.DialogResult = DialogResult.No;
                }

            }
             
         
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
