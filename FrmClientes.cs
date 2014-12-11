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
    public partial class FrmClientes : Form
    {

        private DataTable dt = new DataTable();
        ArrayList arreglo = new ArrayList();

        private SqlDataAdapter adapter;
        private SqlConnection conexion;
        private SqlCommand cmd;
        string strConn = string.Empty;
        private int ID = 0;


        public FrmClientes()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        bool ValidarCampos()
        {

            if (this.txtNombre.Text.Trim().Length <= 0)
            {
               
                MessageBox.Show("El Nombre no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtNombre.Focus();
                errorProvider1.SetError(txtNombre,"");
                return false;
            }

           



            return true;
        }



        bool GuardarDatos()
        {
            

            bool ret = false;
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF-522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.CommandText = "Guardar_Clientes"; //NOMBRE DEL PROCE. ALMACENADO

            cmd.Parameters.AddWithValue("@ID", this.ID);
            cmd.Parameters.AddWithValue("@Nombres", txtNombre.Text.TrimEnd());






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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF-522 ;Integrated Security=True");

           // if (this.txtCodigo.Text.Contains("NUEVO"))
            {

                if (ValidarCampos() == true)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblClientes (Nombre, Apellido, Cedula, Direccion , Email , Balance)" +
                                                        " VALUES (@Nombre, @Apellido, @Cedula , @Direccion , @Email , @Balance);", conn);

                        
                        int z = 0;
                        cmd.Parameters.AddWithValue("@Nombre", this.txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", this.txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Cedula", this.txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Direccion", this.txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Email", this.txtNombre.Text);
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
                        this.Close();
                    }

                }
            }


            }

        }

       
            
        
       
}
    