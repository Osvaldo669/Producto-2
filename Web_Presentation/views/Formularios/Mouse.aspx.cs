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
    public partial class Mouse : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable contenedor = new DataTable();
        DataTable tabla = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                LlenarDropDown();
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
            string query = "select *  from mouse";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in tabla.Rows)
            {
                actualizar.Items.Add(row["id_mouse"].ToString());
            }
            Session["datos_upd"] = tabla;
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            //Metodo Para insertar un Mouse
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
                        resultado = bl.UpdateItem("Mouse", ref msg, lista);
                    }
                    else
                    {
                        resultado = bl.InsertarItem("Mouse", ref msg, lista);
                    }

                    if (resultado)
                        MessageBox(this, msg);
                    else
                        MessageBox(this, msg);

                    Tipos_usb_drop.SelectedIndex = 0;
                    Marcas_drop.SelectedIndex = 0;
                    actualizar.SelectedIndex = 0;
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
        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (Tipos_usb_drop.SelectedIndex == 0 | Marcas_drop.SelectedIndex == 0)
            {
                lista = null;
            }
            else
            {

                lista = new List<SqlParameter>();
                SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);
                SqlParameter conector = new SqlParameter("@conector", SqlDbType.VarChar);
                marca.Value = Convert.ToInt16(Marcas_drop.SelectedItem.Value);
                conector.Value = Tipos_usb_drop.SelectedValue;
                lista.Add(marca);
                lista.Add(conector);
            }
            return lista;
        }
        private void LlenarDropDown()
        {
            string msg = "";
            try
            {
                contenedor = bl.getMarca(ref msg, 3);
                Marcas_drop.Items.Add("---Seleccione una opcion---");
                Tipos_usb_drop.Items.Add("---Seleccione una opcion---");
                Tipos_usb_drop.Items.Add("PS27");
                Tipos_usb_drop.Items.Add("USB 2.0");
                Tipos_usb_drop.Items.Add("USB 3.0");
                Tipos_usb_drop.Items.Add("Bluetooth");
                Session["Datos_a"] = contenedor;
                if (contenedor.Rows.Count > 0)
                {
                    ListItem item = null;
                    foreach (DataRow dr in contenedor.Rows)
                    {
                        item = new ListItem(dr["Marca"].ToString(), dr["ID"].ToString());
                        Marcas_drop.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox(this, "No existen Marcas que se asocian con marcas de tipo Mouse");
                }
            }
            catch(Exception ex)
            {
                MessageBox(this, ex.Message);
            }
        }

        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
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
                Especial.Text = "ID: " + tabla.Rows[index]["id_mouse"].ToString();
                Marcas_drop.SelectedValue = tabla.Rows[index]["f_marcamouse"].ToString();
                Tipos_usb_drop.SelectedValue = tabla.Rows[index]["conector"].ToString();
            }
        }
    }
}