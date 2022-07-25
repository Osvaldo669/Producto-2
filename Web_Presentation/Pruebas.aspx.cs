using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataSet container = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Datos"] = null;
            }
            if (Session["Datos"] != null)
            {
                container = (DataSet) Session["Datos"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string mensaje = "";
            
            
        

            container = bl.Consulta_General(ref mensaje);
            if (container != null)
            {
                GridView1.DataSource = container.Tables[0];
                GridView1.DataBind();
                GridView2.DataSource = container.Tables[6];
                GridView2.DataBind();
                Label2.Text = mensaje;
            }

            Session["Datos"] = container;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}