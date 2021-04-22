using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySqlConnector;

namespace final_project
{
    public partial class MainPage : ContentPage
    {
        string myConnectionString = "server=asusfinalproject.mysql.database.azure.com;uid=mainuser@asusfinalproject;" +
        "pwd=Admin123;database=asusfinalproject";

        public MainPage()
        {
            InitializeComponent();
            btnIR.Clicked += BtnIR_Clicked;

        }

        private void BtnIR_Clicked(object sender, EventArgs e)
        {
            // Handle Login..
            string loginQuery = "SELECT COUNT(*) FROM usuario WHERE `Correo`=@mail AND `Password`=@pass;";
            string mail = email.Text;
            string pass = password.Text;

            //Mail or pass are empty? Return.
            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(pass)) { return; } // No mail/pass? Return.
                using (var conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open(); // Opens Connection

                    using (var loginCmd = new MySqlCommand(loginQuery)) // Prepares Query
                    {
                    try {
                        loginCmd.Connection = conn;
                        loginCmd.CommandText = loginQuery;
                        loginCmd.Parameters.AddWithValue("mail", mail);
                        loginCmd.Parameters.AddWithValue("pass", pass);
                        object result = loginCmd.ExecuteScalar();
                        conn.Close();
                        int count = Convert.ToInt32(result);
                        if (count != 1) { log.Text = "Credenciales Invalidas"; return; } // Account not found? Return.
                        ((NavigationPage)this.Parent).PushAsync(new Inicio());
                    }
                    catch (Exception ex) { log.Text = $"Error: {ex.Message}"; }
                        
                    }

                }

        }
        
    }
}