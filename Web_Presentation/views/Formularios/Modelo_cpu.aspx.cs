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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrops();
                Alerta.Visible = false;
            }
            else
            {
                contenedor = (DataTable)Session["Datos_a"];
            }
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
            string msg = "";
            bool resultado = false;
            if (Marca_DDL.SelectedIndex == 0 | Modelo_TB.Text.Length==0)
            {
                Alerta.Visible = true;
            }
            else
            {
                string cadena = Modelo_TB.Text;
                cadena = cadena.Replace(" ", string.Empty);
                if (cadena.Length == 0)
                {
                    Alerta.Visible = true;
                    Modelo_TB.Text = "";
                }
                else
                {
                    Alerta.Visible = false;
                    SqlParameter modelo = new SqlParameter("@modelo",SqlDbType.VarChar);
                    SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);

                    modelo.Value = Modelo_TB.Text.Trim();
                    marca.Value = Marca_DDL.SelectedValue;

                    List<SqlParameter> lista = new List<SqlParameter>()
                    {
                        modelo,marca
                    };

                    try
                    {
                        resultado = bl.InsertarItem("Modelo CPU", ref msg, lista);
                        if (resultado)
                            MessageBox(this, msg);
                        else
                        {
                            MessageBox(this, "Error al insertar");
                        }

                        Marca_DDL.SelectedIndex = 0;
                        Modelo_TB.Text = "";
                    }
                    catch(Exception ex)
                    {
                        MessageBox(this, "Error" + ex.Message);
                    }
                
                }
            }
        }
    }
}