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
    public partial class frmPrueba : Form
    {

        private string valor;

        public frmPrueba(string valor)
        {
            InitializeComponent();
            this.valor = valor;
            GetDatos2();
        }

        void GetDatos2()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT CodigoDeBarra, Descripcion, PrecioVenta FROM tblArticulos WHERE CodigoDeBarra=@CodigoDeBarra  ";

            cmd.Parameters.AddWithValue("@CodigoDeBarra", valor);

            SqlDataReader r;
            try
            {
                conn.Open();
                r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        this.txtCodigo.Text = r.GetString(0);

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









    }
}
