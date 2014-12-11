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
    public partial class NuevoCotizacion : Form
    {
        private string valor;

        public NuevoCotizacion(string valor)
        {
            InitializeComponent();
            this.valor = valor;
          
        }

        void GetDatos() 
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT CodigoDeBarra, Descripcion, PrecioVenta , Referencia FROM tblArticulos WHERE Referencia=@Referencia or CodigoDeBarra=@CodigoDeBarra";

            cmd.Parameters.AddWithValue("@Referencia", txtCodigo.Text);
            cmd.Parameters.AddWithValue("@CodigoDeBarra", txtCodigo.Text);
          
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
                        this.txtCodigo.Text = r.GetString(0);
                        this.txtDescripcion.Text = r.GetString(1);
                        this.txtPrecio.Text = r.GetInt32(2).ToString();
                        this.txtReferencia.Text = r.GetString(3); 


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





        private void FrmVentas_KeyDown(object sender, KeyEventArgs e)
        {
        //////////////////////////////////////////////////////////////////////////////
            switch (e.KeyCode)
            {
                case Keys.F1:
                    if (ValidarCamposAgregar() == true)
                    {
                        btnAgregar_Click(null, null);
                    }
                 break;

       //////////////////////////////////////////////////////////////////////////////
                case Keys.F2:
                 FrmBuscarArticulo f = new FrmBuscarArticulo();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtCodigo.Text = f.valor;
            }
                 break;
         //////////////////////////////////////////////////////////////////////////////
                case Keys.Enter:
                 if (ValidarCamposAgregar() == true)
                 {
                     btnAgregar_Click(null, null);
                 }
                 break;
        //////////////////////////////////////////////////////////////////////////////
                case Keys.F3:
                 btnAnular_Click(null, null);
                 break;
      //////////////////////////////////////////////////////////////////////////////
                case Keys.F6:
                 btnFinalizar_Click(null, null);
                 break;
       //////////////////////////////////////////////////////////////////////////////
                case Keys.F4:
                 btnDescuento_Click(null, null);
                 break;

                   

            }
        }



        void limpiarAgregar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtReferencia.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
        }


        void limpiarTodo()
        {

            this.txtCodigo.Text = string.Empty;
            this.dataGridViewVentas.DataSource = null;
            this.lblTotal.Text = "0.00";
        
        }

        bool ValidarCamposAgregar() 
        {

            if (this.txtCodigo.Text.Trim().Length <= 0)
            {

                MessageBox.Show("Digite el codigo del Articulo");
                this.DialogResult = DialogResult.None;
                this.txtCodigo.Focus();
                return false;
            }


            return true;
        }


        bool ValidarExiste()
        {

            if (this.txtDescripcion.Text.Trim().Length <= 0)
            {

                MessageBox.Show("Este Articulo No Existe");
                this.DialogResult = DialogResult.None;
                this.txtDescripcion.Focus();
                return false;
            }


            return true;
        }

        bool ValidarCodigoBaseDeDatos()  
        {
            DataTable dt = new DataTable();
            // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["INF420"]);
           // SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF420;Integrated Security=True");
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand("select CodigoDeBarra from tblArticulos", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {


                    if ((txtCodigo.Text.Trim() ) != ( rdr.GetString(0)))
                    {
                        MessageBox.Show("Este Codigo No esta Registrado, Intentelo de Nuevo");
                        this.DialogResult = DialogResult.None;
                        this.txtCodigo.Focus();
                        return false;
                    }


                    else if ((txtCodigo.Text.Trim()) == (rdr.GetString(0)))
                    {
                       // MessageBox.Show("Esto si existe");
                       // this.DialogResult = DialogResult.None;
                        //this.txtCodigo.Focus();
                        return true;
                    }
                }
                rdr.Close();
            }
            conn.Close();

            return true;

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposAgregar() == true  && ValidarExiste() ==true  &&  ValidarCodigoBaseDeDatos()==true )
            {
                int CeldaNueva = this.dataGridViewVentas.Rows.Add();

                int i = 1;
                int Precio;
                int Total;
                int Cant;
                txtCantidad.Text = Convert.ToString(i);

                Precio = Convert.ToInt32(txtPrecio.Text);
                Cant = Convert.ToInt32(txtCantidad.Text);
                Total = Precio * Cant;


                this.dataGridViewVentas.Rows[CeldaNueva].Cells["Codigo"].Value = this.txtCodigo.Text.ToString();
                this.dataGridViewVentas.Rows[CeldaNueva].Cells["Descripcion"].Value = this.txtDescripcion.Text.ToString();
                this.dataGridViewVentas.Rows[CeldaNueva].Cells["Precio"].Value = this.txtPrecio.Text.ToString();
                this.dataGridViewVentas.Rows[CeldaNueva].Cells["Cantidad"].Value = this.txtCantidad.Text.ToString();
                this.dataGridViewVentas.Rows[CeldaNueva].Cells["ColTotal"].Value = Total;


                // PARA QUE SUME 


                decimal resul = dataGridViewVentas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["ColTotal"].Value));

                //mostramos la suma en el textbox y en la fila que agregamos
                this.lblTotal.Text = Convert.ToString(resul) + ".00";

                HacerDescuento();

                limpiarAgregar();

            }
        }



       
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
             GetDatos();
        

        }

        private void btnBuscar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewVentas_CellValidated(object sender, DataGridViewCellEventArgs e) // para cuando entren la cantidad
        {   // ESTO ES PARA CUANDO CAMBIAMOS LA CANTIDAD EN LA CELDA DE CANTIDAD DEL DATAGRID
            string IDart = (dataGridViewVentas[0, e.RowIndex].Value == null ? string.Empty : dataGridViewVentas[0, e.RowIndex].Value.ToString());
            Ventas v = GetDatosArticulo(IDart);
            int cantidad;
            if (v.IDArticulo != null)
            {
                switch (e.ColumnIndex)
                {

                    case 0:

                        dataGridViewVentas[2, e.RowIndex].Value = v.Precio;//Asignacion del precio del articulo
                        dataGridViewVentas[3, e.RowIndex].Value = 1;//Cantidad de articulos que desea comprar para que empieze siempre en 1 

                        int.TryParse(dataGridViewVentas[2, e.RowIndex].Value.ToString(), out v.Precio);
                        int.TryParse(dataGridViewVentas[3, e.RowIndex].Value.ToString(), out cantidad);
                        dataGridViewVentas[4, e.RowIndex].Value = v.Precio * cantidad;

                        // AQUI REFRESCAMOS EL LABEL DE LA SUMA DEL TOTAL 
                         decimal resul = dataGridViewVentas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["ColTotal"].Value));

                         //mostramos la suma en el textbox y en la fila que agregamos
                         this.lblTotal.Text = Convert.ToString(resul) +".00";
                         HacerDescuento();




                        break;

                    case 2:
                        int.TryParse(dataGridViewVentas[2, e.RowIndex].Value.ToString(), out v.Precio);
                        int.TryParse(dataGridViewVentas[3, e.RowIndex].Value.ToString(), out cantidad);
                        dataGridViewVentas[4, e.RowIndex].Value = v.Precio * cantidad;

                        // AQUI REFRESCAMOS EL LABEL DE LA SUMA DEL TOTAL 
                        decimal resul2 = dataGridViewVentas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["ColTotal"].Value));

                        //mostramos la suma en el textbox y en la fila que agregamos
                        this.lblTotal.Text = Convert.ToString(resul2) + ".00";
                        HacerDescuento();

                        break;

                    case 3:
                        int.TryParse(dataGridViewVentas[2, e.RowIndex].Value.ToString(), out v.Precio);
                        int.TryParse(dataGridViewVentas[3, e.RowIndex].Value.ToString(), out cantidad);
                        dataGridViewVentas[4, e.RowIndex].Value = v.Precio * cantidad;
                        // AQUI REFRESCAMOS EL LABEL DE LA SUMA DEL TOTAL 
                        decimal resul3 = dataGridViewVentas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["ColTotal"].Value));

                        //mostramos la suma en el textbox y en la fila que agregamos
                        this.lblTotal.Text = Convert.ToString(resul3) + ".00";
                        HacerDescuento();

                        break;

                }



                dataGridViewVentas[1, e.RowIndex].Value = v.Descripcion;
                dataGridViewVentas[2, e.RowIndex].Value = v.Precio;



            }
        
            
        }


        private Ventas GetDatosArticulo(string idArticulo)
        {
            Ventas r = new Ventas();
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            // SqlConnection conn = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=PuntoDeVenta;User ID=sa; Password=yericordero;");
            string sql = string.Format("SELECT CodigoDeBarra,Descripcion,PrecioVenta , Referencia FROM [INF522].[dbo].[tblArticulos] WHERE CodigoDeBarra LIKE '{0}';", idArticulo);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //textBox1.Text = idArticulo;
                        //this.textBox1.Text = reader.GetString(0);
                        r.IDArticulo = reader["CodigoDeBarra"].ToString();
                        r.Descripcion = reader["Descripcion"].ToString();
                        r.Precio = Convert.ToInt32(reader["PrecioVenta"]);



                    }
                    this.txtCodigo.Text = string.Empty;
                }

                else
                {
                    // MessageBox.Show("esto no existe");
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


            return r;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            if (this.dataGridViewVentas.RowCount > 0)
            {
                int fila = dataGridViewVentas.CurrentRow.Index;
                dataGridViewVentas.Rows.RemoveAt(fila);
            }


            // PARA ACUALIZAR LA SUMA 

            decimal resul = dataGridViewVentas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["ColTotal"].Value));

            //mostramos la suma en el textbox y en la fila que agregamos
            this.lblTotal.Text = Convert.ToString(resul) + ".00";

            HacerDescuento();
        }


        void HacerDescuento()
        {

            // PARA ACUALIZAR LA SUMA 

            decimal resul = dataGridViewVentas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["ColTotal"].Value));

            //mostramos la suma en el textbox y en la fila que agregamos
            this.lblTotal.Text = Convert.ToString(resul) + ".00";


            decimal division; 
            decimal Descuento;
            decimal TotalCompra;
            decimal multiplicacion;
            decimal totalfinal;
            Descuento = Convert.ToDecimal(lblDescuento.Text);
            TotalCompra = Convert.ToDecimal(this.lblTotal.Text);
            division =  (Descuento / 100);
            multiplicacion = resul* division;
            totalfinal = resul - multiplicacion;
            lblTotalDescuento.Text = Convert.ToString(division);
            lblMult.Text = Convert.ToString(multiplicacion) +"%";
            lblTotalConDescuento.Text = Convert.ToString(totalfinal);


          
        
        
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulo f = new FrmBuscarArticulo();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtCodigo.Text = f.valor;
            }
        }

        public string id { get; set; }


        private void dataGridViewVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // PARA CUANDO SE SELECCIONE EL CONTENIDO DEL DATAGRID SE MUESTRE EN LOS TEXTBOX
           // if (e.RowIndex >= 0)
            {
              //  DataGridViewRow row = dataGridViewVentas.Rows[e.RowIndex];
              //  txtCodigo.Text = row.Cells["Codigo"].Value.ToString();
              //  txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
            
            }
        }

        

        private void dataGridViewVentas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
          //  ((DataGridViewTextBoxEditingControl)sender).KeyPress += new KeyPressEventHandler(dataGridViewVentas_KeyPress);
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten NUMEROS");
                e.Handled = true;
                return;


            }
        }

        private void pimpiarData()
        {
            this.dataGridViewVentas.DefaultCellStyle.Font = new Font("Tahoma", 8);
            this.dataGridViewVentas.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridViewVentas.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewVentas.DefaultCellStyle.SelectionForeColor = Color.Black;//letras de la seleccion
            // this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue; //para la celda seleccionada
            this.dataGridViewVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
        }


        void GetDatosCompania()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Nombre , Telefono , Direccion FROM tblCompañia ";



            SqlDataReader r;
            try
            {
                conn.Open();
                r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {

                        this.txtNombreCompania.Text = r.GetString(0);
                        this.txtTelefonoCompania.Text = r.GetString(1);
                        this.txtDireccionCompania.Text = r.GetString(2);


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



        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtCodigo;
            GetDatosCompania();
            txtFecha.Text = DateTime.Now.ToShortDateString();
            timer1.Start();

            txtHora.Text = DateTime.Now.ToLongTimeString();
            pimpiarData();
            this.txtCodigo.Focus();
            CbxVenta.SelectedIndex = 0;

            GetDatosUsuario();



           // para poner el texto en mayuscula 
         txtDescripcion.CharacterCasing = CharacterCasing.Upper;
                
            
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulo f = new FrmBuscarArticulo();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtCodigo.Text = f.valor;
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)// PARA FINALIZAR LA VENTA 
        {
           //InsertarDatosFactura();
           //DescontarArticulo();
          // GetIDFactura();
           //InsertarDatosDetalle();

           MessageBox.Show("En Construccion..   :)   ");
                

       }

        

        void InsertarDatosDetalle()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");

            {

                //   if (ValidarCampos() == true)

                for (int i = 0; i < this.dataGridViewVentas.Rows.Count; i++)
                {
                    {
                        try
                        {

                            SqlCommand cmd = new SqlCommand("INSERT INTO tblDetalles (ID_Factura, Descripcion, Cantidad, PrecioUnitario, PrecioTotal , Codigo)" +
                                                           " VALUES (@ID_Factura, @Descripcion, @Cantidad, @PrecioUnitario, @PrecioTotal , @Codigo);", conn);

                            cmd.Parameters.AddWithValue("@ID_Factura", this.txtFactura.Text);
                            cmd.Parameters.AddWithValue("@Codigo", this.dataGridViewVentas.Rows[i].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@Descripcion", this.dataGridViewVentas.Rows[i].Cells[1].Value);
                            cmd.Parameters.AddWithValue("@Cantidad", this.dataGridViewVentas.Rows[i].Cells[3].Value);
                            cmd.Parameters.AddWithValue("@PrecioUnitario", this.dataGridViewVentas.Rows[i].Cells[2].Value);
                            cmd.Parameters.AddWithValue("@PrecioTotal", this.dataGridViewVentas.Rows[i].Cells[4].Value);


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

                            //MessageBox.Show("se entraron los detalles en la tbl");
                            this.DialogResult = DialogResult.OK;

                        }


                    }// FIN DEL IF 

                } // fin del FOR
            }


        }

        void InsertarDatosFactura()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");

            {

                //   if (ValidarCampos() == true)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblFactura (Cliente, ID_Cliente, Fecha, Usuario, Monto, TipoVenta)" +
                                                       " VALUES (@Cliente, @ID_Cliente, @Fecha, @Usuario, @Monto, @TipoVenta);", conn);

                        cmd.Parameters.AddWithValue("@Cliente", this.txtCliente.Text);
                        cmd.Parameters.AddWithValue("@ID_Cliente", this.txtIDCliente.Text);
                        cmd.Parameters.AddWithValue("@Fecha", this.txtFecha.Text);
                        cmd.Parameters.AddWithValue("@Usuario", this.txtCajero.Text);
                        cmd.Parameters.AddWithValue("@Monto", this.lblTotal.Text);
                        cmd.Parameters.AddWithValue("@TipoVenta", CbxVenta.Text);


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


        void DescontarArticulo() 
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522 ;Integrated Security=True");

            {
                for (int i = 0; i < this.dataGridViewVentas.Rows.Count; i++)
                {
                //   if (ValidarCampos() == true)
                {
                        try
                        {

                            SqlCommand cmd = new SqlCommand("UPDATE tblArticulos SET  Cantidad= Cantidad-@Cantidad  WHERE  CodigoDeBarra= @CodigoDeBarra", conn);

                            cmd.Parameters.AddWithValue("@CodigoDeBarra", this.dataGridViewVentas.Rows[i].Cells[0].Value);
                          
                            cmd.Parameters.AddWithValue("@Cantidad", this.dataGridViewVentas.Rows[i].Cells[3].Value);





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

                            MessageBox.Show("Compra Realizada Satisfactoriamente.");
                            this.DialogResult = DialogResult.OK;

                        }


                    }// FIN DEL IF 
                }// fin del for
            }
        }

        void GetIDFactura()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["INF420"]);
            SqlConnection conn = new SqlConnection(@"Data Source=PC-PC;Initial Catalog=INF522;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID FROM tblFactura WHERE ID = (SELECT MAX(ID) from tblFactura)";

           // cmd.Parameters.AddWithValue("ID", txtFactura.Text);
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


                        txtFactura.Text = r.GetInt32(0).ToString();

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

            MessageBox.Show(txtFactura.Text);

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

        private void txtCodigo_Click(object sender, EventArgs e)
        {// para cuando haga click se borre todo 
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtReferencia.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;

        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
           // GetDatos();
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            frmDescuento f = new frmDescuento();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.lblDescuento.Text = f.desc;
               // lblDescuento.Text = "%";
            }
            HacerDescuento();
        }

        private void txtDinero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDinero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten NUMEROS");
                e.Handled = true;
                return;


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            dataGridViewVentas = null;
            txtCodigo.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            this.lblTotal.Text = "0.00";
            this.lblDescuento.Text = "0";
            //this.lblCambio.Text = "0.00";
            //this.txtDinero.Text = "0.00";
            this.txtCliente.Text = ""; 
            this.txtIDCliente.Text = "";

        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
           // btnAgregar_Click(null, null);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            HacerDescuento();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            BuscarClientes c = new BuscarClientes();
            if (c.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtIDCliente.Text = c.ID;
                this.txtCliente.Text = c.Nombre + " " + c.Apellido;
            }
        }

      





    }
}
