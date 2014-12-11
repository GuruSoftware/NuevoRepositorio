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

namespace PuntoDeVenta
{
    public partial class FrmBackup : Form
    {
        private SqlCommand cmd;
        string strConn = string.Empty;

        public FrmBackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// BACKUP COMPLETO
        {
            this.Cursor = Cursors.WaitCursor;
            // SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connStr"]);
            SqlConnection conn = new SqlConnection("Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");
            //  strConn = @"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True";
            SqlCommand cmd = new SqlCommand(string.Format(@"BACKUP DATABASE INF522 TO DISK = 'D:\PDV_COMPLETO.Bak' WITH FORMAT, NAME = 'Full Backup of INF522';", "INF522"), conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("BackUp Finalizado Exitosamente! ");
        }


        private void btnBackup_Click(object sender, EventArgs e)// BACKUP DIFERENCIAL
        {
            this.Cursor = Cursors.WaitCursor;
            // SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connStr"]);
            SqlConnection conn = new SqlConnection("Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");
            //  strConn = @"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True";
            SqlCommand cmd = new SqlCommand(string.Format(@"BACKUP DATABASE INF522 TO DISK = 'D:\{0}.bak' WITH DIFFERENTIAL;", "PDV_DIFERENCIAL"), conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("BackUp Finalizado Exitosamente! ");

        }
    }
}
