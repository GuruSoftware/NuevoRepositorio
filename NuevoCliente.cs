using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Media;
using System.Collections;
using System.IO;

namespace PuntoDeVenta
{
    public partial class NuevoCliente : Form
    {
        private DataTable dt = new DataTable();
        ArrayList arreglo = new ArrayList();

        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;
        private int ID = 0;


        public NuevoCliente()
        {
            InitializeComponent();
        }



        bool ValidarCampos()
        {

            if (this.txtNombre.Text.Trim().Length <= 0)
            {

                MessageBox.Show("El Nombre no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
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


      


        private void btnGuardar_Click(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");

           // if (this.txtCodigo.Text.Contains("NUEVO"))
            {

                if (ValidarCampos() == true)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblClientes (Nombre, Apellido, Cedula, Direccion , Email , Balance , Telefono , Movil1 , Movil2 , Observacion )" +
                                                        " VALUES (@Nombre, @Apellido, @Cedula , @Direccion , @Email , @Balance , @Telefono , @Movil1, @Movil2 , @Observacion);", conn);

                        
                        int z = 0;
                        cmd.Parameters.AddWithValue("@Nombre", this.txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", this.txtApellido.Text);
                        cmd.Parameters.AddWithValue("@Cedula", this.txtCedula.Text);
                        cmd.Parameters.AddWithValue("@Telefono", this.txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@Direccion", this.txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@Email", this.txtEnail.Text);
                        cmd.Parameters.AddWithValue("@Movil1", this.txtMovil1.Text);
                        cmd.Parameters.AddWithValue("@Movil2", this.txtMovil2.Text);
                        cmd.Parameters.AddWithValue("@Observacion", this.txtObservacion.Text);
                        cmd.Parameters.AddWithValue("@Balance", z.ToString() );

                        

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

                    
                    {
                        SystemSounds.Exclamation.Play();

                        MessageBox.Show("Informacion Guardada Satisfactoriamente.");
                        this.DialogResult = DialogResult.OK;
                      //  this.Close();
                    }

                }
            }


            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuardar;


        }


    }
}
