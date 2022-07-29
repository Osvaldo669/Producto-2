using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Presentation.views.Operaciones
{
    public partial class Operaciones : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataSet contenedor = new DataSet();
        string msg ="";
        int tab = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LlenarDrop();
                ObtenerDatos();
            }
            else {
                contenedor = (DataSet)Session["Datos"];
                tab = (int)Session["Tabla_num"];
            }
                      
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {
            if (Query.SelectedIndex == 0)
            {
                MessageBox(this, "Seleccione una opcion correcta");
            }
            else
            {
                
                int tabla = Query.SelectedIndex - 1;
                Label1.Text = Query.SelectedValue;
                Session["Tabla_num"] = tabla;
                GridView1.DataSource = contenedor.Tables[tabla];
                GridView1.DataBind();
            }
        }

        private void ObtenerDatos()
        {
            try
            {
                contenedor = bl.Consulta_General(ref msg);
                Session["Datos"] = contenedor;
                Session["Tabla_num"] = tab;
            }
            catch (Exception ex)
            {
                MessageBox(this, "Error: " + ex.Message);
            }
        }
        private void LlenarDrop()
        {
            Query.Items.Clear();
            Query.Items.Add("---Seleccione una opcion---");
            Query.Items.Add("Componente");
            Query.Items.Add("Marca");
            Query.Items.Add("Monitor");
            Query.Items.Add("Teclado");
            Query.Items.Add("Mouse");
            Query.Items.Add("Gabinete");
            Query.Items.Add("Disco Duro");
            Query.Items.Add("Modelo CPU");
            Query.Items.Add("Tipo CPU");
            Query.Items.Add("Tipo RAM");
            Query.Items.Add("RAM");
            Query.Items.Add("CPU Génerico");
            Query.Items.Add("Actualización");
            Query.Items.Add("Laboratorio");
            Query.Items.Add("Ubicación");
            Query.Items.Add("Computadora Final");
            Query.Items.Add("Cantidad de disco duro");

        }
        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string msg = "";
            int index = Convert.ToInt32(e.RowIndex.ToString());
            string clave = Label1.Text;
            bool resultado = false;
            var id = GridView1.Rows[index].Cells[1].Text;
            try
            {
                resultado=bl.EliminarItem(clave, ref msg, id);
                if (resultado == true)
                {
                    MessageBox(this, msg);
                    ObtenerDatos();
                    Label1.Text = Label1.Text;
                    LlenarGrid();
                    
                }
                else
                {
                    MessageBox(this, "Error al eliminar!! existe un conflicto por las llaves foraneas");
                }
               
            }
            catch(Exception ex)
            {
                MessageBox(this,"Error: " +ex.Message);
            }

        }

        private void LlenarGrid()
        {
            GridView1.DataSource = contenedor.Tables[tab];
            GridView1.DataBind();
        }
    }
}