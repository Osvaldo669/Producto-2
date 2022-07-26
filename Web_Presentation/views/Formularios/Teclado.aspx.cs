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
    public partial class Teclado : System.Web.UI.Page
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
            string query = "select *  from teclado";
            tabla = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in tabla.Rows)
            {
                actualizar.Items.Add(row["id_teclado"].ToString());
            }
            Session["datos_upd"] = tabla;
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
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
                Alerta.Visible = true;
                try
                {
                    if (id == 1)
                    {
                        SqlParameter id_valor = new SqlParameter("@id", SqlDbType.Int);
                        id_valor.Value = actualizar.SelectedValue;
                        lista.Add(id_valor);
                        resultado = bl.UpdateItem("Teclado", ref msg, lista);
                    }
                    else
                    {
                        resultado = bl.InsertarItem("Teclado", ref msg, lista);
                    }
                    if (resultado)
                        MessageBox(this, msg);
                    else
                        MessageBox(this, "No se pudo realizar la operacion");

                    Marca.SelectedIndex = 0;
                    Conector.SelectedIndex = 0;
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
            if (Marca.SelectedIndex == 0 | Conector.SelectedIndex == 0)
            {
                lista = null;
            }
            else
            {
                SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);
                SqlParameter conector = new SqlParameter("@conector", SqlDbType.VarChar);
                marca.Value = Convert.ToInt16(Marca.SelectedItem.Value);
                conector.Value = Conector.SelectedValue;
                lista = new List<SqlParameter>()
                {
                    marca,conector
                };
            }
            return lista;
        }

        private void LlenarDrops()
        {
            string msg = "";
            try
            {
                contenedor = bl.getMarca(ref msg, 5);
                Marca.Items.Add("---Seleccione una opcion---");
                Conector.Items.Add("---Seleccione una opcion---");
                Conector.Items.Add("PS27");
                Conector.Items.Add("USB");
                Conector.Items.Add("USB 2.0");
                Conector.Items.Add("USB 3.0");
                Conector.Items.Add("Bluetooth");
                if (contenedor.Rows.Count > 0)
                {
                    ListItem item = null;
                    foreach (DataRow dr in contenedor.Rows)
                    {
                        item = new ListItem(dr["Marca"].ToString(), dr["ID"].ToString());
                        Marca.Items.Add(item);
                    }
                    Session["Datos_a"] = contenedor;
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
                    Especial.Text = "ID: " + tabla.Rows[index]["id_teclado"].ToString();
                    Marca.SelectedValue = tabla.Rows[index]["f_marcat"].ToString();
                    Conector.SelectedValue = tabla.Rows[index]["conector"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }

            }
        }
    }
}