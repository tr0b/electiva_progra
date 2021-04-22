using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_project.Model;
using MySqlConnector;
using System.Data;

namespace final_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Categorias : ContentPage
    {
        public IList<Producto> Productos { get; private set; }
        private static string ConnectionString = "Server = asusfinalproject.mysql.database.azure.com; Port = 3306; Database = asusfinalproject; Uid = mainuser@asusfinalproject; Pwd = Admin123; SslMode = Preferred;";

        public Categorias()
        {
            InitializeComponent();
            tb1.Clicked += Tb1_Clicked;
            tb2.Clicked += Tb2_Clicked;
            tb3.Clicked += Tb3_Clicked;
            tb4.Clicked += Tb4_Clicked;
            verProducto.Clicked += VerProducto_Clicked;
            BindingContext = this;
            GetProducts();
        }
        private void Tb1_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Carrito());

        }
        private void Tb2_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new Inicio());
        }
        private void Tb3_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new Categorias());
        }
        private void Tb4_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new MisPagos());
        }

        private void VerProducto_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Producto());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Producto selectedItem = e.SelectedItem as Producto;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Producto tappedItem = e.Item as Producto;
        }

        private void GetProducts()
        {
            Productos = new List<Producto>();
            MySqlDataReader reader = null;
            var conn = new MySqlConnection(ConnectionString);

            try
            {
                string sql = "SELECT Nombre, Descripcion, Precio, Imagen FROM producto";
                var cmd = new MySqlCommand(sql, conn);

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Productos.Add(new Producto
                    //{
                    //    Nombre = reader.GetString("Nombre"),
                    //    Descripcion = reader.GetString("Descripcion"),
                    //    Precio = reader.GetDouble("Precio"),
                    //    Imagen = reader.GetString("Imagen"),
                    //});

                    lblnombre.Text = reader.GetString("Nombre");
                    lbldescripcion.Text = reader.GetString("Descripcion");
                    lblprecio.Text = "$" + Convert.ToString(reader.GetDouble("Precio"));
                    imagen.Source = reader.GetString("Imagen");
                }
                BindingContext = this;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error:", ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
    }

}