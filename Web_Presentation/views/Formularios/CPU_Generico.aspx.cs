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
    public partial class CPU_Generico : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataSet contenedor = new DataSet();
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrops();
                LlenarActualizar();
                Alerta.Visible = false;
            }
            else
            {
                contenedor = (DataSet)Session["Datos"];
                table=(DataTable)Session["datos_upd"];
            }
        }

        private void LlenarDrops()
        {
            string msg = "";
            string query1 = " select id_RAM as 'ID', Capacidad as 'C', t.Tipo as 'T' from RAM r join TipoRAM t on r.F_TipoR = t.id_tipoRam; ";
            string query2 = " select g.id_Gabinete as 'ID', g.Modelo as 'M', TipoForma as 'T', Marca as 'Mar' from Gabinete g join Marca m on g.F_Marca = m.Id_Marca;";
            string query3=" select id_Tcpu as 'ID', Tipo from Tipo_CPU t; ";
            string queryfinal = query1 + query2 + query3;
            try
            {
                contenedor = bl.consultaSencilla(queryfinal, ref msg);
                if (contenedor != null)
                {
                    tipo_DDL.Items.Add("---Seleccione una opcion---");
                    ram_DDL.Items.Add("---Seleccione una opcion---");
                    gabinete_DDL.Items.Add("---Seleccione una opcion---");

                    foreach (DataRow row in contenedor.Tables[0].Rows)
                    {
                        ListItem item = new ListItem(row["C"].ToString()+" GB--" + row["T"] ,row["ID"].ToString());
                        ram_DDL.Items.Add(item);
                    }
                    foreach (DataRow row1 in contenedor.Tables[1].Rows)
                    {
                        ListItem item = new ListItem(row1["M"].ToString() + "--" + row1["T"] + "--" + row1["Mar"], row1["ID"].ToString());
                        gabinete_DDL.Items.Add(item);
                    }
                    foreach(DataRow row2 in contenedor.Tables[2].Rows)
                    {
                        ListItem item = new ListItem(row2["Tipo"].ToString(), row2["ID"].ToString());
                        tipo_DDL.Items.Add(item);
                    }
                    Session["Datos"] = contenedor;
                }
                else
                {
                    MessageBox(this, "No Hay datos   ---> Agruegue Datos en la tabla de computadora final y laboratorio");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this, "Error: " + ex.Message);
            }
        }

        private void LlenarActualizar()
        {
            string msg = "";
            string query = "select *  from CPU_Generico";
            table = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in table.Rows)
            {
                actualizar.Items.Add(row["id_CPU"].ToString());
            }
            Session["datos_upd"] = table;
        }
        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            OperacionesTable(0);
            LlenarActualizar(); 
        }

        private void OperacionesTable(int tarea)
        {
            List<SqlParameter> lista = getLista();
            bool resultado;
            if (lista != null)
            {
                Alerta.Visible = true;
                string msg = "";
                if (tarea == 1)
                {
                    SqlParameter id_valor = new SqlParameter("@id", SqlDbType.VarChar);
                    id_valor.Value = actualizar.SelectedValue;
                    lista.Add(id_valor);
                    resultado = bl.UpdateItem("CPU Generico", ref msg, lista);
                }
                else
                {
                    resultado = bl.InsertarItem("CPU Generico", ref msg, lista);
                }
                if (resultado)
                {
                    MessageBox(this, msg);
                    tipo_DDL.SelectedIndex = 0;
                    ram_DDL.SelectedIndex = 0;
                    gabinete_DDL.SelectedIndex = 0;
                    modelo_TB.Text = "";
                    desc_TB.Text = "";
                    actualizar.SelectedIndex = 0;
                }
                else
                {
                    MessageBox(this, "Error al insertar los datos");
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

            if (tipo_DDL.SelectedIndex==0 | ram_DDL.SelectedIndex==0| gabinete_DDL.SelectedIndex == 0 
                | String.IsNullOrEmpty(modelo_TB.Text) | String.IsNullOrEmpty(desc_TB.Text) )
            {
                lista = null;
            }
            else
            {
                string cadena = modelo_TB.Text.Replace(" ", string.Empty);
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
                        SqlParameter tipo_cpu = new SqlParameter("@tipo", SqlDbType.Int);
                        SqlParameter ram = new SqlParameter("@ram", SqlDbType.Int);
                        SqlParameter gab = new SqlParameter("@gab", SqlDbType.Int);
                        SqlParameter modelo = new SqlParameter("@modelo", SqlDbType.VarChar);
                        SqlParameter desc = new SqlParameter("@desc", SqlDbType.VarChar);
                        SqlParameter image = new SqlParameter("@imagen", SqlDbType.VarChar);

                        tipo_cpu.Value = tipo_DDL.SelectedValue;
                        ram.Value = ram_DDL.SelectedValue;
                        gab.Value = gabinete_DDL.SelectedValue;

                        modelo.Value = modelo_TB.Text;
                        desc.Value = desc_TB.Text;
                        if (imagen.HasFile)
                        {
                            string fullpath1 = Server.MapPath(Request.ApplicationPath + "Cpu-Imagen/" + imagen.FileName);
                            imagen.SaveAs(fullpath1);
                            image.Value = "~/Cpu-Imagen/" + imagen.FileName;
                        }
                        else
                        {
                            image.Value = "";
                        }

                        lista = new List<SqlParameter>() { tipo_cpu,ram,gab,modelo,desc,image };
                    }
                }
            }

            return lista;
        }

        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            OperacionesTable(1);
            LlenarActualizar();
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
                try
                {
                    Especial.Text = "ID: " + table.Rows[index]["id_CPU"].ToString();
                    tipo_DDL.SelectedValue = table.Rows[index]["f_Tcpu"].ToString();
                    modelo_TB.Text = table.Rows[index]["Modelo"].ToString();
                    desc_TB.Text = table.Rows[index]["Descripcion"].ToString();
                    ram_DDL.SelectedValue = table.Rows[index]["f_tipoRam"].ToString();
                    gabinete_DDL.SelectedValue = table.Rows[index]["id_Gabinete"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
            }
        }
    }
}