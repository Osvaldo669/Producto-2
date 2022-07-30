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
    public partial class Gabinete : System.Web.UI.Page
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
                contenedor = bl.getMarca(ref msg, 6);
                Marca_DDL.Items.Add("---Seleccione una opcion---");
                Tipo_DDL.Items.Add("---Seleccione una opcion---");
                Tipo_DDL.Items.Add("Mini ATX");
                Tipo_DDL.Items.Add("Micro-ATX");
                Tipo_DDL.Items.Add("ATX");
                Tipo_DDL.Items.Add("Media Torre");
                Tipo_DDL.Items.Add("Torre");
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
                    MessageBox(this, "No existen Marcas que se asocian con marcas de tipo Gabinete--- Agregue una marca de gabinete primero");
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
            string msg = "";
            bool resultado = false;
            if (Marca_DDL.SelectedIndex == 0 | Tipo_DDL.SelectedIndex == 0 | String.IsNullOrEmpty(Modelo_TB.Text))
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
                    try
                    {
                        SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);
                        SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar);
                        SqlParameter modelo = new SqlParameter("@modelo", SqlDbType.VarChar);

                        marca.Value = Marca_DDL.SelectedValue;
                        tipo.Value = Tipo_DDL.SelectedValue;
                        modelo.Value = Modelo_TB.Text.Trim();

                        List<SqlParameter> lista = new List<SqlParameter>()
                        {
                            marca,tipo,modelo
                        };
                        resultado = bl.InsertarItem("Gabinete",ref msg, lista);
                        if (resultado==true)
                        {
                            MessageBox(this, msg);
                        }
                        else
                        {

                            MessageBox(this, "Solo se permiten 10 caracteres en el modelo");
                        }

                    }
                    catch(Exception ex)
                    {
                        MessageBox(this, "Error: " + ex.Message);
                    }
                }
            }
        }
    }
}