using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AccesoDatos
    {
        private string cadenaDB;
        SqlConnection connection;
        public AccesoDatos(string cadena)
        {
            connection = new SqlConnection();
            cadenaDB = cadena;
        }

        //Metodo para abrir la conexion a la base de datos
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
        //Metodo para cerra la conexion hacia la base de datos
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

        //Metodo para una consulta que incluya parametros
        public DataSet Innner_consulta(string query, ref string msg,List<SqlParameter> parameters)
        {
            DataSet data = new DataSet();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = null;
            msg = AbrirConexion();

            if (connection == null)
            {
                msg = "Sin Conexion a la Base de Datos";
                data = null;
            }
            else
            {
                command.CommandText = query;
                command.Connection = connection;
                adapter = new SqlDataAdapter(command);
                try
                {
                    adapter.Fill(data);
                    msg = "Consulta Correcta";
                }
                catch (Exception ex)
                {
                    msg = "Error: " + ex.Message;
                    data = null;
                }
            }
            CerrarConexion();
            return data;
        }

        //Metodo para hacer un select a todas las tablas de la base de datos con la cual vamos a trabajar
        public DataSet ConsultaGeneral(List<string> querys, ref string msg)
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
                int counter = 0;
                foreach(string query in querys)
                {
                    command.CommandText = query;
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    try
                    {
                        adapter.Fill(dataSet, counter.ToString());
                        msg = "Consulta Correcta";
                    }
                    catch (Exception ex)
                    {
                        msg = "Error: " + ex.Message;
                        dataSet = null;
                    }
                    counter++;
                }
            }
            CerrarConexion();
            return dataSet;
        }

        //Metodo para realizar las tareas de insertas, modificar y eliminar cualquier registro de cualquier tabla
        public Boolean Operaciones_Tables(string query, ref string msg, List<SqlParameter> parametros)
        {
            Boolean result = false;
            SqlCommand command = new SqlCommand();
            msg = AbrirConexion();

            if (connection == null)
            {
                msg = "Sin conexion a la base de datos";
            }
            else
            {
                command.CommandText = query;
                foreach(var parametro in parametros)
                {
                    command.Parameters.Add(parametro);
                }
                command.Connection = connection;
                try
                {
                    command.ExecuteNonQuery();
                    msg = "Se ha realizado correctamente la tarea";
                    result = true;
                }
                catch (Exception ex)
                {
                    msg = "Error: " + ex.Message;
                    result = false;
                }
            }
            CerrarConexion();

            return result;
        }
    }
}
