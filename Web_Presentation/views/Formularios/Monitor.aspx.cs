﻿using BL;
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
    public partial class Monitor : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable contenedor = new DataTable();
        DataTable tabla = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                LlenarDrops();
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
            string query = "select *  from monitor";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in tabla.Rows)
            {
                actualizar.Items.Add(row["id_monitor"].ToString());
            }
            Session["datos_upd"] = tabla;
        }
        private void LlenarDrops()
        {
            string msg = "";
            try
            {
                contenedor = bl.getMarca(ref msg, 4);
                Marca_monitor.Items.Add("---Seleccione una opcion---");
                Tipo_conector.Items.Add("---Seleccione una opcion---");
                Tamano_monitor.Items.Add("---Seleccione una opcion---");
                //Valores
                Tipo_conector.Items.Add("HDMI");
                Tipo_conector.Items.Add("VGA");
                Tipo_conector.Items.Add("DVI-I");
                Tipo_conector.Items.Add("DisplayPort");
                Tipo_conector.Items.Add("Mini DisplayPort");
                //
                Tamano_monitor.Items.Add("852x480");
                Tamano_monitor.Items.Add("896x504");
                Tamano_monitor.Items.Add("1024x576");
                Tamano_monitor.Items.Add("1365x768");
                Tamano_monitor.Items.Add("1280x720");
                Tamano_monitor.Items.Add("1600x900");
                Tamano_monitor.Items.Add("1664x936");
                Tamano_monitor.Items.Add("1792x1008");
                Tamano_monitor.Items.Add("1920x1080");
                Session["Datos_a"] = contenedor;
                if (contenedor.Rows.Count > 0)
                {
                    ListItem item = null;
                    foreach (DataRow dr in contenedor.Rows)
                    {
                        item = new ListItem(dr["Marca"].ToString(), dr["ID"].ToString());
                        Marca_monitor.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox(this, "No existen Marcas que se asocian con marcas de tipo Monitor");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this, ex.Message);
            }
        }
        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            operaciones
                (0);
            LlenarActualizar();
        }

        private void operaciones(int id)
        {
            string msg = "";
            List<SqlParameter> lista = getLista();
            bool resultado = false;
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
                        resultado = bl.UpdateItem("Monitor", ref msg, lista);
                    }
                    else
                    {
                        resultado = bl.InsertarItem("Monitor", ref msg, lista);
                    }
                    if (resultado)
                        MessageBox(this, msg);
                    else
                        MessageBox(this, "Error al insertar");

                    Marca_monitor.SelectedIndex = 0;
                    Tipo_conector.SelectedIndex = 0;
                    Tamano_monitor.SelectedIndex = 0;
                    actualizar.SelectedIndex = 0;
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
            if (Tipo_conector.SelectedIndex == 0 | Marca_monitor.SelectedIndex == 0 | Tamano_monitor.SelectedIndex == 0)
            {
                Alerta.Visible = true;
            }
            else
            {
                Alerta.Visible = false;
                

                SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);
                SqlParameter conector = new SqlParameter("@conector", SqlDbType.VarChar);
                SqlParameter tamano = new SqlParameter("@tamano", SqlDbType.VarChar);

                marca.Value = int.Parse(Marca_monitor.SelectedItem.Value);
                conector.Value = Tipo_conector.SelectedValue;
                tamano.Value = Tamano_monitor.SelectedValue;
                lista = new List<SqlParameter>() { marca,conector,tamano };
               
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
                    Especial.Text = "ID: " + tabla.Rows[index]["id_monitor"].ToString();
                    Marca_monitor.SelectedValue = tabla.Rows[index]["f_marcam"].ToString();
                    Tipo_conector.SelectedValue = tabla.Rows[index]["conectores"].ToString();
                    Tamano_monitor.SelectedValue = tabla.Rows[index]["tamano"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
        }
    }
}