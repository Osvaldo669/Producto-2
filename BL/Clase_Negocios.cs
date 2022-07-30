using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    
    public class Clase_Negocios
    {
        private string cadenaDB;
        AccesoDatos accesoDatos;
        private List<string> querys_strings = new List<string>()
        {
            "select * from Componente",
            "select * from Marca ",
            "select * from Monitor",
            "select * from Teclado",
            "select * from Mouse",
            "select * from Gabinete",
            "select * from DiscoDuro",
            "select * from ModeloCpu",
            "select * from Tipo_Cpu",
            "select * from TipoRAM",
            "select * from RAM",
            "select * from CPU_Generico",
            "select * from Actualizacion",
            "select * from Laboratorio",
            "select * from Ubicacion",
            "select * from ComputadoraFinal",
            "select * from cantDisc",

        };
        public Clase_Negocios(string cadena)
        {
            this.cadenaDB = cadena;
            accesoDatos = new AccesoDatos(cadenaDB);
        }

        public DataSet Consulta_General(ref string msg)
        {
            DataSet container = null;
            container = accesoDatos.ConsultaGeneral(querys_strings, ref msg);
            return container;
        }

        public DataSet consultaSencilla(string query, ref string msg)
        {
            DataSet data = null;
            List<SqlParameter> lista_Provisional = new List<SqlParameter>();
            data = accesoDatos.Innner_consulta(query, ref msg, lista_Provisional);
            return data;
        }

        public DataSet ConsultaJoin(ref string msg, List<SqlParameter> parameters)
        {
            DataSet dataSet = null;
            string query = "select top 1 c.num_inv as 'Numero de inventario',mou.Marca as 'Mouse'," +
                "c.num_smouse as 'N° mouse',moni.Marca as 'Monitor Marca',c.num_smonitor as 'N° Monitor'," +
                "monitor.tamano as 'Tamaño',tec.Marca as 'Teclado',c.num_steclado as 'N° Teclado',CPU_Generico.Modelo as" +
                " 'Modelo Procesador',cpu.Marca as 'Marca Procesador',RAM.Capacidad as 'Cantidad RAM (GB)',c.ubicacion as 'Laboratorio'," +
                "Estado.Estado as 'Estado',(select COUNT(*) from cantDisc where cantDisc.num_inv = c.num_inv) as ' Cantidad Discos'," +
                "(Select SUM(Capacidad) from DiscoDuro join cantDisc on cantDisc.id_Disco = DiscoDuro.id_Disco join computadorafinal on " +
                "cantDisc.num_inv = computadorafinal.num_inv where computadorafinal.num_inv=c.num_inv)as 'Capacidad Total (GB)'," +
                "c.imagen1,c.imagen2,c.imagen3 from computadorafinal c " +
                "join mouse  on mouse.id_mouse=c.id_mousg join monitor on monitor.id_monitor =c.id_mong " +
                "join teclado on teclado.id_teclado =c.id_tecladog join CPU_Generico on CPU_Generico.id_CPU = c.id_cpug " +
                "join RAM on RAM.id_RAM =CPU_Generico.f_tipoRam join cantDisc on cantDisc.num_inv = c.num_inv " +
                "join DiscoDuro on DiscoDuro.id_Disco = cantDisc.id_Disco join Estado on Estado.id_estado = c.Estado " +
                "join Marca mou on mou.Id_Marca = mouse.f_marcamouse join Marca moni on moni.Id_Marca = monitor.f_marcam " +
                "join Marca tec on tec.Id_Marca = teclado.f_marcat join Tipo_CPU on Tipo_CPU.id_Tcpu = CPU_Generico.f_Tcpu " +
                "join ModeloCPU on ModeloCPU.id_modcpu = Tipo_CPU.f_id_modcpu join Marca cpu on cpu.Id_Marca= ModeloCPU.f_marca " +
                "where c.num_inv =@num_inv ";
            dataSet = accesoDatos.Innner_consulta(query, ref msg, parameters);
            return dataSet;
        }

        public DataSet ConsultaJoin_Sencilla(string clave,ref string msg, List<SqlParameter> parameters)
        {
            DataSet data = null;
            string query = "";
            switch (clave)
            {
                case "lab":
                    query = "select num_inv,es.Estado 'Estado Computadora'," +
                    "imagen1 from computadorafinal join Estado es on es.id_estado = computadorafinal.Estado " +
                    "where computadorafinal.ubicacion = @clave";
                    break;

                case "disco":
                    query = "Select TipoDisco as 'Tipo',com.num_inv as 'N° de inventario',es.Estado 'Estado Computadora',com.imagen1 as 'Imagen'" +
                        "from DiscoDuro join cantDisc cant on cant.id_Disco = DiscoDuro.id_Disco join computadorafinal com on cant.num_inv = com.num_inv " +
                        "join Estado es on es.id_estado = com.Estado where DiscoDuro.TipoDisco = @disco and com.ubicacion = @lab";
                    break;
                case "monitor":
                    query = "select c.num_inv as 'N° inventario',es.Estado 'Estado Computadora',c.ubicacion as 'Laboratorio',monitor.tamano as 'Tamaño' from monitor " +
                        "join computadorafinal c on c.id_mong = monitor.id_monitor join Estado es on es.id_estado = c.Estado " +
                        "where monitor.tamano = @monitor";
                    break;
                case "actualizacion":
                    query = "select a.num_serie as 'N° de Serie', a.descripcion as 'Descripcion',a.fecha as 'Fecha'," +
                        "c.num_inv as 'N° inventario',c.ubicacion as 'Ubicacion',c.imagen1 " +
                        "from actualizacion a " +
                        "join computadorafinal c on a.num_inv = c.num_inv " +
                        "where a.num_inv = @clave";
                    break;
            }
            data = accesoDatos.Innner_consulta(query,ref msg, parameters);
            return data;
        }

        public bool EliminarItem(string clave,ref string msg, string parametro)
        {
            bool resultado = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            string query = "";
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@id";
            switch (clave)
            {
                case "Componente":
                    parameter.Value = Convert.ToInt32(parametro);
                     query = "delete  from Componente where Id_Componente=@id";
                        break;
                case "Marca":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from Marca where Id_Marca =@id";
                    break;
                case "Monitor":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from Monitor where id_monitor =@id";
                    break;
                case "Teclado":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from teclado where id_teclado =@id";
                    break;
                case "Mouse"://Metodo funcionando
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete from mouse where id_mouse=@id";
                    break;
                case "Gabinete":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from Gabinete where id_Gabinete =@id";
                    break;
                case "Disco Duro":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from DiscoDuro where id_Disco =@id";
                    break;
                case "Modelo CPU":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from ModeloCpu where id_modcpu =@id";
                    break;
                case "Tipo CPU":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from Tipo_Cpu where id_Tcpu =@id";
                    break;
                case "Tipo RAM":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from TipoRAM where id_tipoRam =@id";
                    break;
                case "RAM":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from RAM where id_RAM =@id";
                    break;
                case "CPU Génerico":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from CPU_Generico where id_CPU =@id";
                    break;
                case "Actualización":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from actualizacion where id_act =@id";
                    break;
                case "Laboratorio":
                    parameter.Value = parametro;
                    query = "delete  from laboratorio where nombre_laboratorio =@id";
                    break;
                case "Ubicación":
                    parameter.Value = parametro;
                    query = "delete  from ubicacion where num_inv =@id";
                    break;
                case "Computadora Final":
                    parameter.Value = parametro;
                    query = "delete  from computadorafinal where num_inv =@id";
                    break;
                case "Cantidad de disco duro":
                    parameter.Value = Convert.ToInt32(parametro);
                    query = "delete  from cantDisc where id_cant =@id";
                    break;
            }
            parameters.Add(parameter);

            resultado = accesoDatos.Operaciones_Tables(query,ref msg, parameters);
            return resultado;
        }

        public bool InsertarItem(string clave, ref string msg, List<SqlParameter> sqlParameters)
        {
            bool resultado = false;
            string query = "";
            switch (clave)
            {
                case "Componente":
                    query = "insert into Componente values(@componente,@extra)";
                    break;

                case "Marca":
                    query = "insert into Marca values(@marca,@componente,@extra);";
                    break;

                case "Monitor":
                    query = "insert into monitor values(@marca,@conector,@tamano);";
                    break;

                case "Teclado":
                    query = "insert into teclado values(@marca,@conector)";
                    break;

                case "Mouse":
                    query = "insert into mouse values(@marca, @conector)";
                    break;

                case "Gabinete":
                    query = "insert into Gabinete values(@modelo,@tipo, @marca);";
                    break;

                case "Disco Duro":
                    query = "";
                    break;

                case "Modelo CPU":
                    query = "insert into ModeloCPU values (@modelo,@marca)";
                    break;

                case "Tipo CPU":
                    query = "";
                    break;

                case "Tipo RAM":
                    query = "insert into TipoRAM values(@tipo,@extra);";
                    break;

                case "RAM":
                    query = "insert into RAM values(@capacidad,@velocidad,@tipo)";
                    break;

                case "CPU Génerico":
                    query = "";
                    break;

                case "Actualización":
                    query = "";
                    break;

                case "Laboratorio":
                    query = "insert into laboratorio values(@lab);";
                    break;

                case "Ubicación":
                    query = "";
                    break;

                case "Computadora Final":
                    query = "";
                    break;

                case "Cantidad de disco duro":
                    query = "";
                    break;
            }
            resultado = accesoDatos.Operaciones_Tables(query, ref msg, sqlParameters);
            return resultado;
        }

        public DataTable getMarca( ref string msg,int parametro)
        {
            string query = "select m.Id_Marca as 'ID', Marca from marca m join Componente c on c.Id_Componente=m.f_Id_Componente where f_Id_Componente=@id";
            DataTable data;
            List<SqlParameter> lista_Provisional = new List<SqlParameter>();
            SqlParameter sqlparametro = new SqlParameter("@id",SqlDbType.Int);
            sqlparametro.Value=parametro;
            lista_Provisional.Add(sqlparametro);
            data = accesoDatos.Innner_consulta(query, ref msg, lista_Provisional).Tables[0];
            return data;
        }


        



    }
}
