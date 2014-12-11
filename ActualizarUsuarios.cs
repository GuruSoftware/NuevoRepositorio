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
    public partial class ActualizarUsuarios : Form
    {

        private string valor;
        public ActualizarUsuarios(string valor)
        {
            InitializeComponent();
            this.valor = valor;
            GetEstudianteInfo();
        }

        void GetEstudianteInfo()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Codigo, Capacidad, Centro FROM tblAulas WHERE Codigo=" + this.Codigo;
            cmd.CommandText = "SELECT ID, Usuario, Contrasena, Grupo FROM tblUsuarios WHERE ID=@ID";
            cmd.Parameters.AddWithValue("@ID", valor);
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

                        this.button1.Text = r.GetInt32(0).ToString(); 
                        this.txtUsuario.Text = r.GetString(1);
                        this.txtContraseña.Text = ClaveSinEncriptar;
                        this.txtConfirmarContraseña.Text = ClaveSinEncriptar;
                      //  this.cmbTipoUsuario.Text = r.GetPermiso(3).ToString();

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
        bool ValidarCampos()
        {

            if (this.txtUsuario.Text.Trim().Length <= 0)
            {
                SystemSounds.Beep.Play();
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
        


            return true;
        }

        bool ValidarUsuario() // Este metodo valida si la cedula que se esta ingresando existe en la base de datos
        {
            DataTable dt = new DataTable();
           // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand("select Usuario from tblUsuarios", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {


                    if (txtUsuario.Text.Trim() == rdr.GetString(0))
                    {
                        MessageBox.Show("El Usuario ya existe en el registro ", "Registro Duplicado");
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

        private void Guardar_Click(object sender, EventArgs e)
        {
            this.AcceptButton = Guardar; 
           // SystemSounds.Exclamation.Play();
             DataTable dt = new DataTable();
           // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
             SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

            if (lblID.Text.Contains("NUEVO"))
            {

                if (ValidarCampos() == true && ValidarUsuario() == true)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblUsuarios (Usuario, Contrasena, Grupo, Permisos)" +
                                                        " VALUES (@Usuario, @Contrasena, @Grupo , @Permisos);", conn);

                        string claveencriptada = CryptorEngine.Encrypt(txtContraseña.Text, true);

                        cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                        cmd.Parameters.AddWithValue("@Contrasena", claveencriptada);
                        cmd.Parameters.AddWithValue("@Grupo", GetGrupo());
                        cmd.Parameters.AddWithValue("@Permisos", GetPermiso());

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
                        this.Close();
                    }

                }
            }

            else
            {


                try
                {

                    SqlCommand cmd = new SqlCommand("UPDATE tblUsuarios SET Usuario = @Usuario, Contrasena = @Contrasena, Grupo = @Grupo , Permisos=@Permisos WHERE ID = @ID", conn);

                    string claveencriptada = CryptorEngine.Encrypt(txtContraseña.Text, true);

                    cmd.Parameters.AddWithValue("@ID", valor);
                    cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@Contrasena", claveencriptada);
                    cmd.Parameters.AddWithValue("@Grupo", this.GetGrupo());
                    cmd.Parameters.AddWithValue("@Permisos", GetPermiso());


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
                    this.Close();
                }


            }
        }

        private String GetPermiso()
        {
            string permiso = String.Empty;

            if (this.Administrador.Checked)
            {
                permiso = permiso + ";1;2;3;4;5;6;7;8;9;10;11;12;";
            }
            if (this.Registro.Checked)
            {
                permiso = permiso + ";2;3;4;5;6;7;8;9;11;";
            }
            if (this.cajero.Checked)
            {
                permiso = permiso + ";10;";
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
            if (this.Registro.Checked)
            {
                Grupo = Grupo + "Registro";
            }
            if (this.cajero.Checked)
            {
                Grupo = Grupo + "Cajero";
            }





            return Grupo;
        }


        private void Eliminar_Click(object sender, EventArgs e)
        {
            
            DialogResult resul = MessageBox.Show("Seguro que quiere eliminar a " + txtUsuario.Text  , "Eliminar Registro", MessageBoxButtons.YesNo);
           // MessageBox.Show(" " + Usuario.Text, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
            if (resul == DialogResult.Yes)
            {

                DataTable dt = new DataTable();
                // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
                SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

                SqlCommand cmd = new SqlCommand("DELETE FROM tblUsuarios WHERE Id= @ID", conn);

                cmd.Parameters.AddWithValue("@ID", valor);

                SqlDataAdapter a = new SqlDataAdapter(cmd);
                MessageBox.Show("El Usuario ha sido borrado!");
                conn.Open();
                a.Fill(dt);
                conn.Close();
            }

           
            SystemSounds.Beep.Play();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
           // SystemSounds.Beep.Play();
            this.Close();
        }

        private void ActualizarUsuario_Load(object sender, EventArgs e)
        {
            this.AcceptButton = Guardar; 
        }

        


    }
}
