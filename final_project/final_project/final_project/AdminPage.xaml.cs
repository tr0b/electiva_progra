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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
            btnUsuarios.Clicked += BtnUsuarios_Clicked;
            btnProductos.Clicked += BtnProductos_Clicked;
            tb5.Clicked += Tb5_Clicked;

        }
        private void BtnProductos_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new ManejoProducto());
        }
        private void BtnUsuarios_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new ManejoUsuario());
        }
        private void Tb5_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }
    }
}