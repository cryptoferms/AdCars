using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (EntSenha.IsPassword.Equals(true))
            {
                EntSenha.IsPassword = false;
                olho.Source = "eyeoff.png";
                olho.WidthRequest = 32;
                olho.HeightRequest = 32;
            }
            else
            {
                EntSenha.IsPassword = true;
                olho.Source = "eyeon.png";
            }
        }
    }
}