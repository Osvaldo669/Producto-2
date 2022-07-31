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
    public partial class ComputadoraFinal : System.Web.UI.Page
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
            string query1 = " select id_CPU as 'ID', Modelo from CPU_Generico;";//
            string query2 = " select t.id_teclado as 'ID', conector as 'C', m.Marca as 'M' from teclado t join Marca m on t.f_marcat = m.Id_Marca;";//
            string query3 = " select t.id_mouse as 'ID', conector as 'C', m.Marca as 'M' from mouse t join Marca m on t.f_marcamouse = m.Id_Marca;";//
            string query4 = " select id_monitor as 'ID', conectores as 'C', tamano as 'T', Marca as 'M' from monitor join Marca m on f_marcam = m.Id_Marca;";
            string query5 = " select nombre_laboratorio as 'N' from laboratorio;";//
            string query6 = " select id_estado as 'ID', Estado from Estado;";//
            string select = query1+query2+query3+query4+query5+query6;

            try
            {
                contenedor = bl.consultaSencilla(select, ref msg);
                if (contenedor != null)
                {
                    monitor_DDL.Items.Add("---Seleccione una opcion---");
                    mouse_DDL.Items.Add("---Seleccione una opcion---");
                    cpu_DDL.Items.Add("---Seleccione una opcion---");
                    estado_DDL.Items.Add("---Seleccione una opcion---");
                    teclado_DDL.Items.Add("---Seleccione una opcion---");
                    ubicacion_DDL.Items.Add("---Seleccione una opcion---");

                    foreach (DataRow row in contenedor.Tables[0].Rows)
                    {
                        ListItem item = new ListItem(row["Modelo"].ToString(), row["ID"].ToString());
                        cpu_DDL.Items.Add(item);
                    }
                    foreach (DataRow row1 in contenedor.Tables[1].Rows)
                    {
                        ListItem item = new ListItem(row1["C"].ToString() + "--" + row1["M"], row1["ID"].ToString());
                        teclado_DDL.Items.Add(item);
                    }
                    foreach (DataRow row2 in contenedor.Tables[2].Rows)
                    {
                        ListItem item = new ListItem(row2["C"].ToString() + "--" + row2["M"] , row2["ID"].ToString());
                        mouse_DDL.Items.Add(item);
                    }
                    foreach (DataRow row in contenedor.Tables[3].Rows)
                    {
                        ListItem item = new ListItem(row["C"].ToString() + "--" + row["M"] + "--"+row["T"] , row["ID"].ToString());
                        monitor_DDL.Items.Add(item);
                    }
                    foreach (DataRow row3 in contenedor.Tables[4].Rows)
                    {
                        ubicacion_DDL.Items.Add(row3["N"].ToString());
                    }
                    foreach (DataRow row4 in contenedor.Tables[5].Rows)
                    {
                        ListItem item = new ListItem(row4["Estado"].ToString(), row4["ID"].ToString());
                        estado_DDL.Items.Add(item);
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

        public static void MessageBox(System.Web.UI.Page page, string Msg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + Msg + "')", true);
        }


        private List<SqlParameter> getLista()
        {
            List<SqlParameter> lista = null;
            if(String.IsNullOrEmpty(inv_TB.Text) |String.IsNullOrEmpty(num_CPU.Text)| cpu_DDL.SelectedIndex==0|
                String.IsNullOrEmpty(num_Teclado.Text) | teclado_DDL.SelectedIndex==0 | String.IsNullOrEmpty(num_Monitor.Text) |
                monitor_DDL.SelectedIndex==0 | String.IsNullOrEmpty(num_Mouse.Text)| mouse_DDL.SelectedIndex==0|
                estado_DDL.SelectedIndex==0| ubicacion_DDL.SelectedIndex == 0)
            {
                Alerta.Visible = true;
                lista = null;
            }
            else
            {
                Alerta.Visible = false;
                string num_inv = inv_TB.Text.Replace(" ", string.Empty);
                string tec = num_Teclado.Text.Replace(" ", string.Empty);
                string cpu = num_CPU.Text.Replace(" ", string.Empty);
                string moni = num_Monitor.Text.Replace(" ", string.Empty);
                string mouse = num_Mouse.Text.Replace(" ", string.Empty);
                if (num_inv.Length ==0)
                {
                    Alerta.Visible = true;
                    lista = null;
                }
                else if(tec.Length==0)
                {
                    Alerta.Visible = true;
                    lista = null;
                }
                else if (cpu.Length == 0)
                {
                    Alerta.Visible = true;
                    lista = null;
                }
                else if (moni.Length == 0)
                {
                    Alerta.Visible = true;
                    lista = null;
                }
                else if (mouse.Length == 0)
                {
                    Alerta.Visible = true;
                    lista = null;
                }
                else
                {
                    //insert into computadorafinal values(@inv,@cpu,@t_cpu,@teclado,@t_tec,@monitor,@t_mon,@mouse_num,@t_mouse,@ubicacion,@ima_1,@ima_2,@ima_3,@estado);
                    SqlParameter inv = new SqlParameter("@inv", SqlDbType.VarChar);//
                    SqlParameter numcpu = new SqlParameter("@cpu", SqlDbType.VarChar);//
                    SqlParameter t_cpu = new SqlParameter("@t_cpu", SqlDbType.Int);//
                    SqlParameter teclado = new SqlParameter("@teclado", SqlDbType.VarChar);//
                    SqlParameter t_tec = new SqlParameter("@t_tec", SqlDbType.Int);//
                    SqlParameter monitor = new SqlParameter("@monitor", SqlDbType.VarChar);//
                    SqlParameter t_mon = new SqlParameter("@t_mon", SqlDbType.Int);//
                    SqlParameter mouse_num = new SqlParameter("@mouse_num", SqlDbType.VarChar);//
                    SqlParameter t_mouse = new SqlParameter("@t_mouse", SqlDbType.Int);//
                    SqlParameter estado = new SqlParameter("@estado", SqlDbType.Int);//
                    SqlParameter ubicacion = new SqlParameter("@ubicacion", SqlDbType.VarChar);//
                    SqlParameter ima_1 = new SqlParameter("@ima_1", SqlDbType.VarChar);
                    SqlParameter ima_2 = new SqlParameter("@ima_2", SqlDbType.VarChar);
                    SqlParameter ima_3 = new SqlParameter("@ima_3", SqlDbType.VarChar);

                    //Valores

                    inv.Value = inv_TB.Text.Trim();
                    numcpu.Value = num_CPU.Text.Trim();
                    t_cpu.Value = cpu_DDL.SelectedValue;
                    teclado.Value = num_Teclado.Text.Trim();
                    t_tec.Value = teclado_DDL.SelectedValue;
                    monitor.Value = num_Monitor.Text.Trim();
                    t_mon.Value = monitor_DDL.SelectedValue;
                    mouse_num.Value = num_Mouse.Text.Trim();
                    t_mouse.Value = mouse_DDL.SelectedValue;
                    estado.Value = estado_DDL.SelectedValue;
                    ubicacion.Value = ubicacion_DDL.SelectedValue;

                    //Lista
                    lista = new List<SqlParameter>() {
                        inv,numcpu,t_cpu,teclado,t_tec,monitor,t_mon,mouse_num,t_mouse,estado,ubicacion
                    };


                    if (imagen1.HasFile)
                    {
                        string fullpath = Server.MapPath(Request.ApplicationPath + "Pc-Imagen/" + inv_TB.Text.Trim()+"-"+ imagen1.FileName);
                        imagen1.SaveAs(fullpath);
                        ima_1.Value = "~/Pc-Imagen/"+ inv_TB.Text.Trim() + "-" + imagen1.FileName;
                        lista.Add(ima_1);
                    }
                    else
                    {
                        ima_1.Value = "";
                        lista.Add(ima_1);
                    }
                    if (imagen2.HasFile)
                    {
                        string fullpath = Server.MapPath(Request.ApplicationPath + "Pc-Imagen/" + inv_TB.Text.Trim() + "-" + imagen2.FileName);
                        imagen2.SaveAs(fullpath);
                        ima_2.Value = "~/Pc-Imagen/" + inv_TB.Text.Trim() + "-" + imagen2.FileName;
                        lista.Add(ima_2);
                    }
                    else
                    {
                        ima_2.Value = "";
                        lista.Add(ima_2);
                    }
                    if (imagen3.HasFile)
                    {
                        string fullpath = Server.MapPath(Request.ApplicationPath + "Pc-Imagen/" + inv_TB.Text.Trim() + "-" + imagen3.FileName);
                        imagen3.SaveAs(fullpath);
                        ima_3.Value = "~/Pc-Imagen/" + inv_TB.Text.Trim() + "-" + imagen3.FileName;
                        lista.Add(ima_3);
                    }
                    else
                    {
                        ima_3.Value = "";
                        lista.Add(ima_3);
                    }

                }
            }
            return lista;
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            List<SqlParameter> lista = getLista();
            if (lista != null)
            {
                Alerta.Visible = false;
                string msg = "";
                bool resultado = bl.InsertarItem("Computadora Final", ref msg, lista);
                if (resultado)
                {
                    MessageBox(this, msg);
                    inv_TB.Text = "";
                    (num_CPU.Text) = "";
                    cpu_DDL.SelectedIndex = 0;
                    (num_Teclado.Text) = "";
                    teclado_DDL.SelectedIndex = 0;
                    (num_Monitor.Text) = "";
                    monitor_DDL.SelectedIndex = 0;
                    (num_Mouse.Text) = "";
                    mouse_DDL.SelectedIndex = 0;
                    estado_DDL.SelectedIndex = 0;
                    ubicacion_DDL.SelectedIndex = 0;
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
    }
}