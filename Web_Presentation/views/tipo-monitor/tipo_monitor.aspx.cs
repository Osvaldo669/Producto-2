using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Web_Presentation.views.tipo_monitor
{
    public partial class tipo_monitor : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                GridView1.Visible = false;
                llenarDropDown();
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if (Tipo_Monitor.SelectedIndex == 0)
            {
                Alerta.Visible = true;
                GridView1.Visible = false;
            }
            else
            {
                DataTable table = new DataTable();
                SqlParameter sql = new SqlParameter("@monitor", SqlDbType.VarChar);
                List<SqlParameter> lista = new List<SqlParameter>();
                string msg = "";

                try
                {
                    sql.Value = Tipo_Monitor.SelectedValue;
                    lista.Add(sql);
                    table = bl.ConsultaJoin_Sencilla("monitor", ref msg, lista).Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        GridView1.DataSource = table;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                    }
                    else
                        MessageBox(this, "No se encontro maquina que coincida con el parametro seleccionado");
                }
                catch(Exception ex)
                {
                    MessageBox(this, "Error: "+ex.Message);
                }
            }
        }

        public void llenarDropDown()
        {
            string query = "Select tamano from monitor";
            string msg = "";
            DataSet data = null;
            try
            {
                data = bl.consultaSencilla(query, ref msg);
                Tipo_Monitor.Items.Add("Seleccione un tamaño");

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    Tipo_Monitor.Items.Add(item["tamano"].ToString());
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