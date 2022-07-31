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
    public partial class CantDisco : System.Web.UI.Page
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
            string query = "select id_Disco as 'ID', TipoDisco as 'T',conector as 'C',Capacidad as 'CA', Marca.Marca as" +
                " 'M' from DiscoDuro join Marca on DiscoDuro.F_MarcaDisco = Marca.Id_Marca;" +
                " select num_inv as 'ID' from computadorafinal; select *  from cantDisc";

            try
            {
                contenedor = bl.consultaSencilla(query, ref msg);
                if (contenedor != null)
                {
                    disc_DDL.Items.Add("---Seleccione una opcion---");
                    inv_DDL.Items.Add("---Seleccione una opcion---");
                    actualizar.Items.Add("---Seleccione una opcion---");
                    ListItem item = null;
                    foreach (DataRow row in contenedor.Tables[0].Rows)
                    {
                        item = new ListItem(row["T"].ToString() +"---"+ row["C"] + "---" + row["CA"] +"---"+ row["M"],
                            row["ID"].ToString());
                        disc_DDL.Items.Add(item);
                    }
                    foreach (DataRow row1 in contenedor.Tables[1].Rows)
                    {
                        inv_DDL.Items.Add(row1["ID"].ToString());
                    }
                    foreach(DataRow row in contenedor.Tables[2].Rows)
                    {
                        actualizar.Items.Add(row["id_cant"].ToString());
                    }
                    Session["Datos"] = contenedor;
                }
                else
                {
                    MessageBox(this, "No Hay datos   ---> Agruegue Datos en la tabla de computadora final y Disco-Duro");
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
        

        private List<SqlParameter> getlista()
        {
            List<SqlParameter> lista = null;
            if (inv_DDL.SelectedIndex == 0 | disc_DDL.SelectedIndex == 0)
            {
                lista = null;
            }
            else
            {
                SqlParameter num_inv = new SqlParameter("@num", SqlDbType.VarChar);
                SqlParameter lab = new SqlParameter("@disc", SqlDbType.VarChar);

                num_inv.Value = inv_DDL.SelectedValue;
                lab.Value = disc_DDL.SelectedValue;

                lista = new List<SqlParameter>() { num_inv, lab };
            }
            return lista;
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            string msg = "";
            List<SqlParameter> lista = getlista();

            if (lista != null)
            {
                Alerta.Visible = false;
                bool resultado = bl.InsertarItem("Cantidad de disco duro", ref msg, lista);
                if (resultado)
                {
                    MessageBox(this, msg);
                    inv_DDL.SelectedIndex = 0;
                    disc_DDL.SelectedIndex = 0;
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

        protected void actualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizar.SelectedIndex == 0)
            {
                MessageBox(this, "Seleccione una opcion correcta");
            }
            else
            {
                int index = actualizar.SelectedIndex - 1;
                Especial.Text = "ID: " + contenedor.Tables[2].Rows[index]["id_cant"].ToString();
                inv_DDL.SelectedValue = contenedor.Tables[2].Rows[index]["num_inv"].ToString();
                disc_DDL.SelectedValue = contenedor.Tables[2].Rows[index]["id_Disco"].ToString();
                
            }
        }

        protected void guardar_datos_Click(object sender, EventArgs e)
        {
            string msg = "";
            List<SqlParameter> lista = getlista();
            SqlParameter id = new SqlParameter("@id",SqlDbType.Int);
            id.Value = actualizar.SelectedValue;
            lista.Add(id);
            if (lista != null)
            {
                Alerta.Visible = false;
                bool resultado = bl.UpdateItem("Cantidad de disco duro", ref msg, lista);
                if (resultado)
                {
                    MessageBox(this, msg);
                    inv_DDL.SelectedIndex = 0;
                    disc_DDL.SelectedIndex = 0;
                    actualizar.SelectedIndex = 0;
                }
                else
                {
                    MessageBox(this, "Error: Surgio un erro al actulizar los datos");
                }
            }
            else
            {
                Alerta.Visible = true;
            }
        }
    }
}