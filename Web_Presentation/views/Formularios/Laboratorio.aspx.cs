using BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation.views.Formularios
{
    public partial class Laboratorio : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
            }
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            string msg = "";
            List<SqlParameter> lista = getLista();

            if (lista != null)
            {
                Alerta.Visible = false;
                try
                {
                    resultado = bl.InsertarItem("Laboratorio", ref msg, lista);
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        laboratorio_text.Text = "";
                    }
                    else
                    {
                        MessageBox(this, "Error al insertar el item");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox(this, "Error: " + ex.Message);
                }
            }
            else
            {
                Alerta.Visible = true;
            }

        }

        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (String.IsNullOrEmpty(laboratorio_text.Text) | laboratorio_text.Text == "")
            {
                lista = null;
            }
            else
            {
                if (laboratorio_text.Text.Length > 2)
                {
                    MessageBox(this, "El nombre del laboratorio solo debe tener una logitud de 2 caracteres");
                    laboratorio_text.Text = "";
                    lista = null;
                }
                else
                {
                    string cadena = laboratorio_text.Text;
                    cadena = cadena.Replace(" ", string.Empty);
                    if (cadena.Length == 0)
                    {
                        MessageBox(this, "Llene correctamente el textbox");
                        laboratorio_text.Text = "";
                        lista = null;
                    }
                    else
                    {
                        SqlParameter laboratorio = new SqlParameter("@lab", System.Data.SqlDbType.VarChar);

                        laboratorio.Value = cadena;

                       lista = new List<SqlParameter>() { laboratorio };
                    }
                }
            }
            return lista;
        }
        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }
    }
}