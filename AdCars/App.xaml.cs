using AdCars.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars
{
    public partial class App : Application
    {
        private int hi;
        public App()
        {
            InitializeComponent();
            var TokenAcesso = Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(TokenAcesso))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new NavigationPage(new HomeView());
            }
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
