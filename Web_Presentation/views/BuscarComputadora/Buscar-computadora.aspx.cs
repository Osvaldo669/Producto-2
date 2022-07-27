using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation.views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Alerta.Visible = false;
                informacionPC.Visible = false;
            }
        }

        protected void BuscarComputadora_Btn_Click(object sender, EventArgs e)
        {
            string msg = "";
           
            DataSet data = null;
            DataTable table = null;
            List<SqlParameter> sqls = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@num_inv", SqlDbType.VarChar, 10);
            if (String.IsNullOrEmpty(Buscar_Computadora_textbox.Text)|Buscar_Computadora_textbox.Text=="")
            {
                Alerta.Visible = true;
            }
            else
            {
                Alerta.Visible = false;
                try
                {
                    parameter.Value = Buscar_Computadora_textbox.Text;
                    sqls.Add(parameter);
                    data = bl.ConsultaJoin(ref msg, sqls);
                    table = data.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        informacionPC.Visible = true;
                        Label1.Text = table.Rows[0]["Numero de inventario"].ToString();
                        if (String.IsNullOrEmpty((data.Tables[0].Rows[0]["imagen1"].ToString())))
                        {
                            imagen_PC.Src = "https://www.tecnologia-informatica.com/wp-content/uploads/2018/08/caracteristicas-de-las-computadoras-1.jpeg";
                        }
                        else
                        {
                            imagen_PC.Src = table.Rows[0]["imagen1"].ToString();
                        }
                        Label2.Text = "Mouse-Marca: " + table.Rows[0]["Mouse"] + ", N°: " + table.Rows[0]["N° mouse"];
                        Label3.Text = "Monitor-Marca: " + table.Rows[0]["Monitor Marca"] + ", N°: " + table.Rows[0]["N° Monitor"] +", \n Tamaño: " + table.Rows[0]["Tamaño"];
                        Label4.Text = "Teclado-Marca: " + table.Rows[0]["Teclado"] + ", N°: " + table.Rows[0]["N° Teclado"];
                        Label5.Text = "Modelo-Procesador: " + table.Rows[0]["Marca Procesador"] + " " + table.Rows[0]["Modelo Procesador"];
                        Label6.Text = "Memoria Ram: " + table.Rows[0]["Cantidad RAM (GB)"] + " GB ";
                        Label7.Text = "Estado de la maquina: " + table.Rows[0]["Estado"]; 
                        Label10.Text = "Laboratorio: " + table.Rows[0]["Laboratorio"];
                        Label8.Text = "Cantidad de Discos Duro: " + table.Rows[0][" Cantidad Discos"].ToString();
                        Label9.Text = "Capacidad de Disco Duro: " + table.Rows[0]["Capacidad Total (GB)"].ToString();
                        
                    }   
                    else
                    {
                        MessageBox(this, "Computadora no encontrada o numero de inventario incorrecto");
                        informacionPC.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
           
        }

        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

        }
    }
}