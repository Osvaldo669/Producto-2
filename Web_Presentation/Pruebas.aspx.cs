using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server2"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bl"] != null) //nulo
            {
                bl = (Clase_Negocios)Session["bl"]; //insertamos el campo LON
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string mensaje = "";
            DataSet container = null;
            
            List<String> strings = new List<String>()
            {
                "Componente",
                "Marca",
                "Monitor",
                "Teclado",
                "Mouse",
                "Gabinete",
                "DiscoDuro",
                "ModeloCpu",
                "Tipo_Cpu",
                "TipoRAM",
                "RAM",
                "CPU_Generico",
                "Actualizacion",
                "Laboratorio",
                "Ubicacion",
                "ComputadoraFinal",
                "CantDisc",

            };
            Random random = new Random();
            int randowss = random.Next(0, strings.Count - 1);

            container = bl.Consulta_General(strings[randowss], ref mensaje);
            if (container != null)
            {
                GridView1.DataSource = container.Tables[0];
                GridView1.DataBind();
                Label2.Text = mensaje;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string mensaje;
            mensaje = bl.InsertarMouse(new Entities.Mouse()//insertamos la clase entidades
            {
                Id_mouse = Convert.ToInt32(id_mouse.Value),
               f_marcamouse = Convert.ToInt32(marcamouse.Value),
                conector = conector.Value,
            });

            Label1.Text = mensaje;
            Session["bl"] = bl;
            id_mouse.Value = "";
            marcamouse.Value = "";
            conector.Value = "";
        }
    }
}