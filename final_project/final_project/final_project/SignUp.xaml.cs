using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using final_project.Model;

namespace final_project
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            btnCrearUsuario.Clicked += btnCrearUsuario_Clicked;

        }
        private void btnCrearUsuario_Clicked(object sender, EventArgs e)
        {
            UsuarioDetalle.AddNewUser(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtPassword.Text);
            log.Text = "Creación Exitosa";
        }
    }
}