using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class frmComprobante : Form
    {
        
        public frmComprobante()
        {
            InitializeComponent();
            Serie.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
              string sql = string.Format("update configCodigo set Serie='{0}',DiviciondeNegocio='{1}',PuntoDeEmicion='{2}',AreaDeImpresion='{3}',Limite={4} where Id=1",
                Serie.Text,DivicionDeNegocio.Value,PuntoDeEmicion.Value,AreaDeImpresion.Value,Limite.Value);
                DataBase.ExecuteNonQuery(sql);

            

        }

        private void Probar_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select Serie,DiviciondeNegocio,PuntoDeEmicion,AreaDeImpresion,Limite from configCodigo where Id=1");
           DataRow row= DataBase.GetSet(sql).Rows[0];
           Prueba.Text = Comprobante.GenerarCodigo(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), row.ItemArray[2].ToString(), row.ItemArray[3].ToString(), ((int)Comprobante.Tipo.ConsumidoresFinales).ToString(), (DataBase.GetSet("select * from tblFactura").Rows.Count + 1).ToString());
        }

        private void Serie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
