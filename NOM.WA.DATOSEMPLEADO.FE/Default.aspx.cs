using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NOM.WA.DATOSEMPLEADO.FE
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44347/api/");
            var consumeapi = hc.GetAsync("Colaborador");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsStringAsync();
                displayrecords.Wait();
                string clbdsstring = displayrecords.Result;
                IList<Model.Colaborador> validcols;
                string jsonString = clbdsstring;
                // Call the deserializer  
                validcols = DeserializeToList<Model.Colaborador>(jsonString);
                GridView1.DataSource = validcols;
                GridView1.DataBind();
                ButtonField b = new ButtonField();
                b.ButtonType = ButtonType.Button;
                Label1.Text = GridView1.Columns.Count.ToString();
            }
            else
            {
                Label1.Text = "Error al obtener los datos";
            }


        }
        public static List<string> InvalidJsonElements;
        public static IList<T> DeserializeToList<T>(string jsonString)
        {
            InvalidJsonElements = null;
            var array = Newtonsoft.Json.Linq.JArray.Parse(jsonString);
            IList<T> objectsList = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    // CorrectElements  
                    objectsList.Add(item.ToObject<T>());
                }
                catch (Exception ex)
                {
                    InvalidJsonElements = InvalidJsonElements ?? new List<string>();
                    InvalidJsonElements.Add(item.ToString());
                }
            }

            return objectsList;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "\"Fuera de peligro\"";
            Label1.Text = "\"TENGA CUIDADO, TOME TODAS LAS MEDIDAS DE PREVENSION\"";
            Label1.Text = "\"POR FAVOR QUEDARSE EN CASA\"";
        }
    }
}