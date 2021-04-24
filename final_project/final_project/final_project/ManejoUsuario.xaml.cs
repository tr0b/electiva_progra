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
    public partial class ManejoUsuario : ContentPage
    {
        public ManejoUsuario()
        {
            InitializeComponent();
            btnAdd.Clicked += btnAdd_Clicked;
            btnEditar.Clicked += btnEditar_Clicked;
            btnRemover.Clicked += btnRemover_Clicked;
        }
        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            UsuarioDetalle.AddNewUser(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtPassword.Text);
            resultado.Text = "Usuario Añadido";
        }
        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            UsuarioDetalle.EditUser(Convert.ToInt32(txtIdE.Text), txtNombreE.Text, txtApellidoE.Text, txtCorreo.Text, txtPassword.Text);
            resultadoE.Text = "Usuario Guardado";
        }
        private void btnRemover_Clicked(object sender, EventArgs e)
        {
            UsuarioDetalle.DeleteUser(Convert.ToInt32(txtIdR.Text));
            resultadoR.Text = "Usuario Removido";
        }

    }
}