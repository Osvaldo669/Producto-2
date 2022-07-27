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



    }
}
