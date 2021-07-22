using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
namespace NOM.WS.DATOSEMPLEADO.BE.Clases
{
    public class ColaboradorInfo
    {

        public static List<Models.Colaborador> GetColaboradores()
        {
            List<Models.Colaborador> clbds = new List<Models.Colaborador>();
            CultureInfo ci = new CultureInfo("es-GT");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(Conexion.GetConexionDB()))
                {
                    conn.Open();
                    da.SelectCommand = new SqlCommand("SELECT * FROM JDCColab", conn);
                    da.SelectCommand.CommandTimeout = 90;
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    conn.Dispose();
                    conn.Close();
                }
                foreach(DataRow dr in dt.Rows)
                {
                    clbds.Add(new Models.Colaborador()
                    {
                        idcolaborador = Convert.ToInt32(dr[0].ToString()),
                        nombre = dr[1].ToString(),
                        apellido = dr[2].ToString(),
                        direccion = dr[3].ToString(),
                        edad = dr[4].ToString(),
                        profesion = dr[5].ToString(),
                        estadoCivil = dr[6].ToString(),

                    });
                }
            }
            catch (Exception ex)
            {

                return null;
            }

            return clbds;
        }
    }
}