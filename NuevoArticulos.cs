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
    public partial class NuevoArticulos : Form
    {
        public NuevoArticulos()
        {
            InitializeComponent();
        }

        private void NuevoArticulos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'iNF_522_DataSet.tblSuplidor' Puede moverla o quitarla según sea necesario.
            this.tblSuplidorTableAdapter.Fill(this.iNF_522_DataSet.tblSuplidor);
            AcceptButton = Guardar;

        }

        bool ValidarCampos()
        {

            if (this.txtCodigo.Text.Trim().Length <= 0)
            {

                MessageBox.Show("El Codigo no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtCodigo.Focus();
                return false;
            }


            if (this.txtDescripcion.Text.Trim().Length <= 0)
            {

                MessageBox.Show("La Descripcion no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtDescripcion.Focus();
                return false;
            }


            if (this.txtUnidad.Text.Trim().Length <= 0)
            {

                MessageBox.Show("la Unidad no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtUnidad.Focus();
                return false;
            }

            if (this.txtPrecio.Text.Trim().Length <= 0)
            {

                MessageBox.Show("El Precio de la Venta no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtPrecio.Focus();
                return false;
            }


            if (this.txtCantidad.Text.Trim().Length <= 0)
            {

                MessageBox.Show("La Cantidad no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtCantidad.Focus();
                return false;
            }


            if (this.txtDepartamento.Text.Trim().Length <= 0)
            {

                MessageBox.Show("El Departamento no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtDepartamento.Focus();
                return false;
            }


            if (this.txtCosto.Text.Trim().Length <= 0)
            {

                MessageBox.Show("El Costo no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtCosto.Focus();
                return false;
            }



            if (this.txtProveedor.Text.Trim().Length <= 0)
            {

                MessageBox.Show("El Proveedor no puede estar en blanco.");
                this.DialogResult = DialogResult.None;
                this.txtProveedor.Focus();
                return false;
            }


            return true;
        }



         bool ValidarCodigo() // Este metodo valida si la cedula que se esta ingresando existe en la base de datos
        {
            DataTable dt = new DataTable();
            // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
           // SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True");
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand("select CodigoDeBarra from tblArticulos", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {


                    if (txtCodigo.Text.Trim() == rdr.GetString(0))
                    {
                        MessageBox.Show("El Codigo ya existe en el registro ", "Registro Duplicado");
                        this.DialogResult = DialogResult.None;
                        this.txtCodigo.Focus();
                        return false;
                    }
                }
                rdr.Close();
            }
            conn.Close();

            return true;

        }

         bool ValidarReferencia() // Este metodo valida si la cedula que se esta ingresando existe en la base de datos
         {
             DataTable dt = new DataTable();
             // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
             // SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True");
             SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");

             conn.Open();
             SqlCommand cmd = new SqlCommand("select Referencia from tblArticulos", conn);
             SqlDataReader rdr = cmd.ExecuteReader();

             if (rdr.HasRows)
             {
                 while (rdr.Read())
                 {


                     if (txtReferencia.Text.Trim() == rdr.GetString(0))
                     {
                         MessageBox.Show("La Referencia ya existe en el registro ", "Registro Duplicado");
                         this.DialogResult = DialogResult.None;
                         this.txtReferencia.Focus();
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
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");

            // if (this.txtCodigo.Text.Contains("NUEVO"))
            {

                if (ValidarCampos() == true && ValidarCodigo() ==true && ValidarReferencia ()== true )
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblArticulos (CodigoDeBarra , Referencia , Descripcion , Unidad , PrecioVenta , Cantidad, Departamento , Costo , Proveedor    )" +
                                                        " VALUES (@CodigoDeBarra, @Referencia ,@Descripcion , @Unidad , @PrecioVenta , @Cantidad, @Departamento , @Costo , @Proveedor    );", conn);


                      
                        cmd.Parameters.AddWithValue("@CodigoDeBarra", this.txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@Referencia", this.txtReferencia.Text);
                        cmd.Parameters.AddWithValue("@Descripcion", this.txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@Unidad", this.txtUnidad.Text);
                        cmd.Parameters.AddWithValue("@PrecioVenta", this.txtPrecio.Text);
                        cmd.Parameters.AddWithValue("@Cantidad", this.txtCantidad.Text);
                        cmd.Parameters.AddWithValue("@Departamento", this.txtDepartamento.Text);
                        cmd.Parameters.AddWithValue("@Costo", this.txtCosto.Text);
                        cmd.Parameters.AddWithValue("@Proveedor", this.txtProveedor.Text);
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
