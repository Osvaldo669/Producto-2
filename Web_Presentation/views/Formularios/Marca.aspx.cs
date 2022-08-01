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
        DataTable tabla = new DataTable();
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
                tabla = (DataTable)Session["datos_upd"];
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            OperacaionesTablas(0);
            LlenarActualizar();
        }
        

        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (String.IsNullOrEmpty(Marca_text.Text) | Marca_text.Text == "" | Componente.SelectedIndex == 0)
            {
                lista = null;
            }
            else
            {
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

                lista = new List<SqlParameter>()
                { marca,componente,extra};
            }
            return lista;
        }

         private void LlenarActualizar()
        {
            string msg = "";
            string query = "select *  from Marca";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            ListItem item;
            foreach (DataRow row in tabla.Rows)
            {
                item = new ListItem(row["Marca"].ToString(), row["Id_Marca"].ToString());
                actualizar.Items.Add(item);
            }
            Session["datos_upd"] = tabla;
        }

        private void OperacaionesTablas(int id)
        {

            string msg = "";
            bool resultado;
            List<SqlParameter> lista = getLista();
            if (lista != null)
            {
                Alerta.Visible = false;
                try
                {
                    if(id == 1)
                    {
                        SqlParameter id_valor = new SqlParameter("@id", SqlDbType.Int);
                        id_valor.Value = actualizar.SelectedValue;
                        lista.Add(id_valor);
                        resultado = bl.UpdateItem("Marca", ref msg, lista);
                    }
                    else
                    {
                        resultado = bl.InsertarItem("Marca", ref msg, lista);
                    }
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        Marca_text.Text = "";
                        Extra.Text = "";
                        actualizar.SelectedIndex = 0;
                    }
                    else
                        MessageBox(this, "Error al insertar los datos");
                    Componente.SelectedIndex = 0;
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

        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            OperacaionesTablas(1);
            LlenarActualizar();
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
                try
                {
                    Especial.Text = "ID: " + tabla.Rows[index]["Id_Marca"].ToString();
                    Marca_text.Text = tabla.Rows[index]["Marca"].ToString();
                    Componente.SelectedValue = tabla.Rows[index]["f_Id_Componente"].ToString();
                    Extra.Text = tabla.Rows[index]["Extra"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
        }
    }
}