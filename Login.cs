using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using System.Threading;
using System.Drawing.Text;

namespace PuntoDeVenta
{
    public partial class Login : Form
    {
        public string user { set; get; }
        private Session session;
        public Session Session
        {
            set { session = value; }
            get { return session; }
        }


        public Login()
        {
            InitializeComponent();
            session = new Session();
        }

        private string permisos = string.Empty;
        /// <summary>
        /// Retorna los permisos del usuario despues de validado.
        /// </summary>
        public string Permisos
        {
            get { return permisos; }
        }



        bool ValidarCampos()
        {
            if (Usuario.Text.Trim().Length <= 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Por favor digite el usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Usuario.Focus();
                return false;

            }
            if (Password.Text.Trim().Length <= 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Por favor digite la contraseña", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Focus();
                return false;
            }


            return true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            user = this.Usuario.Text; // pasandole el txtUsuario al la factura

            //frmWait w = new frmWait();
            //  w.Show();


            // if (Usuario.Text.Trim().Length <= 0)
            {
                // SystemSounds.Exclamation.Play();
                // MessageBox.Show("Por favor digite el usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Usuario.Focus();
                // return;

            }
            // if (Password.Text.Trim().Length <= 0)
            {
                //   SystemSounds.Exclamation.Play();
                // // MessageBox.Show("Por favor digite la contraseña", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  Password.Focus();
                //  return;
            }
            if (ValidarCampos() == true)
            {
                bool exito = false;
                SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                string sql = "SELECT Usuario,Contrasena, Permisos, ID FROM tblUsuarios WHERE Usuario='" + Usuario.Text + "';";
                string claveDesencriptada;


                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            claveDesencriptada = PuntoDeVenta.CryptorEngine.Decrypt(reader.GetString(1), true);
                            if (Usuario.Text.Equals(reader.GetString(0)) && Password.Text.Equals(claveDesencriptada))

                            //mi if anterior version 1.0
                            //  if (Usuario.Text.Equals(reader.GetString(0)) && Password.Text.Equals(reader.GetString(1)))
                            {
                                permisos = reader.GetString(2);
                                this.session.Permisos = reader.GetString(2);
                                this.session.Login = reader.GetString(0);
                                this.session.UserID = reader.GetInt32(3).ToString();

                                Cursor.Current = Cursors.WaitCursor;
                                exito = true;

                                SystemSounds.Asterisk.Play();
                                InsertarEntrada();//pa entrar el usuario 
                                 MessageBox.Show(" " + Usuario.Text, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Visible = false;
                                new Inicio(session).ShowDialog();
                            }
                            reader.NextResult();
                        }

                    }
                    else
                    {
                        exito = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                if (!exito)
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("Usuario/Contraseña Inválidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        void InsertarEntrada()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=Mayelin\SQLEXPRESS;Initial Catalog=INF522 ;Integrated Security=True");

            {

                //   if (ValidarCampos() == true)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblControlEntrada (Usuario, Fecha , Hora )" +
                                                       " VALUES (@Usuario, @Fecha, @Hora  );", conn);

                        cmd.Parameters.AddWithValue("@Usuario", this.Usuario.Text);
                        cmd.Parameters.AddWithValue("@Fecha", this.txtFecha.Text);
                        cmd.Parameters.AddWithValue("@Hora", this.txtHora.Text);

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

                        // MessageBox.Show("Compra Realizada Satisfactoriamente.");
                        this.DialogResult = DialogResult.OK;

                    }


                }// FIN DEL IF 
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            AcceptButton = button2;
            txtFecha.Text = DateTime.Now.ToShortDateString();
           txtHora.Text = DateTime.Now.ToShortTimeString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmComprobante().ShowDialog();
        }

    }
}
