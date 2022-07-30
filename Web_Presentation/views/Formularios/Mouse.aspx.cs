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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                LlenarDropDown();
            }
            else
            {
                contenedor = (DataTable)Session["Datos_a"];
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            //Metodo Para insertar un Mouse
            if(Tipos_usb_drop.SelectedIndex == 0 | Marcas_drop.SelectedIndex == 0)
            {
                Alerta.Visible = true;
            }
            else
            {
                Alerta.Visible = false;
                bool resultado = false;
                string msg = "";
                List<SqlParameter> sqls = new List<SqlParameter>();
                SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);
                SqlParameter conector = new SqlParameter("@conector", SqlDbType.VarChar);
                marca.Value = Convert.ToInt16(Marcas_drop.SelectedItem.Value);
                conector.Value = Tipos_usb_drop.SelectedValue;
                sqls.Add(marca);
                sqls.Add(conector);
                try
                {
                    resultado = bl.InsertarItem("Mouse", ref msg, sqls);
                    if (resultado)
                        MessageBox(this, msg);
                    else
                        MessageBox(this, msg);

                    Tipos_usb_drop.SelectedIndex = 0;
                    Marcas_drop.SelectedIndex = 0;
                }
                catch(Exception ex)
                {
                    msg = ex.Message;
                    MessageBox(this, msg);
                }
            }
        }
        private void LlenarDropDown()
        {
            string msg = "";
            string query = "select m.Id_Marca as 'ID', Marca from marca m join Componente c on c.Id_Componente=m.f_Id_Componente where f_Id_Componente=3";
            try
            {
                contenedor = bl.consultaSencilla(query, ref msg).Tables[0];
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
    }
}