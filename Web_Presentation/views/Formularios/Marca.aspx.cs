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
    public partial class Marca : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrops();
                Alerta.Visible = false;
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string msg = "";
            bool resultado = false;
            if (String.IsNullOrEmpty(Marca_text.Text) | Marca_text.Text=="" | Componente.SelectedIndex ==0)
            {
                Alerta.Visible = true;
            }
            else
            {
                Alerta.Visible = false;

                SqlParameter marca = new SqlParameter("@marca", SqlDbType.VarChar);
                SqlParameter componente = new SqlParameter("@componente", SqlDbType.Int);
                SqlParameter extra = new SqlParameter("@extra", SqlDbType.VarChar);

                marca.Value = Marca_text.Text;
                componente.Value = Componente.SelectedItem.Value;
                if (String.IsNullOrEmpty(Extra.Text))
                {
                    extra.Value = "";
                }
                else
                {
                    extra.Value = Extra.Text;
                }

                List<SqlParameter> lista = new List<SqlParameter>()
                { marca,componente,extra};

                try
                {
                    resultado = bl.InsertarItem("Marca", ref msg, lista);
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        Marca_text.Text = "";
                        Extra.Text = "";
                    }
                    else
                        MessageBox(this, msg);
                    Componente.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox(this, "Error: " + ex.Message);
                }

            }
        }

        private void LlenarDrops()
        {
            string query = "select c.Id_Componente as 'ID',Componente from Componente c";
            string msg = "";
            try
            {
                table = bl.consultaSencilla(query, ref msg).Tables[0];
                Componente.Items.Add("---Seleccione una opción---");
                if (table.Rows.Count > 0)
                {
                    ListItem item = null;
                    foreach(DataRow row in table.Rows)
                    {
                        item = new ListItem(row["Componente"].ToString() ,row["ID"].ToString());
                        Componente.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox(this, "No existen Marcas que se asocian con marcas de tipo Teclado--- Agregue una marca de teclado primero");
                }
            }
            catch(Exception ex)
            {
                MessageBox(this, "Error: " + ex.Message);
            }

        }

        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }
    }
}