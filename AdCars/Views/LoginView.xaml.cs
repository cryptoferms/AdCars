using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            EntEmail.Text = Preferences.Get("userInfo", string.Empty);
            lembrarme.IsChecked = Preferences.Get("LoginStatus", false);
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (lembrarme.IsChecked)
            {
                Preferences.Set("userInfo", EntEmail.Text);
                Preferences.Set("LoginStatus", lembrarme.IsChecked);
            }
            else
            {
                Preferences.Remove("userInfo");
                Preferences.Remove("LoginStatus");
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (EntSenha.IsPassword.Equals(true))
            {
                EntSenha.IsPassword = false;
                olho.Source = "baseline_visibility_off_24.xml";
                olho.WidthRequest = 32;
                olho.HeightRequest = 32;
            }
            else
            {
                EntSenha.IsPassword = true;
                olho.Source = "baseline_visibility_24.xml";
            }
        }
    }
}