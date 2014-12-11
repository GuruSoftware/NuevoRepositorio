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
    public partial class frmCuadre : Form
    {
        public frmCuadre()
        {
            InitializeComponent();
            GetTotal();
            GetDatosUsuario();

        }


        void GetTotal()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            txtFecha.Text = DateTime.Now.ToShortDateString();


            cmd.CommandText = "SELECT SUM (Monto) FROM tblFactura WHERE Fecha=@Fecha";

            cmd.Parameters.AddWithValue("@Fecha", txtFecha.Text);

            SqlDataReader r;
            try
            {
                conn.Open();
                r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        // this.txtID.Text = r.GetInt32(0).ToString();// pa un ID 
                        // this.txtCodigo.Text = r.GetString(0);
                        this.txtTotalCaja.Text = r.GetDecimal(0).ToString();


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

        void GetDatosUsuario()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            // cmd.CommandText = "SELECT Usuario, Descripcion, PrecioVenta , Referencia FROM tblArticulos WHERE Referencia=@Referencia or CodigoDeBarra=@CodigoDeBarra";
            cmd.CommandText = "SELECT Usuario FROM tblControlEntrada WHERE ID = (SELECT MAX(ID) from tblControlEntrada)";


            SqlDataReader r;
            try
            {
                conn.Open();
                r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        this.txtCajero.Text = r.GetString(0);


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


        void actualizaTotal()
        {
            int valor = int.Parse(txtSuma1.Text) + int.Parse(txtSuma5.Text) + int.Parse(txtSuma10.Text) + int.Parse(txtSuma20.Text) + int.Parse(txtSuma25.Text) + int.Parse(txtSuma50.Text) + int.Parse(txtSuma100.Text) + int.Parse(txtSuma200.Text) + int.Parse(txtSuma500.Text) + int.Parse(txtSuma1000.Text) + int.Parse(txtSuma2000.Text);
            txtTotal.Text = valor.ToString();

        }

        void CalculaDescuadre()
        {
            decimal valor = decimal.Parse(this.txtTotal.Text) - decimal.Parse(this.txtTotalCaja.Text);
            this.txtFaltante.Text = valor.ToString();

        }


        bool ValidarCampos1()
        {

            if (this.txt1.Text.Trim().Length <= 0)
            {

                MessageBox.Show("Este Campo no puede Estar en Blanco");
                this.DialogResult = DialogResult.None;
                this.txt1.Focus();
                return false;
            }
            return true;
        }


        bool ValidarCampos5()
        {

            if (this.txt5.Text.Trim().Length <= 0)
            {

                MessageBox.Show("Este Campo no puede Estar en Blanco");
                this.DialogResult = DialogResult.None;
                this.txt5.Focus();
                return false;
            }
            return true;
        }

        void suma1()
        {
                int y = int.Parse(txt1.Text);
                int mult = 1 * y;

                if (mult >= 0)
                    txtSuma1.Text = Convert.ToString(mult);
                actualizaTotal();
                CalculaDescuadre();
                this.ActiveControl = this.txt5;

            
        
        }

        void suma5()
        {

            int y = int.Parse(txt5.Text);
            int mult = 5 * y;

            if (mult >= 0)
                txtSuma5.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt10;

        }

        void suma10()
        {

            int y = int.Parse(txt10.Text);
            int mult = 10 * y;

            if (mult >= 0)
                txtSuma10.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt20;

        }

        void suma20()
        {

            int y = int.Parse(txt20.Text);
            int mult = 20 * y;

            if (mult >= 0)
                txtSuma20.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt25;

        }

        void suma25()
        {

            int y = int.Parse(txt25.Text);
            int mult = 25 * y;
             
            if (mult >= 0)
                txtSuma25.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt50;

        }

        void suma50()
        {

            int y = int.Parse(txt50.Text);
            int mult = 50 * y;

            if (mult >= 0)
                txtSuma50.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt100;

        }

        void suma100()
        {

            int y = int.Parse(txt5.Text);
            int mult = 100 * y;

            if (mult >= 0)
                txtSuma100.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt200;

        }

        void suma200()
        {

            int y = int.Parse(txt200.Text);
            int mult = 200 * y;

            if (mult >= 0)
                txtSuma200.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt500;

        }

        void suma500()
        {

            int y = int.Parse(txt500.Text);
            int mult = 500 * y;

            if (mult >= 0)
                txtSuma500.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt1000;

        }


        void suma1000()
        {

            int y = int.Parse(txt1000.Text);
            int mult = 1000 * y;

            if (mult >= 0)
                txtSuma1000.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
            this.ActiveControl = this.txt2000;

        }

        void suma2000()
        {

            int y = int.Parse(txt5.Text);
            int mult = 2000 * y;

            if (mult >= 0)
                txtSuma2000.Text = Convert.ToString(mult);
            actualizaTotal();
            CalculaDescuadre();
           // this.ActiveControl = this.txt5;

        }
        private void frmCuadre_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtHora.Text = DateTime.Now.ToShortTimeString();

        }

       

        

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma1();
                    break;
            }   
        }

        private void txt1_Click(object sender, EventArgs e)
        {
            this.txt1.Text = string.Empty;
            this.txtSuma1.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt5_Click(object sender, EventArgs e)
        {
            this.txt5.Text = string.Empty;
            this.txtSuma5.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt10_Click(object sender, EventArgs e)
        {
            this.txt10.Text = string.Empty;
            this.txtSuma10.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt20_Click(object sender, EventArgs e)
        {
            this.txt20.Text = string.Empty;
            this.txtSuma20.Text = "0";
            actualizaTotal();
            CalculaDescuadre();

        }

        private void txt25_Click(object sender, EventArgs e)
        {
            this.txt25.Text = string.Empty;
            this.txtSuma25.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt50_Click(object sender, EventArgs e)
        {
            this.txt50.Text = string.Empty;
            this.txtSuma50.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt100_Click(object sender, EventArgs e)
        {
            this.txt100.Text = string.Empty;
            this.txtSuma100.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt200_Click(object sender, EventArgs e)
        {
            this.txt200.Text = string.Empty;
            this.txtSuma200.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt500_Click(object sender, EventArgs e)
        {
            this.txt500.Text = string.Empty;
            this.txtSuma500.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt1000_Click(object sender, EventArgs e)
        {
            this.txt1000.Text = string.Empty;
            this.txtSuma1000.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt2000_Click(object sender, EventArgs e)
        {
            this.txt2000.Text = string.Empty;
            this.txtSuma2000.Text = "0";
            actualizaTotal();
            CalculaDescuadre();
        }

        private void txt5_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma5();
                    break;
            }   
        }

        private void txt10_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma10();
                    break;
            }   

        }

        private void txt20_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma20();
                    break;
            }   

        }

        private void txt25_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma25();
                    break;
            }   
        }

        private void txt50_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma50();
                    break;
            }   
        }

        private void txt100_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma100();
                    break;
            }   
        }

        private void txt200_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma200();
                    break;
            }   
        }

        private void txt500_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma500();
                    break;
            }   
        }

        private void txt1000_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma1000();
                    break;
            }   
        }

        private void txt2000_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    suma2000();
                    break;
            }   
        }

        private void txt1_Leave(object sender, EventArgs e)
        {
            suma1();
        }

      
       
        

       

    }
}
