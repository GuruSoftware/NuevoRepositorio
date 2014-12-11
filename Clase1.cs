using System;

namespace PuntoDeVenta
{
    public class EProducto
    {
        //Estas son propiedades Autoimplementadas y su uso requiere
        // del Framework 4.0 Client Profile como minimo

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Decimal TotalUnidad { get; set; }  
        public Decimal PrecioTotal { get; set; }
    }
}
