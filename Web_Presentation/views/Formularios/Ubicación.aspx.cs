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
    public partial class Ubicación : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataSet contenedor = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrops();
                Alerta.Visible = false;
            }
            else
            {
                contenedor = (DataSet)Session["Datos"];
            }
        }



        private void LlenarDrops()
        {
            string msg = "";
            string query = "select nombre_laboratorio as 'laboratorio' from laboratorio;" +
                " select num_inv as 'ID' from computadorafinal; select *  from ubicacion;";

            try
            {
                contenedor = bl.consultaSencilla(query, ref msg);
                if (contenedor != null)
                {
                    lab_DDL.Items.Clear();
                    inv_DDL.Items.Clear();
                    actualizar.Items.Clear();

                    lab_DDL.Items.Add("---Seleccione una opcion---");
                    inv_DDL.Items.Add("---Seleccione una opcion---");
                    actualizar.Items.Add("---Seleccione una opcion---");

                    foreach (DataRow row in contenedor.Tables[0].Rows)
                    {
                        lab_DDL.Items.Add(row["laboratorio"].ToString());
                    }
                    foreach(DataRow row1 in contenedor.Tables[1].Rows)
                    {
                        inv_DDL.Items.Add(row1["ID"].ToString());
                    }
                    ListItem item;
                    foreach (DataRow row in contenedor.Tables[2].Rows)
                    {
                        item= new ListItem(row["num_inv"].ToString() + "---" + row["nombre_laboratorio"], row["num_inv"].ToString());
                        
                        actualizar.Items.Add(item);
                    }
                    Session["Datos"] = contenedor;
                }
                else
                {
                    MessageBox(this, "No Hay datos   ---> Agruegue Datos en la tabla de computadora final y laboratorio");
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

        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if (inv_DDL.SelectedIndex == 0 | lab_DDL.SelectedIndex == 0)
            {
                lista = null;
            }
            else
            {
                Alerta.Visible = false;
                SqlParameter num_inv = new SqlParameter("@num", SqlDbType.VarChar);
                SqlParameter lab = new SqlParameter("@lab", SqlDbType.VarChar);

                num_inv.Value = inv_DDL.SelectedValue;
                lab.Value = lab_DDL.SelectedValue;

                lista = new List<SqlParameter>() { num_inv, lab };
            }
            return lista;
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            operaciones(0);
            LlenarDrops();
        }

        private void operaciones (int id)
        {
            string msg = "";
            List<SqlParameter> lista = getLista();
            bool resultado;
            if (lista != null)
            {
                Alerta.Visible = false;
                if (id == 1)
                {
                    resultado = bl.UpdateItem("Ubicacion", ref msg, lista);
                }
                else
                {
                    resultado = bl.InsertarItem("Ubicacion", ref msg, lista);
                }
                if (resultado)
                {
                    MessageBox(this, msg);
                    inv_DDL.SelectedIndex = 0;
                    lab_DDL.SelectedIndex = 0;
                    actualizar.SelectedIndex = 0;
                }
                else
                {
                    MessageBox(this, "Error: Surgio un erro al insertar los datos");
                }
            }
            else
            {
                Alerta.Visible = true;
            }
        }

        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            operaciones(1);
            LlenarDrops();
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
                    inv_DDL.SelectedValue = contenedor.Tables[2].Rows[index]["num_inv"].ToString();
                    lab_DDL.SelectedValue = contenedor.Tables[2].Rows[index]["nombre_laboratorio"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
        }
    }
}