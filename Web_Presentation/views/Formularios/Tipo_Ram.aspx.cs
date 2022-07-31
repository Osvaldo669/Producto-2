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
        DataTable tabla = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                LlenarActualizar();
            }
            else
            {
                tabla =(DataTable) Session["datos_upd"];
            }

        }

        private void LlenarActualizar()
        {
            string msg = "";
            string query = "select *  from TipoRAM";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in tabla.Rows)
            {
                actualizar.Items.Add(row["id_tipoRam"].ToString());
            }
            Session["datos_upd"] = tabla;
        }
        protected void guardar_Click(object sender, EventArgs e)
        {
            operaciones(0);
            LlenarActualizar();
        }

        private void operaciones(int id)
        {
            bool resultado = false;
            string msg = "";
            List<SqlParameter> lista = getLista();

            if (lista != null)
            {
                Alerta.Visible = false;
                try
                {
                    if (id == 1)
                    {
                        SqlParameter id_valor = new SqlParameter("@id", SqlDbType.Int);
                        id_valor.Value = actualizar.SelectedValue;
                        lista.Add(id_valor);
                        resultado = bl.UpdateItem("Tipo RAM", ref msg, lista);
                    }
                    else
                    {
                        resultado = bl.InsertarItem("Tipo RAM", ref msg, lista);
                    }
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        extra_TB.Text = "";
                        tipo_ram.Text = "";
                        actualizar.SelectedIndex = 0;
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
                Alerta.Visible = true;
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

        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            operaciones(1);
        }

        protected void actualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizar.SelectedIndex == 0)
            {
                Alerta.Visible = true;
            }
            else
            {
                Alerta.Visible = false;
                int index = actualizar.SelectedIndex - 1;
                Especial.Text = "ID: " + tabla.Rows[index]["id_tipoRam"].ToString();
                tipo_ram.Text = tabla.Rows[index]["Tipo"].ToString();
                extra_TB.Text = tabla.Rows[index]["Extra"].ToString();
            }
        }
    }
}