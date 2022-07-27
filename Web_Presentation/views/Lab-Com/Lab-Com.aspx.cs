using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation.views.Lab_Com
{
    public partial class Lab_Com : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                LlenaDropdownList();
            }
        }

        protected void BuscarXLaboratorio_Click(object sender, EventArgs e)
        {
            string msg = "";
            DataSet container = null;
            List<SqlParameter> parametros = new List<SqlParameter>();
            if(Laboratorios.SelectedIndex == 0)
            {
                Alerta.Visible = true;
                GridView1.Visible = false;
            }
            else
            {
                Alerta.Visible = false;
                
                SqlParameter parameter = new SqlParameter("@clave", SqlDbType.VarChar, 64);
                parameter.Value = Laboratorios.SelectedValue;
                try
                {
                    GridView1.Visible = true;
                    parametros.Add(parameter);
                    container = bl.ConsultaJoin_Sencilla("lab", ref msg, parametros);
                    GridView1.DataSource = container.Tables[0];
                    GridView1.DataBind();
                }
                catch
                {
                    MessageBox(this, msg);
                }
            }
        }
        private void LlenaDropdownList()
        {
            string query = "Select nombre_laboratorio from ubicacion";
            string msg = "";
            DataSet data = null;
            try
            {
                data = bl.consultaSencilla(query, ref msg);
                Laboratorios.Items.Add("Seleccione un laboratorio");
                foreach(DataRow item in data.Tables[0].Rows)
                {
                    Laboratorios.Items.Add(item["nombre_laboratorio"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox(this, ex.Message);
            }
            
        }

        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }
    }
}