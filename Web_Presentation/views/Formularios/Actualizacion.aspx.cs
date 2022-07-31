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
    public partial class Actualizacion : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable contenedor = new DataTable();
        DataTable tabla = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrops();
                LlenarActualizar();
                Alerta.Visible = false;
                Especial.Text = "";
            }
            else
            {
                contenedor = (DataTable)Session["Datos"];
                tabla=(DataTable)Session["datos_update"];
            }
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            Especial.Text = "";
            string msg = "";
            List<SqlParameter> lista = getlista();
            if (lista != null)
            {
                Alerta.Visible = false;
                try
                {
                    bool resultado= bl.InsertarItem("Actualizacion", ref msg, lista);
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        inv_DDL.SelectedIndex = 0;
                        num_TB.Text = "";
                        desc_TB.Text = "";
                        
                    }
                    else
                    {
                        MessageBox(this, "Error al insertar");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox(this, "Error: "+ex.Message);
                }
            }
            else
            {
                Alerta.Visible = true;
            }
        }
        private List<SqlParameter> getlista()
        {
            List<SqlParameter> lista = null;
            if(inv_DDL.SelectedIndex==0| Calendar1.SelectedDate == null | String.IsNullOrEmpty(num_TB.Text)|
                String.IsNullOrEmpty(desc_TB.Text))
            {
                lista = null;
            }
            else
            {
                string cadena = num_TB.Text.Replace(" ",string.Empty);
                string cadena2 = desc_TB.Text.Replace(" ", string.Empty);
                if (cadena.Length == 0)
                {
                    lista = null;
                }
                else
                {
                    if (cadena2.Length == 0)
                    {
                        lista = null;
                    }
                    else
                    {
                        
                        SqlParameter inv = new SqlParameter("@inv", SqlDbType.Int);
                        SqlParameter cal = new SqlParameter("@cal", SqlDbType.Date);
                        SqlParameter num = new SqlParameter("@num", SqlDbType.VarChar);
                        SqlParameter desc = new SqlParameter("@desc", SqlDbType.VarChar);

                        inv.Value = inv_DDL.SelectedValue;
                        cal.Value = Calendar1.SelectedDate;
                        num.Value = num_TB.Text.Trim();
                        desc.Value = desc_TB.Text.Trim();

                        lista = new List<SqlParameter>() { inv,cal,num,desc };
                    }
                }
            }
            return lista;
        }
        private void LlenarActualizar()
        {
            actualizar.Items.Clear();
            actualizar.Items.Add("---Selcccione una opcion---");

            string query = "select *  from actualizacion";
            string msg = "";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            foreach (DataRow row in tabla.Rows)
            {
                actualizar.Items.Add(row["id_act"].ToString());
            }
            Session["datos_update"] = tabla;
        }
        private void LlenarDrops()
        {
            string msg = "";
            string query = "select num_inv as 'ID' from computadorafinal;";
            try
            {
                contenedor = bl.consultaSencilla(query, ref msg).Tables[0];
                if (contenedor != null)
                {
                    inv_DDL.Items.Add("---Seleccione una opcion---");
                    
                    foreach (DataRow row in contenedor.Rows)
                    {
                        inv_DDL.Items.Add(row["ID"].ToString());
                    }
                   
                    Session["Datos"] = contenedor;
                }
                else
                {
                    MessageBox(this, "No Hay datos   ---> Agruegue Datos en la tabla de computadora final");
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


        protected void guardar_datos_Click(object sender, EventArgs e)
        {
            string msg = "";
            List<SqlParameter> lista = getlista();
            SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
            id.Value = actualizar.SelectedValue;

            lista.Add(id);
            if (lista != null)
            {
                Alerta.Visible = false;
                try
                {
                    bool resultado = bl.UpdateItem("Actualizacion", ref msg, lista);
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        inv_DDL.SelectedIndex = 0;
                        num_TB.Text = "";
                        desc_TB.Text = "";
                        Especial.Text = "";
                        actualizar.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox(this, "Error al insertar");
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
                MessageBox(this, "Seleccione una opcion correcta");
            }
            else
            {
                int index = actualizar.SelectedIndex - 1;
                Especial.Text ="ID: "+ tabla.Rows[index]["id_act"].ToString();
                inv_DDL.SelectedValue = tabla.Rows[index]["num_inv"].ToString();
                num_TB.Text = tabla.Rows[index]["num_serie"].ToString();
                desc_TB.Text=tabla.Rows[index]["descripcion"].ToString();
                Calendar1.SelectedDate =Convert.ToDateTime(tabla.Rows[index]["fecha"].ToString());
            }
        }
    }
}