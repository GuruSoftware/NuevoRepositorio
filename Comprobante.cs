using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuntoDeVenta
{
    class Comprobante
    {
       public enum Tipo {GeneraCredito=01,ConsumidoresFinales=01,NotaDebito=03,NotaCredito=04,ProvedoresInformales=11,RegistroUnicoDeIngreso=12,GastosMenores=13,EspecialesDeTributacion=14 }
        
        public static string GenerarCodigo(String Serie,string DivicionDeNegocio,string  PuntoDeEmicion,string  AreaDeImpresion,string tipo ,string  Secuencia)
        {

            string Codigo = (Serie + DivicionDeNegocio.PadLeft(2, '0').Trim(' ') + PuntoDeEmicion.PadLeft(3, '0').Trim(' ') + AreaDeImpresion.PadLeft(3, '0').Trim(' ') + tipo.PadLeft(2, '0').Trim(' ') + Secuencia.PadLeft(8, '0').Trim(' '));
            return Codigo;
        }
    }
}
