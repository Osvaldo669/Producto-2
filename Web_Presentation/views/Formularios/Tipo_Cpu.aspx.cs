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
    public partial class Tipo_Cpu : System.Web.UI.Page
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

        protected void modelo_cpu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(modelo_cpu.SelectedIndex == 0)
            {
                MessageBox(this, "Selecione una opcion correcta");
            }
            else
            {
                tipo_TB.Text = modelo_cpu.SelectedItem.ToString();
                tipo_TB.Enabled = false;
            }
        }

        private void LlenarDrops()
        {
            string msg = "";
            tipo_TB.Enabled = false;
            string query = "select id_modcpu as 'ID', modeloCPU as 'Modelo'  from ModeloCPU";
            try
            {
                contenedor = bl.consultaSencilla(query, ref msg).Tables[0];
                modelo_cpu.Items.Add("---Seleccione una opcion---");
                if (contenedor.Rows.Count > 0)
                {
                    ListItem item = null;
                    foreach (DataRow dr in contenedor.Rows)
                    {
                        item = new ListItem(dr["Modelo"].ToString(), dr["ID"].ToString());
                        modelo_cpu.Items.Add(item);
                    }

                    Session["Datos_a"] = contenedor;
                }
                else
                {
                    MessageBox(this, "No Hay datos   ---> Agregue una dato primero en la tabla Modelo CPU");
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
            bool resultado = false;
            string msg = "";
            if (String.IsNullOrEmpty(familia.Text) | modelo_cpu.SelectedIndex == 0 )
            {
                Alerta.Visible = true;
            }
            else
            {
                string cadena = familia.Text.Replace(" ", string.Empty);
                if (cadena.Length == 0)
                {
                    Alerta.Visible = true;
                    familia.Text = "";
                }
                else
                {
                    if (familia.Text == "")
                    {
                        Alerta.Visible = true;
                        familia.Text = "";
                    }
                    else
                    {
                        SqlParameter modelo = new SqlParameter("@modelo", SqlDbType.Int);
                        SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar);
                        SqlParameter vel = new SqlParameter("@vel", SqlDbType.VarChar);
                        SqlParameter fam = new SqlParameter("@fam", SqlDbType.VarChar);
                        SqlParameter extra = new SqlParameter("@extra", SqlDbType.VarChar);

                        if (String.IsNullOrEmpty(velocidad.Text))
                            vel.Value = " ";
                        else
                            vel.Value = velocidad.Text.Trim();

                        if (String.IsNullOrEmpty(extra_TB.Text))
                            extra.Value = "";
                        else
                            extra.Value = extra_TB.Text.Trim();

                        fam.Value = familia.Text.Trim();
                        tipo.Value = tipo_TB.Text;
                        modelo.Value = modelo_cpu.SelectedValue;
                        List<SqlParameter> lista = new List<SqlParameter>() { modelo,tipo,vel,fam,extra };

                        try
                        {
                            resultado = bl.InsertarItem("Tipo CPU", ref msg, lista);
                            if (resultado)
                            {
                                MessageBox(this, msg);
                                modelo_cpu.SelectedIndex = 0;
                                familia.Text = "";
                                velocidad.Text = "";
                                tipo_TB.Text = "";
                                extra_TB.Text = "";
                            }
                            else
                            {
                                MessageBox(this, "Error: Al insertar el item");
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
}