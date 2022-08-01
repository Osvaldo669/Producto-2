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
    public partial class Gabinete : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable contenedor = new DataTable();
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrops();
                LlenarActualizar();
                Alerta.Visible = false;
            }
            else
            {
                contenedor = (DataTable)Session["Datos_a"];
                table = (DataTable)Session["datos_upd"];
            }
        }

        private void LlenarActualizar()
        {
            string msg = "";
            string query = "select *  from Gabinete";
            table = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in table.Rows)
            {
                actualizar.Items.Add(row["id_Gabinete"].ToString());
            }
            Session["datos_upd"] = table;
        }
        private void LlenarDrops()
        {
            string msg = "";
            try
            {
                contenedor = bl.getMarca(ref msg, 6);
                Marca_DDL.Items.Add("---Seleccione una opcion---");
                Tipo_DDL.Items.Add("---Seleccione una opcion---");
                Tipo_DDL.Items.Add("Mini ATX");
                Tipo_DDL.Items.Add("Micro-ATX");
                Tipo_DDL.Items.Add("ATX");
                Tipo_DDL.Items.Add("Media Torre");
                Tipo_DDL.Items.Add("Torre");
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
                    MessageBox(this, "No existen Marcas que se asocian con marcas de tipo Gabinete--- Agregue una marca de gabinete primero");
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

        protected void guardar_Click(object sender, EventArgs e)
        {
            OperacionesTablas(0);
            LlenarActualizar();
        }

        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (Marca_DDL.SelectedIndex == 0 | Tipo_DDL.SelectedIndex == 0 | String.IsNullOrEmpty(Modelo_TB.Text))
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
                    try
                    {
                        SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);
                        SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar);
                        SqlParameter modelo = new SqlParameter("@modelo", SqlDbType.VarChar);

                        marca.Value = Marca_DDL.SelectedValue;
                        tipo.Value = Tipo_DDL.SelectedValue;
                        modelo.Value = Modelo_TB.Text.Trim();

                        lista = new List<SqlParameter>()
                        {
                            marca,tipo,modelo
                        };
                    }
                    catch (Exception ex)
                    {
                        MessageBox(this, "Error: " + ex.Message);
                        lista = null;
                    }
                }
            }
            return lista;
        }

        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            OperacionesTablas(1);
            LlenarActualizar();
        }

        private void OperacionesTablas(int id)
        {
            string msg = "";
            bool resultado = false;
            List<SqlParameter> lista = getLista();
            if (lista != null)
            {
                try
                {
                    Alerta.Visible = false;
                    if (id == 1)
                    {
                        SqlParameter id_valor = new SqlParameter("@id", SqlDbType.Int);
                        id_valor.Value = actualizar.SelectedValue;
                        lista.Add(id_valor);
                        resultado = bl.UpdateItem("Gabinete", ref msg, lista);

                    }
                    else
                    {
                        resultado = bl.InsertarItem("Gabinete", ref msg, lista);
                    }


                    if (resultado == true)
                    {
                        MessageBox(this, msg);
                        Especial.Text = "";
                        Modelo_TB.Text = "";
                        Tipo_DDL.SelectedIndex = 0;
                        Marca_DDL.SelectedIndex = 0;
                        actualizar.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox(this, "Solo se permiten 10 caracteres en el modelo");
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

        protected void actualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizar.SelectedIndex == 0)
            {
                Alerta.Visible = true;
            }
            else
            {
                int index = actualizar.SelectedIndex - 1;
                Especial.Text ="ID: "+ table.Rows[index]["id_Gabinete"].ToString();
                try
                {
                    Modelo_TB.Text = table.Rows[index]["Modelo"].ToString();
                    Tipo_DDL.SelectedValue = table.Rows[index]["TipoForma"].ToString();
                    Marca_DDL.SelectedValue = table.Rows[index]["F_Marca"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
        }

        

    }
}