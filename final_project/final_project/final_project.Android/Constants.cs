using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace final_project.Droid
{
    public static class Constants
    {
        #region MYSQL CONNECTION STRING

        public static string conectionString =
            "server=asusfinalproject.mysql.database.azure.com;port=3306;" +
            "user=mainuser@asusfinalproject;password=Admin123;database=asusfinalproject";
        #endregion


        #region MYSQL SELECT ALL QUERY

        public static string selectAllQuery = "SELECT '1' FROM usuario WHERE `Correo` = ? AND `Password` = ?";

        #endregion


        #region MYSQL INSERT COMMAND

        public static string insertNote = "insert into new_table(note,timestamp) values(@note,@timestap)";

        #endregion
    }
}