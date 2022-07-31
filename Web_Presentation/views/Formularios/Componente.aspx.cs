﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            List<SqlParameter> lista = getLista();
            string msg = "";
            bool resultado = false;
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
    }
}