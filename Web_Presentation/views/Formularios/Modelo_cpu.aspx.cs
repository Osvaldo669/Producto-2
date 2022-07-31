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
    public partial class Modelo_cpu : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable contenedor = new DataTable();
        DataTable tabla = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrops();
                Alerta.Visible = false;
                LlenarActualizar();
            }
            else
            {
                contenedor = (DataTable)Session["Datos_a"];
                tabla = (DataTable)Session["datos_upd"];
            }
        }
        private void LlenarActualizar()
        {
            string msg = "";
            string query = "select *  from ModeloCPU";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            ListItem item;
            foreach (DataRow row in tabla.Rows)
            {
                item = new ListItem(row["modeloCPU"].ToString(), row["id_modcpu"].ToString());
                actualizar.Items.Add(item);
            }
            Session["datos_upd"] = tabla;
        }
        private void LlenarDrops()
        {
            string msg = "";
            try
            {
                contenedor = bl.getMarca(ref msg, 1);
                Marca_DDL.Items.Add("---Seleccione una opcion---");
                if (contenedor.Rows.Count > 0)
                {
                    ListItem item = null;
                    foreach (DataRow dr in contenedor.Rows)
                    {
                        item = new ListItem(dr["Marca"].ToString(), dr["ID"].ToString());
                        Marca_DDL.Items.Add(item);
                    }
                    Session["Datos_a"] = contenedor;
                }
                else
                {
                    MessageBox(this, "No existen Marcas que se asocian con marcas de tipo CPU--- Agregue una marca de CPU primero");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this, "Error: " + ex.Message);
            }
        }

        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
           
        }

        private List<SqlParameter> getlista()
        {
            List<SqlParameter> lista = null;
            if (Marca_DDL.SelectedIndex == 0 | Modelo_TB.Text.Length == 0)
            {
                lista = null;
            }
            else
            {
                string cadena = Modelo_TB.Text;
                cadena = cadena.Replace(" ", string.Empty);
                if (cadena.Length == 0)
                {
                    lista = null;
                    Modelo_TB.Text = "";
                }
                else
                {
                    Alerta.Visible = false;
                    SqlParameter modelo = new SqlParameter("@modelo", SqlDbType.VarChar);
                    SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);

                    modelo.Value = Modelo_TB.Text.Trim();
                    marca.Value = Marca_DDL.SelectedValue;

                    lista = new List<SqlParameter>()
                    {
                        modelo,marca
                    };
                }
            }
            return lista;
        }

        private void OperacionesTablas(int id)
        {
            string msg = "";
            bool resultado = false;
            List<SqlParameter> lista = getlista();

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
                        resultado = bl.UpdateItem("Modelo CPU", ref msg, lista);
                    }
                    else
                    {
                        resultado = bl.InsertarItem("Modelo CPU", ref msg, lista);
                    }

                    if (resultado)
                    {
                        MessageBox(this, msg);
                        Especial.Text = "";
                        Modelo_TB.Text = "";
                        Marca_DDL.SelectedIndex = 0;
                        actualizar.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox(this, "Error al insertar");
                    }

                    Marca_DDL.SelectedIndex = 0;
                    Modelo_TB.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox(this, "Error" + ex.Message);
                }
            }
            else
            {
                Alerta.Visible = true;
            }
        }
        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            OperacionesTablas(1);
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
                Especial.Text = "ID: " + tabla.Rows[index]["id_modcpu"].ToString();
                Modelo_TB.Text = tabla.Rows[index]["modeloCPU"].ToString();
                Marca_DDL.SelectedValue = tabla.Rows[index]["f_marca"].ToString();
                
            }
        }
    }
}