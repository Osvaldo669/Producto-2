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
    public partial class Ram : System.Web.UI.Page
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
                tabla = (DataTable)Session["Datos_upd"];
            }
        }

        private void LlenarActualizar()
        {
            string msg = "";
            string query = "select *  from RAM";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in tabla.Rows)
            {
                actualizar.Items.Add(row["id_RAM"].ToString());
            }
            Session["datos_upd"] = tabla;
        }
        private void LlenarDrops()
        {
            string msg = "";
            string query = "select id_tipoRam as 'ID', Tipo from TipoRAM";
            try
            {
                contenedor = bl.consultaSencilla(query, ref msg).Tables[0];
                capacidad.Items.Add("---Seleccione una opcion---");
                tipos.Items.Add("---Seleccione una opcion---");
                
                if (contenedor.Rows.Count > 0)
                {
                    ListItem item = null;
                    foreach (DataRow dr in contenedor.Rows)
                    {
                        item = new ListItem(dr["Tipo"].ToString(), dr["ID"].ToString());
                        tipos.Items.Add(item);
                    }
                    ListItem item2 = null;
                    int cap = 2;
                    for(int x =0; x <= 5; x++)
                    {
                        item2 = new ListItem(cap + " GB", cap.ToString());
                        capacidad.Items.Add(item2);
                        cap = cap * 2;
                    }
                    Session["Datos_a"] = contenedor;
                }
                else
                {
                    MessageBox(this, "No Hay datos en la tabla Tipos-RAM  ---> Agregue una dato primero en esa tabla");
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
            operaciones(0);
            LlenarActualizar();

        }

        private void operaciones(int id)
        {
            string msg = "";
            bool resultado = false;
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
                        resultado = bl.UpdateItem("RAM", ref msg, lista);
                    }
                    else
                    {
                        resultado = bl.InsertarItem("RAM", ref msg, lista);
                    }
                    if (resultado)
                    {
                        MessageBox(this, msg);
                        Velocidad.Text = "";
                        tipos.SelectedIndex = 0;
                        capacidad.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox(this, "Error, no se pudo insertar");
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

        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (capacidad.SelectedIndex == 0 | tipos.SelectedIndex == 0 | String.IsNullOrEmpty(Velocidad.Text))
            {
                lista = null;
            }
            else
            {
                string cadena = Velocidad.Text.Replace(" ", string.Empty);
                if (cadena.Length == 0)
                {
                    lista = null;
                    Velocidad.Text = "";
                }
                else
                {
                    if (Velocidad.Text == "")
                        lista = null;
                    else
                    {
                        SqlParameter cap = new SqlParameter("@capacidad", SqlDbType.SmallInt);
                        SqlParameter vel = new SqlParameter("@velocidad", SqlDbType.VarChar);
                        SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.Int);

                        cap.Value = capacidad.SelectedValue;
                        vel.Value = Velocidad.Text.Trim();
                        tipo.Value = tipos.SelectedValue;

                        lista = new List<SqlParameter>() { cap, vel, tipo };
                    }
                }
            }
            return lista;
        }

        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            operaciones(1);
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
                Alerta.Visible = false;
                int index = actualizar.SelectedIndex - 1;
                try
                {
                    Especial.Text = "ID: " + tabla.Rows[index]["id_RAM"].ToString();
                    capacidad.SelectedValue = tabla.Rows[index]["Capacidad"].ToString();
                    Velocidad.Text = tabla.Rows[index]["Velocidad"].ToString();
                    tipos.SelectedValue = tabla.Rows[index]["F_TipoR"].ToString();

                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
        }
    }
}