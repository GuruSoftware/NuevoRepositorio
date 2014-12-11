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
    public partial class ActualizarClientes : Form
    {

        private string valor;

        public ActualizarClientes(string valor)
        {
            InitializeComponent();
            this.valor = valor;
            GetEstudianteInfo();
        }

        /*SqlCommand cmd = new SqlCommand("UPDATE tblClientes SET  Nombre=@Nombre, Apellido=@Apellido, Cedula=@Cedula, Direccion=@Direccion , Email=@Email , Telefono=@Telefono , Movil1=@Movil1, Movil2=@Movil2, Observacion=@Observacion  WHERE ID = @ID", conn);


                        cmd.Parameters.AddWithValue("@ID", valor);
                        cmd.Parameters.AddWithValue("@Nombre", this.txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", this.txtApellido.Text);
                        cmd.Parameters.AddWithValue("@Cedula", this.txtCedula.Text);
                        cmd.Parameters.AddWithValue("@Direccion", this.txtCedula.Text);
                        cmd.Parameters.AddWithValue("@Email", this.txtEnail.Text);
                        cmd.Parameters.AddWithValue("@Telefono", this.txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@Movil1", this.txtMovil1.Text);
                        cmd.Parameters.AddWithValue("@Movil2", this.txtMovil2.Text);
                        cmd.Parameters.AddWithValue("@Observacion", this.txtObservacion.Text);
                        */

         bool ValidarCampos()
        {
            if (this.txtNombre.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe digitar el Nombre");
                this.txtNombre.Focus();
                return false;
            }

            if (this.txtApellido.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe digitar el Apellido");
                this.txtApellido.Focus();
                return false;
            }


            if (this.txtCedula.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe digitar la Cedula");
                this.txtCedula.Focus();
                return false;
            }

            if (this.txtTelefono.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe digitar el Telefono");
                this.txtTelefono.Focus();
                return false;
            }

            if (this.txtDireccion.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe digitar la Direccion");
                this.txtDireccion.Focus();
                return false;
            }





            return true;
        }



        void GetEstudianteInfo()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Codigo, Capacidad, Centro FROM tblAulas WHERE Codigo=" + this.Codigo;
            // cmd.CommandText = " SELECT Usuario from tblUsuariosWHERE ID= @ID";
            cmd.CommandText = "SELECT ID, Nombre, Apellido, Cedula, Direccion , Email , Telefono , Movil1, Movil2, Observacion  FROM tblClientes WHERE ID=@ID";
           
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

                         this.txtID.Text = r.GetInt32(0).ToString();// pa un ID 
                        this.txtNombre.Text = r.GetString(1);
                        this.txtApellido.Text = r.GetString(2);
                        this.txtCedula.Text = r.GetString(3);
                        this.txtDireccion.Text = r.GetString(4);
                        this.txtEnail.Text = r.GetString(5);
                        this.txtTelefono.Text = r.GetString(6);
                        this.txtMovil1.Text = r.GetString(7);
                        this.txtMovil2.Text = r.GetString(8);
                        this.txtObservacion.Text = r.GetString(9);


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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // this.AcceptButton = Guardar;
            // SystemSounds.Exclamation.Play();
            DataTable dt = new DataTable();
            // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

            if (this.txtID.Text.Contains("NUEVO"))
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
                        this.Close();
                    }

                }
            }

            else
            {


                try
                {

                    SqlCommand cmd = new SqlCommand("UPDATE tblClientes SET  Nombre=@Nombre, Apellido=@Apellido, Cedula=@Cedula, Direccion=@Direccion , Email=@Email , Telefono=@Telefono , Movil1=@Movil1, Movil2=@Movil2, Observacion=@Observacion  WHERE ID = @ID", conn);


                    cmd.Parameters.AddWithValue("@ID", valor);
                    cmd.Parameters.AddWithValue("@Nombre", this.txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Apellido", this.txtApellido.Text);
                    cmd.Parameters.AddWithValue("@Cedula", this.txtCedula.Text);
                    cmd.Parameters.AddWithValue("@Direccion", this.txtCedula.Text);
                    cmd.Parameters.AddWithValue("@Email", this.txtEnail.Text);
                    cmd.Parameters.AddWithValue("@Telefono", this.txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Movil1", this.txtMovil1.Text);
                    cmd.Parameters.AddWithValue("@Movil2", this.txtMovil2.Text);
                    cmd.Parameters.AddWithValue("@Observacion", this.txtObservacion.Text);




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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            DialogResult resul = MessageBox.Show("Seguro que quiere eliminar a " + this.txtNombre.Text, "Eliminar Registro", MessageBoxButtons.YesNo);
            // MessageBox.Show(" " + Usuario.Text, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (resul == DialogResult.Yes)
            {

                DataTable dt = new DataTable();
                // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
                SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");

                SqlCommand cmd = new SqlCommand("DELETE FROM tblClientes WHERE ID= @ID", conn);

                cmd.Parameters.AddWithValue("@ID", valor);

                SqlDataAdapter a = new SqlDataAdapter(cmd);

                conn.Open();
                a.Fill(dt);
                conn.Close();

                MessageBox.Show("El Cliente ha sido borrado!");
            }

            
            SystemSounds.Beep.Play();
            this.DialogResult = DialogResult.OK;
            this.Close();
        
        }




    }
}
