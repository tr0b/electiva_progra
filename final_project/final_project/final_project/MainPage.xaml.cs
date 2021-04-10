using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Model;
using Xamarin.Forms;

namespace final_project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnIR.Clicked += BtnIR_Clicked;
            btnRecuperar.Clicked += BtnRecuperar_Clicked;
        }

        public void accesar()
        {
            
        }

        private void BtnIR_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Inicio());

        }
        private void BtnRecuperar_Clicked(object sender, EventArgs e)
        {


        }
    }
}
