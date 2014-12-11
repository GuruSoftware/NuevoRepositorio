using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login frm = new Login();
            Application.Run(frm);
           /* if (frm.DialogResult == DialogResult.OK)
            {
                Session session = frm.Session;
                frm.Dispose();

                Application.Run(new Inicio (session));
            }
            */                


        }


    }
}


