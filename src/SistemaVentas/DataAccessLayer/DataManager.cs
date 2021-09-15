using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public class DataManager
{

    private string string_conexion;
    private static DataManager instance;
    public DataManager()
    {
        string_conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=BugTracker;Integrated Security=true;";
    }

    // Con el siguiente método aplicamos el patrón singleton
    public static DataManager GetInstance()
    {
        if (instance == null)
            instance = new DataManager();

        return instance;
    }

    /// Resumen:
    ///      Se utiliza para sentencias SQL del tipo “Select” con parámetros recibidos desde la interfaz
    ///      La función recibe por valor una sentencia sql como string y un diccionario de objetos como parámetros
    /// Devuelve:
    ///      un objeto de tipo DataTable con el resultado de la consulta
    /// Excepciones:
    ///      System.Data.SqlClient.SqlException:
    ///          El error de conexión se produce:
    ///              a) durante la apertura de la conexión
    ///              b) durante la ejecución del comando.
    public DataTable ConsultaSQL(string strSql, Dictionary<string, object> prs = null)
    {

        SqlConnection dbConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable tabla = new DataTable();
        try
        {

            dbConnection.ConnectionString = string_conexion;
            dbConnection.Open();
            cmd.Connection = dbConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;

            //Agregamos a la colección de parámetros del comando los filtros recibidos
            if (prs != null)
            {
                foreach (var item in prs)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            tabla.Load(cmd.ExecuteReader());
            return tabla;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();
        }
    }

    /// Resumen:
    ///     Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”. Recibe por valor una sentencia sql como string
    /// Devuelve:
    ///      un valor entero con el número de filas afectadas por la sentencia ejecutada
    /// Excepciones:
    ///      System.Data.SqlClient.SqlException:
    ///          El error de conexión se produce:
    ///              a) durante la apertura de la conexión
    ///              b) durante la ejecución del comando.
    public int EjecutarSQL(string strSql, Dictionary<string, object> prs = null)
    {
        // Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”
        SqlConnection dbConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        int rtdo = 0;

        // Try Catch Finally
        // Trata de ejecutar el código contenido dentro del bloque Try - Catch
        // Si hay error lo capta a través de una excepción
        // Si no hubo error
        try
        {
            dbConnection.ConnectionString = string_conexion;
            dbConnection.Open();
            cmd.Connection = dbConnection;
            cmd.CommandType = CommandType.Text;
            // Establece la instrucción a ejecutar
            cmd.CommandText = strSql;

            //Agregamos a la colección de parámetros del comando los filtros recibidos
            if (prs != null)
            {
                foreach (var item in prs)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            // Retorna el resultado de ejecutar el comando
            rtdo = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();
        }
        return rtdo;
    }


    /// Resumen:
    ///     Se utiliza para sentencias SQL del tipo “Select”. Recibe por valor una sentencia sql como string
    /// Devuelve:
    ///      un valor entero
    /// Excepciones:
    ///      System.Data.SqlClient.SqlException:
    ///          El error de conexión se produce:
    ///              a) durante la apertura de la conexión
    ///              b) durante la ejecución del comando.
    public object ConsultaSQLScalar(string strSql)
    {
        SqlConnection dbConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        try
        {
            dbConnection.ConnectionString = string_conexion;
            dbConnection.Open();
            cmd.Connection = dbConnection;
            cmd.CommandType = CommandType.Text;
            // Establece la instrucción a ejecutar
            cmd.CommandText = strSql;
            return cmd.ExecuteScalar();
        }
        catch (SqlException ex)
        {
            throw (ex);
        }
        finally
        {
            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();
        }
    }

}