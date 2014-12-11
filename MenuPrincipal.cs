using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    class MenuPrincipal
    {
         MenuStrip menu;
         ToolStrip barra;

         public MenuPrincipal(ToolStrip barra)
         {
             this.barra = barra;
         }


        public MenuPrincipal(MenuStrip menu)
        {
            this.menu = menu;
        }
        /// <summary>
        /// Actualiza las opciones del menu principal del sistema
        /// </summary>
        /// <param name="permisos">
        /// El listado de permisos separados por ; Ejemplo: 100;200;300;
        /// </param>
        public void UpdateMenuItems(string permisos)
        {
            this.UpdateDropDownItems(this.menu.Items, permisos);
        }

      
        /// <summary>
        /// Actualiza los sub menu
        /// </summary>
        /// <param name="permisos">
        /// Indica un string de permisos a usarse para el menu principal
        /// </param>
        // ;100;200;102;103;104;3000;
       




       // ;100;200;102;103;104;3000;
        private void UpdateDropDownItems(ToolStripItemCollection items, string permisos)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Tag != null)
                {
                        string key = ";"+item.Tag.ToString()+";";
                        switch (key)
                        {
                            case ";0;":
                                item.Enabled = true;
                                break;
                            case ";1010;":
                                item.Enabled = true; //Desactivando a conectarse.
                                break;
                            case ";1020;":
                                item.Enabled = true; //Desactivando a conectarse.
                                break;
                            case ";1030;":
                                item.Enabled = true; //Desactivando a conectarse.
                                break;
                            case ";2000;":
                                item.Visible = true;
                                break;
                            case ";3000;":
                                item.Visible = true;
                                break;
                            case ";4000;":
                                item.Visible = true;
                                break;
                            case ";5000;":
                                item.Visible = true;
                                break;
                            default:
                                //-
                                // Para desactivar/activar los otros items estudiante ;100;101;103;104;200;210;500;501; cajero ;100;101;103;104;200;209;500;501;
                                //--------------------------------------------------
                                if (permisos.IndexOf(key) < 0)
                                {
                                    item.Enabled = false;
                                    //item.Visible = false;
                                }
                                else
                                {
                                    item.Enabled = true;
                                    //item.Visible = true;
                                }
                                break;
                        }
                }
                ToolStripMenuItem mnu = new ToolStripMenuItem();
                try
                {
                    mnu = (ToolStripMenuItem)item;
                }
                catch { }
                finally
                {
                    if (mnu.HasDropDownItems && mnu.Enabled)
                        UpdateDropDownItems(mnu.DropDownItems, permisos);
                }

            }
        }
    }
}
