using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    class DataBase
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");
        public static DataTable GetSet(String consulta)
        {
            SqlCommand comando = new SqlCommand(consulta, Connection);
            SqlDataAdapter a = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            try
            {
                comando.Connection.Open();
                a.Fill(dt);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { comando.Connection.Close(); }

            return dt;
        }
        public static void ExecuteNonQuery(string consulta)
        {
            SqlCommand comando = new SqlCommand(consulta, Connection);

            DataTable dt = new DataTable();
            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { comando.Connection.Close(); }

        }

        public static void ExecuteNonQuery(string consulta, int Return)
        {
            SqlCommand comando = new SqlCommand(consulta, Connection);

            DataTable dt = new DataTable();
            try
            {
                comando.Connection.Open();
                Return = comando.ExecuteNonQuery();
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { comando.Connection.Close(); }


        }
        public static void ExecuteNonQuery(SqlCommand cmd)
        {
            SqlCommand comando = cmd;

            DataTable dt = new DataTable();
            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { comando.Connection.Close(); }

        }


        public static void Fill(string Query, DataTable Table)
        {
            SqlCommand comando = new SqlCommand(Query, Connection);
            SqlDataAdapter a = new SqlDataAdapter(comando);

            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                a.Fill(Table);
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { comando.Connection.Close(); }

        }
    }
}
