using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NOM.WS.DATOSEMPLEADO.BE.Controllers
{
    public class ColaboradorController : ApiController
    {
        // GET: api/Colaborador
        public List<Models.Colaborador> Get()
        {
            return Clases.ColaboradorInfo.GetColaboradores();
        }

        // GET: api/Colaborador/5
        public string Get(int id)
        {
            return "value";
        }
    }

}
