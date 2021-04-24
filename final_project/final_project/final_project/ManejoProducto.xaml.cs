using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_project.Model;

namespace final_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManejoProducto : ContentPage
    {
        public ManejoProducto()
        {
            InitializeComponent();
            btnAdd.Clicked += btnAdd_Clicked;
            btnEditar.Clicked += btnEditar_Clicked;
            btnRemover.Clicked += btnRemover_Clicked;
            tb5.Clicked += Tb5_Clicked;
        }
        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            ProductoDetalle.AddNewProduct(txtNombre.Text, Convert.ToInt32(txtPrecio.Text), txtDescripcion.Text, Convert.ToInt32(txtCantidad.Text),txtImagen.Text);
            resultado.Text = "Producto Añadido";
        }
        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            ProductoDetalle.EditProduct(Convert.ToInt32(txtIdE.Text),txtNombreE.Text, Convert.ToInt32(txtPrecioE.Text), txtDescripcionE.Text, Convert.ToInt32(txtCantidadE.Text), txtImagenE.Text);
            resultadoE.Text = "Producto Guardado";
        }
        private void btnRemover_Clicked(object sender, EventArgs e)
        {
            ProductoDetalle.DeleteProduct(Convert.ToInt32(txtIdR.Text));
            resultadoR.Text = "Producto Removido";
        }
        private void Tb5_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

    }
}