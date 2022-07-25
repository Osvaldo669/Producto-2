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
                    msg = "Se ha realizado correctamento";
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
