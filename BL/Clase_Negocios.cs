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

       



    }
}
