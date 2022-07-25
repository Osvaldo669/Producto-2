using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AccesoDatos
    {
        private Equipo a;
        private string cadenaDB;
        SqlConnection connection;
        public AccesoDatos(string cadena)
        {
            connection = new SqlConnection();
            cadenaDB = cadena;
        }

        public string AbrirConexion()
        {
            string msg = "";
            connection.ConnectionString = cadenaDB;
            try
            {
                connection.Open();
                msg = "Conexion Abierta";
            }
            catch(Exception ex)
            {
                msg = "Error: " + ex.Message;
            }
            return msg;
        }
        public void CerrarConexion()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public DataSet ConsultaGeneral(string query, ref string msg)
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = null;
            msg = AbrirConexion();

            if (connection == null)
            {
                msg = "Sin Conexion a la Base de Datos";
                dataSet = null;
            }
            else
            {
                command.CommandText = query;
                command.Connection = connection;
                adapter = new SqlDataAdapter(command);
                try
                {
                    adapter.Fill(dataSet);
                    msg = "Consulta Correcta";
                }
                catch(Exception ex)
                {
                    msg = "Error: " + ex.Message;
                    dataSet = null;
                }
            }
            return dataSet;
        }

        public AccesoDatos() //constructor se crea primero cuando crea la clase
        {
            a = null;
        }
        public string InsertarMouse(Mouse a)
        {
            Equipo nuevo;
            nuevo = new Equipo();//crea un nuevo 
            nuevo.Informacion = a;
            string salida;
            {

            }
            return "Se inserto correctamente";
        }

        //public string InsertarMonitor(Monitor b) 
        //{
            
        //}

        //public string InsertarTeclado(Teclado c)
        //{

        //}

        //public string InsertarGabinete(Gabinete d)
        //{

        //}

        //public string InsertarDiscoDuro(DiscoDuro e)
        //{

        //}

        //public string InsertarMarca(Marca f)
        //{

        //}

        //public string InsertarComponente(DiscoDuro g)
        //{

        //}
        //public string InsertarModeloCPU(ModeloCPU h)
        //{

        //}
        //public string InsertarTipoCPU(TipoCpu i)
        //{

        //}
        //public string InsertarTipoRam(TipoRam j)
        //{

        //}
        //public string InsertarRam(Ram k)
        //{

        //}
        //public string InsertarCantDisc(cantDisc l)
        //{

        //}
        //public string InsertarLaboratorio(Laboratorio m)
        //{

        //}
        //public string InsertarUbicacion(Ubicacion n)
        //{

        //}
        //public string InsertarActualizacion(Actualizacion o)
        //{

        //}
        //public string InsertarCPU_Generico(CPU_Generico p)
        //{

        //}
        //public string InsertarCompuFinal(ComputadoraFinal q)
        //{

        //}


    }
}
