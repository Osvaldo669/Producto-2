using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation.views.Actualizaciones
{
    public partial class Actualizacion : System.Web.UI.Page
    {

        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                informacionPC.Visible = false;
            }
        }

        protected void BuscarComputadora_Btn_Click(object sender, EventArgs e)
        {
            string msg = "";


            DataTable table = null;
            List<SqlParameter> sqls = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@clave", SqlDbType.VarChar, 10);
            if (String.IsNullOrEmpty(Buscar_Computadora_textbox.Text) | Buscar_Computadora_textbox.Text == "")
            {
                Alerta.Visible = true;
            }
            else
            {
                Alerta.Visible = false;
                try
                {
                    parameter.Value = Buscar_Computadora_textbox.Text;
                    sqls.Add(parameter);
                    table = bl.ConsultaJoin_Sencilla("actualizacion", ref msg, sqls).Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        informacionPC.Visible = true;
                        Label1.Text ="N° de Inventario: " +table.Rows[0]["N° inventario"].ToString();
                        Label2.Text = "Ubicacion: Laboratorio-" + table.Rows[0]["Ubicacion"];

                        if (String.IsNullOrEmpty((table.Rows[0]["imagen1"].ToString())))
                        {
                            imagen_PC.Src = "https://www.tecnologia-informatica.com/wp-content/uploads/2018/08/caracteristicas-de-las-computadoras-1.jpeg";
                        }
                        else
                        {
                            imagen_PC.Src = table.Rows[0]["imagen1"].ToString();
                        }
                        GridView1.DataSource = table;
                        GridView1.DataBind();
                    }
                    else
                    {
                        MessageBox(this, "Computadora no encontrada o numero de inventario incorrecto");
                        informacionPC.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
        }

        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
        }
    }
}