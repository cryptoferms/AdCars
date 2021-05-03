using AdCars.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var TokenAcesso = Preferences.Get("accessToken", string.Empty);
           fuif (string.IsNullOrEmpty(TokenAcesso))
                MainPage = new RegisterView();
            MainPage = new NavigationPage(new HomeView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
