using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation.views.Formularios
{
    public partial class Tipo_Ram : System.Web.UI.Page
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
            List<SqlParameter> lista =getLista();

            if (lista != null)
            {
                Alerta.Visible = false;
                try
                {
                    resultado = bl.InsertarItem("Tipo RAM", ref msg, lista);
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        extra_TB.Text = "";
                        tipo_ram.Text = "";
                    }
                    else
                    {
                        MessageBox(this, msg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox(this, "Error: " + ex.Message);
                }
            }
            else
            {
                Alerta.Visible = true ;
            }
        }


        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }

        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (String.IsNullOrEmpty(tipo_ram.Text))
            {
                lista = null;
            }
            else
            {
                string caden_tipo = tipo_ram.Text;
                caden_tipo = caden_tipo.Replace(" ", string.Empty);
                if (caden_tipo.Length == 0)
                {
                    tipo_ram.Text = "";
                    lista = null;
                }
                else
                {
                    if (tipo_ram.Text.Length > 20)
                    {
                        MessageBox(this, "Solo se permiten 20 caracteres");
                        lista = null;
                    }
                    else
                    {
                        SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar);
                        SqlParameter extra = new SqlParameter("@extra", SqlDbType.VarChar);
                        tipo.Value = tipo_ram.Text;
                        if (String.IsNullOrEmpty(extra_TB.Text))
                        {
                            extra.Value = "";
                        }
                        else
                        {
                            extra.Value = extra_TB.Text;
                        }

                        lista = new List<SqlParameter>()
                        {
                            tipo, extra
                        };
                    }
                }
            }
            return lista;
        }
    }
}