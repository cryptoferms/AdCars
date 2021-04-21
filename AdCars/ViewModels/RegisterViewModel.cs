using AdCars.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdCars.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }

        public RegisterViewModel()
        {  
            LoginCommand = new Command(async () => await LoginCommandAsync());
        }
        private async Task LoginCommandAsync()
        {
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }
    }
}
