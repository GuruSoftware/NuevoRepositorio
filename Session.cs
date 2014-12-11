using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuntoDeVenta
{
    public class Session
    {
        private static string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private static string userID;
        public string UserID
        {
            set { userID = value; }
            get { return userID; }
        }

        public static string permisos;
        public string Permisos
        {
            set { permisos = value; }
            get { return permisos; }
        }



        public static string grupo;
        public string Grupo
        {
            set { grupo = value; }
            get { return grupo; }
        }

    }
}
