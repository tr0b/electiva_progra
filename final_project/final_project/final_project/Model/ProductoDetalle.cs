using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySqlConnector;

namespace final_project.Model
{
    class ProductoDetalle
    {
        private static string ConnectionString = "Server = asusfinalproject.mysql.database.azure.com; Port = 3306; Database = asusfinalproject; Uid = mainuser@asusfinalproject; Pwd = Admin123; SslMode = Preferred;";
        MySqlConnection conn = new MySqlConnection(ConnectionString);
        MySqlCommand cmd = new MySqlCommand();

        public static void AddNewProduct(string nombre, int precio, string descripcion, int cantidad, string imagen)
        {        
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "INSERT INTO producto(Nombre,Precio,Descripcion,Cantidad,Imagen) VALUES(?nombre,?precio,?descripcion,?cantidad,?imagen)";
            cmd.Parameters.Add("?Nombre", MySqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("?Precio", MySqlDbType.Int32).Value = precio;
            cmd.Parameters.Add("?Descripcion", MySqlDbType.VarChar).Value = descripcion;
            cmd.Parameters.Add("?Cantidad", MySqlDbType.Int32).Value = cantidad;
            cmd.Parameters.Add("?Imagen", MySqlDbType.VarChar).Value = imagen;
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

        public static void EditProduct(int idProducto, string nombre, int precio, string descripcion, int cantidad, string imagen)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "UPDATE producto SET Nombre='"+nombre+"',Precio="+precio+",Descripcion='"+descripcion+"',Cantidad="+cantidad+",Imagen='"+imagen+"' where idProducto="+idProducto+";";          
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
        public static void DeleteProduct(int idProducto)
        {       
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "DELETE FROM producto where idProducto =" + idProducto +";";
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

