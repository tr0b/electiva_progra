using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Confirmacion : ContentPage
    {
        public Confirmacion()
        {
            InitializeComponent();
            tb1.Clicked += Tb1_Clicked;
            tb2.Clicked += Tb2_Clicked;
            tb3.Clicked += Tb3_Clicked;
            tb4.Clicked += Tb4_Clicked;
            tb5.Clicked += Tb5_Clicked;

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
        private void Tb5_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }
    }
}