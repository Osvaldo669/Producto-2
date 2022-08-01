using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BL;

namespace Web_Presentation.views.Formularios
{
    

    public partial class Componente : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                LlenarDrop();
            }
            else{
                table = (DataTable)Session["datos"];
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            operaciones(0);
        }

        private void LlenarDrop()
        {
            string msg = "";
            string query = "select *  from Componente";
            table = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            ListItem item;
            foreach(DataRow row in table.Rows)
            {
                item = new ListItem(row["Componente"].ToString(),row["Id_Componente"].ToString());
                actualizar.Items.Add(item);
            }
            Session["datos"] = table;
        }
        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }

        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (String.IsNullOrEmpty(Componente_textB.Text) | Componente_textB.Text == "")
            {
                lista = null;
            }
            else
            {
                SqlParameter componente = new SqlParameter("@componente", SqlDbType.VarChar);
                SqlParameter extra = new SqlParameter("@extra", SqlDbType.VarChar);

                componente.Value = Componente_textB.Text;
                if (String.IsNullOrEmpty(Extra.Text))
                {
                    extra.Value = "";
                }
                else
                {
                    extra.Value = Extra.Text;
                }

                lista = new List<SqlParameter>()
                {
                    componente,extra
                };
            }
            return lista;
        }

        protected void actualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizar.SelectedIndex == 0)
            {
                MessageBox(this, "Seleccione una opcion correcta");
            }
            else
            {
                int index = actualizar.SelectedIndex - 1;
                try
                {
                    Especial.Text = "ID: " + table.Rows[index]["Id_Componente"].ToString();
                    Componente_textB.Text = table.Rows[index]["Componente"].ToString();
                    Extra.Text = table.Rows[index]["Extra"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }

            }
        }

        protected void guardar_datos_Click(object sender, EventArgs e)
        {
            operaciones(1);
        }

        private void operaciones(int tarea)
        {
            string msg = "";
            bool resultado = false;
            List<SqlParameter> lista = getLista();
            if(tarea== 1)
            {
                SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                id.Value = actualizar.SelectedValue;
                lista.Add(id);
                if (lista != null)
                {
                    Alerta.Visible = false;
                    try
                    {
                        resultado = bl.UpdateItem("Componente", ref msg, lista);
                        if (resultado)
                            MessageBox(this, msg);
                        else
                            MessageBox(this, "No se pudo realizar la operacion");

                        Componente_textB.Text = "";
                        actualizar.SelectedIndex = 0;
                        Extra.Text = "";

                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message;
                        MessageBox(this, msg);
                    }
                }
                else
                {
                    Alerta.Visible = true;
                }
            }
            else
            {
                if (lista != null)
                {
                    Alerta.Visible = false;
                    try
                    {
                        resultado = bl.InsertarItem("Componente", ref msg, lista);
                        if (resultado)
                            MessageBox(this, msg);
                        else
                            MessageBox(this, "No se pudo realizar la operacion");

                        Componente_textB.Text = "";

                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message;
                        MessageBox(this, msg);
                    }
                }
                else
                {
                    Alerta.Visible = true;
                }
                LlenarDrop();
            }

            
            
        }
    }
}