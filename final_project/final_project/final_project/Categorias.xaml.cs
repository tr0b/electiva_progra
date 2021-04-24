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
        public IList<Product> Productos { get; set; }
        string myConnectionString = "server=asusfinalproject.mysql.database.azure.com;uid=mainuser@asusfinalproject;" +
                "pwd=Admin123;database=asusfinalproject";
        public Categorias()
        {
            InitializeComponent();
            tb1.Clicked += Tb1_Clicked;
            tb2.Clicked += Tb2_Clicked;
            tb3.Clicked += Tb3_Clicked;
            tb4.Clicked += Tb4_Clicked;
            tb5.Clicked += Tb5_Clicked;
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
            Product selectedItem = e.SelectedItem as Product;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Product tappedItem = e.Item as Product;
        }
        private void Tb5_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private void GetProducts()
        {
            

                string productosQuery = "SELECT Nombre, Descripcion, Precio, Imagen FROM producto";

                //Productos.Add(new Producto
                //{
                //    Nombre = reader.GetString("Nombre"),
                //    Descripcion = reader.GetString("Descripcion"),
                //    Precio = reader.GetDouble("Precio"),
                //    Imagen = reader.GetString("Imagen"),
                //});
                using (var conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open(); // [NON ASYNC] Open Connection
                    using (var productosCmd = new MySqlCommand(productosQuery))
                    {
                    try
                    {
                        productosCmd.Connection = conn;
                        productosCmd.CommandText = productosQuery;
                        Productos = new List<Product>();
                        MySqlDataReader productosReader = productosCmd.ExecuteReader();
                        
                        while (productosReader.Read())
                        {
                            //lblnombre.Text += $"\n {productosReader.GetString(0)} - {productosReader.GetString(1)} - {productosReader.GetDouble(2).ToString()} - {productosReader.GetString(3)}";
                            Productos.Add(new Product
                            {
                                Nombre = productosReader.GetString(0),
                                Descripcion = productosReader.GetString(1),
                                Precio = productosReader.GetDouble(2).ToString(),
                                Imagen = productosReader.GetString(3)
                            });
                        };

                    } catch(Exception ex)
                    {
                        log.Text=ex.Message;
                    } finally {
                        conn.Close();
                        BindingContext = this;
                    }
                    }

                }      
        }
    }

}