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
        public Command VoltarCommand { get; set; }

        public RegisterViewModel()
        {  
            VoltarCommand = new Command(async () => await VoltarCommandAsync());
        }
        private async Task VoltarCommandAsync()
        {
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }
    }
}
