using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation.views.Disco_Tipo
{
    public partial class Disco_Tipo : System.Web.UI.Page
    {

        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenaDropdownList();
                GridView1.Visible = false;
                Alerta.Visible = false;
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            DataSet contenedor = null;
            string msg = "";
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter sql = new SqlParameter("@disco",SqlDbType.VarChar);
            SqlParameter sql2 = new SqlParameter("@lab",SqlDbType.VarChar);
            if(Laboratorios.SelectedIndex ==0 | Tipos_Discos.SelectedIndex == 0)
            {
                Alerta.Visible = true;
            }
            else
            {
                Alerta.Visible = false;
                try
                {
                    sql.Value = Tipos_Discos.SelectedValue;
                    sql2.Value = Laboratorios.SelectedValue;
                    parametros.Add(sql);
                    parametros.Add(sql2);
                    contenedor = bl.ConsultaJoin_Sencilla("disco", ref msg, parametros);
                    if (contenedor.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = contenedor.Tables[0];
                        GridView1.DataBind();
                        GridView1.Visible = true;
                    }
                    else
                    {
                        MessageBox(this, "No se encontro ningun equipo con esos parametros");
                        GridView1.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox(this, "Error: " + ex.Message);
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
                Tipos_Discos.Items.Add("Seleccione un tipo de disco");
                Tipos_Discos.Items.Add("SSD");
                Tipos_Discos.Items.Add("Disco Mecanico");

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    Laboratorios.Items.Add(item["nombre_laboratorio"].ToString());
                }
            }
            catch (Exception ex)
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