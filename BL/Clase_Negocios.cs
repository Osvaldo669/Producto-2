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

        public Clase_Negocios(string cadena)
        {
            this.cadenaDB = cadena;
            accesoDatos = new AccesoDatos(cadenaDB);
        }


        public string Connection()
        {
            return accesoDatos.AbrirConexion();
        }

        public DataSet Consulta_General(string clave_palabre, ref string msg)
        {
            DataSet container = null;
            string query = "";
            switch (clave_palabre)
            {
                case "Componente":
                    query = "select * from Componente";
                    break;
                case "Marca":
                    query = "select * from Marca ";
                    break;
                case "Monitor":
                    query = "select * from Monitor";
                    break ;
                case "Teclado":
                    query = "select * from Teclado";
                    break;
                case "Mouse":
                    query = "select * from Mouse";
                    break;
                case "Gabinete":
                    query = "select * from Gabinete";
                    break;
                case "DiscoDuro":
                    query = "select * from DiscoDuro";
                    break;
                case "ModeloCpu":
                    query = "select * from ModeloCpu";
                    break;
                case "Tipo_Cpu":
                    query = "select * from Tipo_Cpu";
                    break;
                case "TipoRAM":
                    query = "select * from TipoRAM";
                    break;
                case "RAM":
                    query = "select * from RAM";
                    break;
                case "CPU_Generico":
                    query = "select * from CPU_Generico";
                    break;
                case "Actualizacion":
                    query = "select * from Actualizacion";
                    break;
                case "Laboratorio":
                    query = "select * from Laboratorio";
                    break;
                case "Ubicacion":
                    query = "select * from Ubicacion";
                    break;
                case "ComputadoraFinal":
                    query = "select * from ComputadoraFinal";
                    break;
                case "CantDisc":
                    query = "select * from cantDisc";
                    break;

            }
            container= accesoDatos.ConsultaGeneral(query, ref msg);
            return container;
        }



    }
}
