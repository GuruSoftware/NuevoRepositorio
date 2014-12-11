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
    public partial class frmDescuento : Form
    {
        public string desc { set; get; } 



        public frmDescuento()
        {
            InitializeComponent();
        }

        private bool ValidarCampos()
        {
            if (this.txtDescuento.Text.Trim().Length <= 0)
            {
                MessageBox.Show("El Campo de Descuento no Puede Estar en Blanco");
                this.txtDescuento.Focus();
                return false;
            }




            return true;
        }

    

        private void btnAcepar_Click(object sender, EventArgs e)
        {

            
           // int max=10;
            int Descuento;
            Descuento = Convert.ToInt32(txtDescuento.Text);


            if (Descuento > 10)
            {
                MessageBox.Show("El Descuento No puede Ser de Mas de 10%");

                txtDescuento.Focus();
            }



            else if (Descuento < 0)
                {
                    MessageBox.Show("El Descuento No puede Ser Menor de 0%");

                    txtDescuento.Focus();

                }

            else  if (ValidarCampos() == true)
                {

                    desc = this.txtDescuento.Text;

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();


                }

            
        }

        private void frmDescuento_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtDescuento;
            AcceptButton = btnAcepar;
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten NUMEROS");
                e.Handled = true;
                return;


            }

        }
    }
}
