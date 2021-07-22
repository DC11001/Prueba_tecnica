using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOM.WS.DATOSEMPLEADO.BE.Models
{
    public class Colaborador
    {
        public int idcolaborador { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string edad { get; set; }
        public string profesion { get; set; }
        public string estadoCivil { get; set; }
    }
}