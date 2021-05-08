using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AdCars.Views;
using Xamarin.Essentials;

namespace AdCars.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(); }
        }
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; OnPropertyChanged(); }
        }


        //commandos para metodos
        public Command LogoutCommand { get; set; }
        public Command TrocarSenhaCommand { get; set; }
        public Command TrocarTelefoneCommand { get; set; }


        public MyProfileViewModel()
        {
            TrocarSenhaCommand = new Command(async () => await TrocarSenhaAsync());
            TrocarTelefoneCommand = new Command(async () => await TrocarTelefoneAsync());
            LogoutCommand = new Command(async () => await LogoutCommandAsync());
            UserInfo();
        }

        private async Task TrocarTelefoneAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MudarTelefoneView());
        }

        private async Task TrocarSenhaAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MudarSenhaView());
        }

        private async Task LogoutCommandAsync()
        {
            Preferences.Remove("accessToken");
            Preferences.Remove("userNome");
            Preferences.Remove("userEmail");
            Application.Current.MainPage = new LoginView();
        }

        private void UserInfo()
        {
            Nome = Preferences.Get("userNome", string.Empty);
            Email = Preferences.Get("userEmail", string.Empty);
        }
    }
}
