using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOM.WS.DATOSEMPLEADO.BE.Clases
{
    public class Conexion
    {
        public static string GetConexionDB()
        {
            //Aquí se puede usar variables de entorno para no tener las credenciales quemadas en código. 
            string servidor = "LOCALHOST";
            string baseDatos = "TEST";
            string usuario = "web_app";
            string contrasenia = "2021_NOM#$";
            return string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", servidor, baseDatos, usuario, contrasenia);
        }
    }
}