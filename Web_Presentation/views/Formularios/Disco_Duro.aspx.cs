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
    public partial class Disco_Duro : System.Web.UI.Page
    {
        Clase_Negocios bl = new Clase_Negocios(System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Server"].ConnectionString);
        DataTable contenedor = new DataTable();
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
                contenedor = (DataTable)Session["Datos_a"];
                table = (DataTable)Session["datos_upd"];
                Especial.Text = "";
            }
        }

        private void LlenarActualizar()
        {
            string msg = "";
            string query = "select *  from DiscoDuro";
            table = bl.consultaSencilla(query, ref msg).Tables[0];
            actualizar.Items.Clear();
            actualizar.Items.Add("---Seleccione una opcion---");
            foreach (DataRow row in table.Rows)
            {
                actualizar.Items.Add(row["id_Disco"].ToString());
            }
            Session["datos_upd"] = table;
        }

        private void LlenarDrops()
        {
            string msg = "";

            try
            {
                contenedor = bl.getMarca(ref msg, 2);
                Marca_DDL.Items.Add("---Seleccione una opcion---");
                tipos_DDL.Items.Add("---Seleccione una opcion---");
                tipos_DDL.Items.Add("SSD");
                tipos_DDL.Items.Add("HDD");

                capacidad_DDL.Items.Add("---Seleccione una opcion (GB)---");
                capacidad_DDL.Items.Add("128");
                capacidad_DDL.Items.Add("256");
                capacidad_DDL.Items.Add("512");
                capacidad_DDL.Items.Add("1024");
                conector_DDL.Items.Add("---Seleccione una opcion---");
                conector_DDL.Items.Add("SATA");
                conector_DDL.Items.Add("PCI-e");
                conector_DDL.Items.Add("SCSI");

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
            OperacionesTablas(0);
            LlenarActualizar();
           
        }
        private void OperacionesTablas(int id)
        {
            string msg = "";
            List<SqlParameter> lista = getLista();
            bool resultado;
            if (lista != null)
            {
                try
                {
                    Alerta.Visible = false;
                    if(id == 1)
                    {
                        SqlParameter id_valor = new SqlParameter("@id", SqlDbType.Int);
                        id_valor.Value = actualizar.SelectedValue;
                        lista.Add(id_valor);
                        resultado = bl.UpdateItem("Disco Duro", ref msg, lista);

                    }
                    else
                    {
                        resultado = bl.InsertarItem("Disco Duro", ref msg, lista);
                    }


                    if (resultado)
                    {
                        MessageBox(this, msg);
                        Marca_DDL.SelectedIndex = 0;
                        tipos_DDL.SelectedIndex = 0;
                        capacidad_DDL.SelectedIndex = 0;
                        conector_DDL.SelectedIndex = 0;
                        Extra.Text = "";
                    }
                    else
                    {
                        MessageBox(this, "Error al insertar o realizar la operacion ");
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
            if (Marca_DDL.SelectedIndex == 0 | tipos_DDL.SelectedIndex == 0 |
              capacidad_DDL.SelectedIndex == 0 | conector_DDL.SelectedIndex == 0)
            {
                lista = null;
            }
            else
            {
                SqlParameter marca = new SqlParameter("@marca", SqlDbType.Int);
                SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar);
                SqlParameter capacidad = new SqlParameter("@capacidad", SqlDbType.Int);
                SqlParameter conector = new SqlParameter("@conector", SqlDbType.VarChar);
                SqlParameter extra = new SqlParameter("@extra", SqlDbType.VarChar);

                if (String.IsNullOrEmpty(Extra.Text))
                {
                    extra.Value = "";
                }
                else
                {
                    extra.Value = Extra.Text;
                }
                marca.Value = Marca_DDL.SelectedValue;
                tipo.Value = tipos_DDL.SelectedValue;
                capacidad.Value = capacidad_DDL.SelectedValue;
                conector.Value = conector_DDL.SelectedValue;

                lista = new List<SqlParameter>() { marca, tipo, conector, capacidad, extra };
            }
            return lista;
        }

        protected void actualizar_datos_Click(object sender, EventArgs e)
        {
            OperacionesTablas(1);
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
                    Especial.Text = "ID: " + table.Rows[index]["id_Disco"].ToString();
                    tipos_DDL.SelectedValue = table.Rows[index]["TipoDisco"].ToString();
                    conector_DDL.SelectedValue = table.Rows[index]["conector"].ToString();
                    Marca_DDL.SelectedValue = table.Rows[index]["F_MarcaDisco"].ToString();
                    capacidad_DDL.SelectedValue = table.Rows[index]["Capacidad"].ToString();
                    Extra.Text = table.Rows[index]["Extra"].ToString();
                }
                catch(Exception ex)
                {
                    MessageBox(this, ex.Message);
                }
               
            }
        }
    }
}