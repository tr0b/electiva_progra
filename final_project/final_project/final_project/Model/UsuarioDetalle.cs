using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySqlConnector;

namespace final_project.Model
{
    class UsuarioDetalle
    {
        private static string ConnectionString = "Server = asusfinalproject.mysql.database.azure.com; Port = 3306; Database = asusfinalproject; Uid = mainuser@asusfinalproject; Pwd = Admin123; SslMode = Preferred;";

        public static void AddNewUser(string nombre, string apellido, string correo, string password)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "INSERT INTO usuario(Nombre,Apellido,Correo,Password) VALUES(?nombre,?apellido,?correo,?password)";
            cmd.Parameters.Add("?Nombre", MySqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("?Apellido", MySqlDbType.VarChar).Value = apellido;
            cmd.Parameters.Add("?Correo", MySqlDbType.Int32).Value = correo;
            cmd.Parameters.Add("?Password", MySqlDbType.VarChar).Value = password;
            cmd.Connection = conn;
            conn.Open();

            try
            {
                int aff = cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error encountered during INSERT operation.");
            }
            finally
            {
                conn.Close();
            }
        }

        public static void EditUser(int idUsuario, string nombre, string apellido, string correo, string password)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "UPDATE usuario SET Nombre='" + nombre + "',Apellido='" + apellido + "',Correo='" + correo + "',Password = '" + password + "' where idUsuario=" + idUsuario + ";";
            cmd.Connection = conn;
            conn.Open();

            try
            {
                int aff = cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error encountered during UPDATE operation.");
            }
            finally
            {
                conn.Close();
            }
        }
        public static void DeleteUser(int idUsuario)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "DELETE FROM usuario where idUsuario =" + idUsuario + ";";
            cmd.Connection = conn;
            conn.Open();

            try
            {
                int aff = cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error encountered during DELETE operation.");
            }
            finally
            {
                conn.Close();
            }
        }

    }
}

